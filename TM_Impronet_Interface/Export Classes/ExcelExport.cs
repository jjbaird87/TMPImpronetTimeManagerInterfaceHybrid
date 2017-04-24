using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using TM_Impronet_Interface.Classes;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Export_Classes
{
    public static class ExcelExport
    {
        public static event EventHandler OnProgressHandler;

        public static void OnProgress(int progress = 0, int totalRecords = 0, string status = "")
        {
            try
            {
                var onProgressHandler = OnProgressHandler;
                if (onProgressHandler == null)
                    return;
                var progressEventArgs = new ProgressEventArgs {Progress = progress, TotalRecords = totalRecords, Status = status};
                onProgressHandler(null, progressEventArgs);
            }
            catch
            {
                //Do nothing
            }
        }        

        public static void Export(DateTime from, DateTime to, 
            bool filterEnabled = false, string costCentreFrom = "", string costCentreTo = "")
        {
            var recordCount = 0;
            if (Settings.Default.EbExcelExportLocation == "")
                throw new Exception("Please select a location to export the report");

            OnProgress(0,0,"Running Excel Export");
            var path = Settings.Default.EbExcelExportLocation + $"\\EarlyBirdReport_{to:yy-MM-dd}.xlsx";
            try
            {
                var fbConnection = new FbConnection("User=SYSDBA;Password=masterkey;Database=" +
                                                    Settings.Default.TMPDatabaseLocation + ";DataSource=" +
                                                    Settings.Default.TmpNetworkLocation +
                                                    ";Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;Packet Size=8192;ServerType=0");
                fbConnection.Open();
                var fbTransaction = fbConnection.BeginTransaction();
                var fbCommand = new FbCommand
                {
                    Connection = fbConnection,
                    Transaction = fbTransaction,
                    CommandText =
                        "SELECT COUNT(*) FROM CLOCKD a WHERE a.DATETIME >= @START_DATE AND a.DATETIME <= @END_DATE AND a.CALC0 IS NOT NULL"
                };
                if (filterEnabled)
                {
                    fbCommand.CommandText = "SELECT COUNT(*) FROM CLOCKD a " +
                                            "INNER JOIN EMP b ON a.EMPNO = b.EMP_NO " +
                                            "WHERE" +
                                            "   a.DATETIME >= @START_DATE AND a.DATETIME <= @END_DATE AND" +
                                            "   b.DEPARTMENT >= @CCFROM AND b.DEPARTMENT <= @CCTO AND a.CALC0 IS NOT NULL";

                    fbCommand.Parameters.Add("@CCFROM", FbDbType.VarChar).Value = costCentreFrom;
                    fbCommand.Parameters.Add("@CCTO", FbDbType.VarChar).Value = costCentreTo;
                }

                //Get Count
                fbCommand.Parameters.Add("@START_DATE", FbDbType.TimeStamp).Value = Helpers.GetLowestDt(from);
                fbCommand.Parameters.Add("@END_DATE", FbDbType.TimeStamp).Value = Helpers.GetHighestDt(to);
                var userCount = (int)fbCommand.ExecuteScalar();

                fbCommand = new FbCommand
                {
                    Connection = fbConnection,
                    Transaction = fbTransaction,
                    CommandText =
                        "SELECT r.EMPNO, r.DATETIME, r.WORKPAT, r.SHIFTS, r.CALC0, r.CALC1, r.CALC2, r.TOTALHOURS, r.DOW, r.FREE, r.LOST, r.SHIFT, r.CLOCKINGNOTES, e.NAME, e.SURNAME, e.WORKPATTERN, d.DESCRIPTION AS DEPARTMENTNAME, ro.DESCRIPTION AS ROSTERNAME " +
                        "FROM CLOCKD r " +
                        "INNER JOIN EMP e ON e.EMP_NO = r.EMPNO " +
                        "INNER JOIN DEPARTMENTS d ON e.DEPARTMENT = d.CODE " +
                        "LEFT OUTER JOIN ROSTERS ro on e.ROSTER = ro.CODE " +
                        "WHERE r.DATETIME >= @START_DATE AND r.DATETIME <= @END_DATE AND r.CALC0 IS NOT NULL " +
                        "ORDER BY r.EMPNO, r.DATETIME"
                };
                if (filterEnabled)
                {
                    fbCommand.CommandText =
                        "SELECT r.EMPNO, r.DATETIME, r.WORKPAT, r.SHIFTS, r.CALC0, r.CALC1, r.CALC2, r.TOTALHOURS, r.DOW, r.FREE, r.LOST, r.SHIFT, r.CLOCKINGNOTES, e.NAME, e.SURNAME, e.WORKPATTERN, d.DESCRIPTION AS DEPARTMENTNAME, ro.DESCRIPTION AS ROSTERNAME " +
                        "FROM CLOCKD r " +
                        "INNER JOIN EMP e ON e.EMP_NO = r.EMPNO " +
                        "INNER JOIN DEPARTMENTS d ON e.DEPARTMENT = d.CODE " +
                        "LEFT OUTER JOIN ROSTERS ro on e.ROSTER = ro.CODE " +
                        "WHERE r.DATETIME >= @START_DATE AND r.DATETIME <= @END_DATE AND " +
                        "e.DEPARTMENT >= @CCFROM AND e.DEPARTMENT <= @CCTO AND r.CALC0 IS NOT NULL " +
                        "ORDER BY r.EMPNO, r.DATETIME";
                    fbCommand.Parameters.Add("@CCFROM", FbDbType.VarChar).Value = costCentreFrom;
                    fbCommand.Parameters.Add("@CCTO", FbDbType.VarChar).Value = costCentreTo;
                }
                fbCommand.Parameters.Add("@START_DATE", FbDbType.TimeStamp).Value = Helpers.GetLowestDt(from);
                fbCommand.Parameters.Add("@END_DATE", FbDbType.TimeStamp).Value = Helpers.GetHighestDt(to);

                var myReader = fbCommand.ExecuteReader();
                var previousEmployee = "";
                var currentUserCount = 0;
                var records = new List<EbExcelExport>();
                var employeeInfo = new EbExcelExport();
                while (myReader.Read())
                {
                    OnProgress(recordCount++, userCount);
                    var emp = myReader["EMPNO"].ToString();
                    if (emp != previousEmployee && previousEmployee != "" || currentUserCount + 1 == userCount)
                    {
                        if (currentUserCount + 1 == userCount)
                            GetHourInfo(employeeInfo, myReader);
                        if (employeeInfo.NormalTime + employeeInfo.Time15 + employeeInfo.DoubleTime > 0.0)
                        {
                            employeeInfo.NormalTime = employeeInfo.NormalTime / 60.0;
                            employeeInfo.Time15 = employeeInfo.Time15 / 60.0;
                            employeeInfo.DoubleTime = employeeInfo.DoubleTime / 60.0;
                            employeeInfo.LostTime = employeeInfo.LostTime / 60.0;
                            employeeInfo.SundayTime = employeeInfo.SundayTime / 60.0;
                            records.Add(employeeInfo);
                        }
                        employeeInfo = new EbExcelExport();
                        GetInitialEmployeeInfo(employeeInfo, myReader, emp);
                        GetHourInfo(employeeInfo, myReader);
                    }
                    else
                    {
                        if (employeeInfo.EmployeeNo == null)
                            GetInitialEmployeeInfo(employeeInfo, myReader, emp);
                        GetHourInfo(employeeInfo, myReader);
                    }
                    previousEmployee = emp;
                    ++currentUserCount;
                }

                fbConnection.Close();
                fbCommand.Dispose();

                //Sort records by name alphabetically
                records = records.OrderBy(i => i.Employee).ToList();

                //Export to excel
                var memoryStream = XlsxRw.ExportDataSet(records, from);
                long offset = 0;
                var num4 = 0;
                memoryStream.Seek(offset, (SeekOrigin) num4);
                var end = ReadToEnd(memoryStream);
                File.WriteAllBytes(path, end);
                OnProgress(userCount, userCount, $"Report Successfully exported\n{userCount} record(s) processed");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Row: " + recordCount);
            }
        }

        public static byte[] ReadToEnd(Stream stream)
        {
            long num1 = 0;
            if (stream.CanSeek)
            {
                num1 = stream.Position;
                stream.Position = 0L;
            }
            try
            {
                var buffer = new byte[4096];
                var length = 0;
                int num2;
                while ((num2 = stream.Read(buffer, length, buffer.Length - length)) > 0)
                {
                    length += num2;
                    if (length == buffer.Length)
                    {
                        var num3 = stream.ReadByte();
                        if (num3 != -1)
                        {
                            var numArray = new byte[buffer.Length * 2];
                            Buffer.BlockCopy(buffer, 0, numArray, 0, buffer.Length);
                            Buffer.SetByte(numArray, length, (byte) num3);
                            buffer = numArray;
                            ++length;
                        }
                    }
                }
                var numArray1 = buffer;
                if (buffer.Length != length)
                {
                    numArray1 = new byte[length];
                    Buffer.BlockCopy(buffer, 0, numArray1, 0, length);
                }
                return numArray1;
            }
            finally
            {
                if (stream.CanSeek)
                    stream.Position = num1;
            }
        }

        private static void GetInitialEmployeeInfo(EbExcelExport employeeInfo, FbDataReader myReader, string emp)
        {
            employeeInfo.Department = myReader["DEPARTMENTNAME"].ToString();
            employeeInfo.Employee = $"{myReader["NAME"]} {myReader["SURNAME"]}";
            employeeInfo.EmployeeNo = emp;
            employeeInfo.Roster = myReader["ROSTERNAME"].ToString();
            employeeInfo.DateAndTimes = new List<DateInOut>();
        }

        private static void GetStartAndEndTimes(DateInOut dateInOut, string employeeNo)
        {
            var fbConnection = new FbConnection("User=SYSDBA;Password=masterkey;Database=" +
                                                Settings.Default.TMPDatabaseLocation + ";DataSource=" +
                                                Settings.Default.TmpNetworkLocation +
                                                ";Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;Packet Size=8192;ServerType=0");
            var fbCommand1 = new FbCommand();
            try
            {
                fbConnection.Open();
                var fbTransaction = fbConnection.BeginTransaction();
                var fbCommand2 = new FbCommand
                {
                    Connection = fbConnection,
                    Transaction = fbTransaction
                };
                var str =
                    "SELECT MIN(r.CLKTIME) AS LOWTIME, MAX(r.CLKTIME) AS HIGHTIME FROM CLOCKING r WHERE CODE = @EMPNO AND CLKDATE = @DATE_TIME";
                fbCommand2.CommandText = str;
                fbCommand1 = fbCommand2;
                fbCommand1.Parameters.Add("@EMPNO", FbDbType.TimeStamp).Value = employeeNo;
                fbCommand1.Parameters.Add("@DATE_TIME", FbDbType.TimeStamp).Value = dateInOut.Date;
                var fbDataReader = fbCommand1.ExecuteReader();
                while (fbDataReader.Read())
                {
                    if (!fbDataReader.IsDBNull(0))
                        dateInOut.TimeIn = (DateTime) fbDataReader["LOWTIME"];
                    if (!fbDataReader.IsDBNull(1))
                        dateInOut.TimeOut = (DateTime) fbDataReader["HIGHTIME"];
                }
            }
            finally
            {
                fbConnection.Close();
                fbCommand1.Dispose();
                fbConnection.Close();
            }
        }

        private static void GetHourInfo(EbExcelExport employeeInfo, FbDataReader myReader)
        {
            var dateInOut = new DateInOut()
            {
                Date = (DateTime) myReader["DATETIME"]
            };
            GetStartAndEndTimes(dateInOut, employeeInfo.EmployeeNo);
            employeeInfo.DateAndTimes.Add(dateInOut);
            employeeInfo.NormalTime += Convert.ToDouble(myReader["CALC0"]);
            employeeInfo.Time15 += Convert.ToDouble(myReader["CALC1"]);
            employeeInfo.DoubleTime += Convert.ToDouble(myReader["CALC2"]);
            employeeInfo.LostTime += Convert.ToDouble(myReader["LOST"]);
            if ((int) myReader["DOW"] != 0)
                return;
            employeeInfo.SundayTime += Convert.ToDouble(myReader["TOTALHOURS"]);
        }        
    }
}

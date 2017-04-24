using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using TM_Impronet_Interface.Classes;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Export_Classes
{
    public static class IntegrityExport
    {
        public static event EventHandler OnProgressHandler;

        public static void OnProgress(int progress = 0, int totalRecords = 0, string status = "")
        {
            try
            {
                var onProgressHandler = OnProgressHandler;
                if (onProgressHandler == null)
                    return;
                var progressEventArgs =
                    new ProgressEventArgs {Progress = progress, TotalRecords = totalRecords, Status = status};
                onProgressHandler(null, progressEventArgs);
            }
            catch
            {
                //Do nothing
            }
        }

        public class ExportLine
        {
            public string EmployeeNumber { get; set; }
            public double NormalTime { get; set; }
            public double OverTime { get; set; }
            public double DoubleTime { get; set; }
            public double Calc3 { get; set; }
            public double Calc4 { get; set; }
        }

        public static void ExportIntegrity(DateTime from, DateTime to,
            bool filterEnabled = false, string costCentreFrom = "", string costCentreTo = "")
        {
            var iCounter = 0;
            var fileName = Settings.Default.IntegrityExportLocation;

            try
            {
                // Set the ServerType to 1 for connect to the embedded server
                var connectionString =
                    "User=SYSDBA;" +
                    "Password=masterkey;" +
                    "Database=" + Settings.Default.TMPDatabaseLocation + ";" +
                    "DataSource=" + Settings.Default.TmpNetworkLocation + ";" +
                    "Port=3050;" +
                    "Dialect=3;" +
                    "Charset=NONE;" +
                    "Role=;" +
                    "Connection lifetime=15;" +
                    "Pooling=true;" +
                    "Packet Size=8192;" +
                    "ServerType=0";

                var myConnection = new FbConnection(connectionString);
                myConnection.Open();

                var myTransaction = myConnection.BeginTransaction();
                var myCommand = new FbCommand
                {
                    Connection = myConnection,
                    Transaction = myTransaction,
                    CommandText = "SELECT COUNT(*) FROM CLOCKD " +
                                  "WHERE DATETIME >= @START_DATE AND DATETIME <= @END_DATE AND CALC0 IS NOT NULL"
                };
                if (filterEnabled)
                {
                    myCommand.CommandText = "SELECT COUNT(*) FROM CLOCKD a " +
                                            "INNER JOIN EMP b ON a.EMPNO = b.EMP_NO " +
                                            "WHERE" +
                                            "   a.DATETIME >= @START_DATE AND a.DATETIME <= @END_DATE AND" +
                                            "   b.DEPARTMENT >= @CCFROM AND b.DEPARTMENT <= @CCTO AND a.CALC0 IS NOT NULL";

                    myCommand.Parameters.Add("@CCFROM", FbDbType.VarChar).Value = costCentreFrom;
                    myCommand.Parameters.Add("@CCTO", FbDbType.VarChar).Value = costCentreTo;
                }

                myCommand.Parameters.Add("@START_DATE", FbDbType.TimeStamp).Value = Helpers.GetLowestDt(from);
                myCommand.Parameters.Add("@END_DATE", FbDbType.TimeStamp).Value = Helpers.GetHighestDt(to);


                //Get amount of records
                var iCount = (int) myCommand.ExecuteScalar();

                myCommand.CommandText = "SELECT * FROM CLOCKD " +
                                        "WHERE DATETIME >= @START_DATE AND DATETIME <= @END_DATE AND CALC0 IS NOT NULL " +
                                        "ORDER BY EMPNO, DATETIME";
                if (filterEnabled)
                {
                    myCommand.CommandText = "SELECT * FROM CLOCKD a " +
                                            "INNER JOIN EMP b ON a.EMPNO = b.EMP_NO " +
                                            "WHERE a.DATETIME >= @START_DATE AND a.DATETIME <= @END_DATE AND " +
                                            "b.DEPARTMENT >= @CCFROM AND b.DEPARTMENT <= @CCTO AND a.CALC0 IS NOT NULL AND a.TARGET0 IS NOT NULL " +
                                            "ORDER BY a.EMPNO, a.DATETIME";
                }
                var myReader = myCommand.ExecuteReader();

                var lastEmployee = "";
                var internalCounter = 0;
                var exportLine = new ExportLine();
                var exportLines = new List<string>();
                var errorUsers = new List<string>();

                while (myReader.Read())
                {
                    //increment toolbar                    
                    OnProgress(internalCounter, iCount);

                    //Last employee
                    var emp = myReader["EMPNO"].ToString();
                    exportLine.EmployeeNumber = emp;

                    if (emp != lastEmployee && lastEmployee != "" || internalCounter == iCount)
                    {
                        //If it is the last record, add the last hours
                        if (internalCounter == iCount)
                        {

                            exportLine.NormalTime += Convert.ToDouble(myReader["CALC0"]);
                            exportLine.OverTime += Convert.ToDouble(myReader["CALC1"]);
                            exportLine.DoubleTime += Convert.ToDouble(myReader["CALC2"]);
                            exportLine.Calc3 += Convert.ToDouble(myReader["CALC3"]);
                            exportLine.Calc4 += Convert.ToDouble(myReader["CALC4"]);
                        }

                        //Add current line
                        if (exportLine.EmployeeNumber.Length > 7)
                            errorUsers.Add(exportLine.EmployeeNumber);
                        else
                        {
                            //Check for any negative values
                            if (exportLine.NormalTime < 0)
                                exportLine.NormalTime = 0;
                            if (exportLine.OverTime < 0)
                                exportLine.OverTime = 0;
                            if (exportLine.DoubleTime < 0)
                                exportLine.DoubleTime = 0;
                            if (exportLine.Calc3 < 0)
                                exportLine.Calc3 = 0;
                            if (exportLine.Calc4 < 0)
                                exportLine.Calc4 = 0;

                            //Add lines to list
                            exportLines.Add(
                                $"{lastEmployee.PadLeft(7, '0')}" +
                                (Settings.Default.Calc0
                                    ? $"{Math.Round(exportLine.NormalTime / 60, 2).ToString("#.00", CultureInfo.InvariantCulture).Replace(".", "").PadLeft(5, '0')}"
                                    : "") +
                                (Settings.Default.Calc1
                                    ? $"{Math.Round(exportLine.OverTime / 60, 2).ToString("#.00", CultureInfo.InvariantCulture).Replace(".", "").PadLeft(5, '0')}"
                                    : "") +
                                (Settings.Default.Calc2
                                    ? $"{Math.Round(exportLine.DoubleTime / 60, 2).ToString("#.00", CultureInfo.InvariantCulture).Replace(".", "").PadLeft(5, '0')}"
                                    : "") +
                                (Settings.Default.Calc3
                                    ? $"{Math.Round(exportLine.Calc3 / 60, 2).ToString("#.00", CultureInfo.InvariantCulture).Replace(".", "").PadLeft(5, '0')}"
                                    : "") +
                                (Settings.Default.Calc4
                                    ? $"{Math.Round(exportLine.Calc4 / 60, 2).ToString("#.00", CultureInfo.InvariantCulture).Replace(".", "").PadLeft(5, '0')}"
                                    : ""));                          
                        }

                        //Add hours of the current employee
                        exportLine = new ExportLine
                        {
                            NormalTime = Convert.ToDouble(myReader["CALC0"]),
                            OverTime = Convert.ToDouble(myReader["CALC1"]),
                            DoubleTime = Convert.ToDouble(myReader["CALC2"]),
                            Calc3 = Convert.ToDouble(myReader["CALC3"]),
                            Calc4 = Convert.ToDouble(myReader["CALC4"])
                        };
                    }
                    else
                    {
                        exportLine.NormalTime += Convert.ToDouble(myReader["CALC0"]);
                        exportLine.OverTime += Convert.ToDouble(myReader["CALC1"]);
                        exportLine.DoubleTime += Convert.ToDouble(myReader["CALC2"]);
                        exportLine.Calc3 += Convert.ToDouble(myReader["CALC3"]);
                        exportLine.Calc4 += Convert.ToDouble(myReader["CALC4"]);
                    }

                    lastEmployee = emp;
                    internalCounter++;
                }

                myConnection.Close();
                myCommand.Dispose();
                myConnection.Close();

                //Write Error users to file
                var directory = Path.GetDirectoryName(fileName);
                File.WriteAllLines($@"{directory}\ProblemEmployees.txt", errorUsers);

                //Write to File
                File.AppendAllLines(fileName, exportLines);

                OnProgress(100, 100, $"{iCount} record(s) processed");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + @" Row: " + iCounter, ex);
            }
        }
    }
}
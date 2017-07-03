using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TM_Impronet_Interface.Classes;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Export_Classes
{
    public static class TmpExport
    {
        public static event EventHandler OnProgressHandler;

        public static void OnProgress(int progress = 0, int totalRecords = 0, string status = "")
        {
            try
            {
                var onProgressHandler = OnProgressHandler;
                if (onProgressHandler == null)
                    return;
                var progressEventArgs = new ProgressEventArgs { Progress = progress, TotalRecords = totalRecords, Status = status };
                onProgressHandler(null, progressEventArgs);
            }
            catch
            {
                //Do nothing
            }
        }

        public static void Export(DateTime startDate, DateTime endDate, bool automated)
        {
            //Validation
            if (string.IsNullOrEmpty(Settings.Default.TmpExportLocation))
                throw new Exception("The output directory can't be empty");

            var unProcessed = 0;
            var iCounter = 0;

            //Create a list for all of the rows for in memory processing
            var improDataAccess = new ImproDataAccess();
            var fileOutput = new List<string>();
            var iCount = 0;

            try
            {                
                iCount = improDataAccess.GetTransactionCount(startDate, endDate, automated);
                OnProgress(0, 0, iCount + @" record(s) found");
                
                var myReader = improDataAccess.GetUnprocessedTransactions(startDate, endDate);

                //Read Current Mappings
                var full = Settings.Default.Mappings;
                var singleMappings = full.Split(',');
                var departmentMappings = new List<DepartmentMapping>();
                if (Settings.Default.MappingConfig == 1)
                {
                    departmentMappings =
                        DeSerializeObject<DepartmentMappings>("DepartmentMappings.mxl").DepartmentMappingses;
                }

                while (myReader.Read())
                {
                    iCounter++;

                    //increment toolbar
                    OnProgress(iCounter, iCount);

                    //standard data                    
                    var employeeNo = myReader["TR_MSTSQ"].ToString().PadRight(8, ' ');

                    var tDate = myReader["TR_DATE"].ToString();
                    //Build Date
                    var date = $"{tDate[6]}{tDate[7]}/{tDate[4]}{tDate[5]}/{tDate[0]}{tDate[1]}{tDate[2]}{tDate[3]}";

                    var tTime = myReader["TR_TIME"].ToString();
                    //Build Time
                    var time = "";
                    if (tTime.Length == 3)
                        time = $"00:0{tTime[0]}";
                    switch (tTime.Length)
                    {
                        case 4:
                            time = $"00:{tTime[0]}{tTime[1]}";
                            break;
                        case 5:
                            time = $"0{tTime[0]}:{tTime[1]}{tTime[2]}";
                            break;
                        case 6:
                            time = $"{tTime[0]}{tTime[1]}:{tTime[2]}{tTime[3]}";
                            break;
                    }

                    var direction = myReader["TR_DIRECTION"].ToString();
                    switch (direction)
                    {
                        case "0":
                            direction = "O";
                            break;
                        case "1":
                            direction = "I";
                            break;
                        default:
                            direction = "I";
                            break;
                    }


                    //Compare mappings
                    var departmentId = myReader["DEPT_No"].ToString();
                    string sFound;
                    if (Settings.Default.MappingConfig == 0)
                    {
                        sFound = singleMappings.FirstOrDefault(i => i.Contains(myReader["TR_TERMSLA"].ToString()));

                        if (sFound == null)
                        {
                            unProcessed++;
                            Application.DoEvents();
                            continue;
                        }
                        sFound = sFound.Split(';')[1];
                    }
                    else
                    {
                        var departmentMapping = departmentMappings.FindAll(i => i.Department.Id == departmentId);
                        if (departmentMapping.Count > 0)
                        {
                            var terminals = departmentMapping[0]
                                .Terminals.FindAll(i => i.Id.Contains(myReader["TR_TERMSLA"].ToString()));

                            sFound = terminals.Count > 0
                                ? Settings.Default.DepTimeAndAttendanceCode
                                : Settings.Default.DepAccessControlCode;
                        }
                        else
                        {
                            sFound = Settings.Default.DepAccessControlCode;
                        }
                    }

                    if (sFound == "") continue;
                    if (!Settings.Default.SyncAccessControl)
                        if (sFound == Settings.Default.DepAccessControlCode)
                        {
                            Application.DoEvents();
                            continue;
                        }
                    var line = $"{employeeNo} {date} {time} {direction} {sFound}";
                    fileOutput.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + @" Row: " + iCounter + "\n\n" + ex);
            }
            finally
            {
                improDataAccess.CloseConnection();
            }

            File.AppendAllLines(Settings.Default.TmpExportLocation, fileOutput);

            if (automated)
            {
                improDataAccess.UpdateProcessed();
            }

            OnProgress(iCount, iCount,
                $"{iCount} record(s) processed and {unProcessed} record(s) skipped due to no mappings");         
        }        

        private static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return default(T);
            }

            var objectOut = default(T);

            try
            {
                var xmlDocument = new XmlDocument();
                if (!File.Exists(fileName))
                    return objectOut;
                xmlDocument.Load(fileName);
                var xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader(xmlString))
                {
                    var outType = typeof(T);

                    var serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return objectOut;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface.Classes
{
    public static class XlsxRw
    {
        private static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
        {
            IEnumerable<Sheet> source = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where<Sheet>((Func<Sheet, bool>)(s => (string)s.Name == sheetName));
            Sheet[] sheetArray = source as Sheet[] ?? source.ToArray<Sheet>();
            if (!((IEnumerable<Sheet>)sheetArray).Any<Sheet>())
                return (WorksheetPart)null;
            string id = ((IEnumerable<Sheet>)sheetArray).First<Sheet>().Id.Value;
            return (WorksheetPart)document.WorkbookPart.GetPartById(id);
        }

        public static MemoryStream ExportDataSet(List<EbExcelExport> records, DateTime selectedStartDate)
        {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(Resources.EarlybirdTemplate, 0, Resources.EarlybirdTemplate.Length);
            memoryStream.Position = 0L;
            using (SpreadsheetDocument document = SpreadsheetDocument.Open((Stream)memoryStream, true))
            {
                SheetData firstChild = XlsxRw.GetWorksheetPartByName(document, "Sheet1").Worksheet.GetFirstChild<SheetData>();
                foreach (EbExcelExport record in records)
                {
                    Row row = new Row();
                    XlsxRw.AddStringCell(record.EmployeeNo, row);
                    XlsxRw.AddStringCell(record.Employee, row);
                    XlsxRw.AddStringCell(record.Department, row);
                    XlsxRw.AddStringCell(record.Roster, row);
                    int index1 = 0;
                    for (int index2 = 0; index2 < record.DateAndTimes.Count; ++index2)
                    {
                        if (record.DateAndTimes[index1].Date.DayOfWeek == (DayOfWeek)(index2 + 1))
                        {
                            DateTime? nullable = record.DateAndTimes[index1].TimeIn;
                            string str1;
                            if (nullable.HasValue)
                            {
                                nullable = record.DateAndTimes[index1].TimeIn;
                                str1 = nullable.Value.ToString("HH:mm");
                            }
                            else
                                str1 = "-";
                            Row newRow1 = row;
                            XlsxRw.AddStringCell(str1, newRow1);
                            nullable = record.DateAndTimes[index1].TimeOut;
                            string str2;
                            if (nullable.HasValue)
                            {
                                nullable = record.DateAndTimes[index1].TimeOut;
                                str2 = nullable.Value.ToString("HH:mm");
                            }
                            else
                                str2 = "-";
                            Row newRow2 = row;
                            XlsxRw.AddStringCell(str2, newRow2);
                            ++index1;
                        }
                        else if (index2 != record.DateAndTimes.Count - 1)
                        {
                            XlsxRw.AddStringCell("-", row);
                            XlsxRw.AddStringCell("-", row);
                        }
                    }
                    XlsxRw.AddNumberCell(record.NormalTime, row);
                    XlsxRw.AddNumberCell(record.Time15, row);
                    XlsxRw.AddNumberCell(record.DoubleTime, row);
                    XlsxRw.AddNumberCell(record.SundayTime, row);
                    XlsxRw.AddNumberCell(record.LostTime, row);
                    XlsxRw.AddNumberCell(record.TotalShift, row);
                    firstChild.AppendChild<Row>(row);
                }
            }
            return memoryStream;
        }

        private static void AddStringCell(string value, Row newRow)
        {
            Cell cell = new Cell();
            EnumValue<CellValues> enumValue = (EnumValue<CellValues>)CellValues.String;
            cell.DataType = enumValue;
            CellValue cellValue = new CellValue(value);
            cell.CellValue = cellValue;
            Cell newChild = cell;
            newRow.AppendChild<Cell>(newChild);
        }

        private static void AddNumberCell(double value, Row newRow)
        {
            Cell cell = new Cell();
            EnumValue<CellValues> enumValue = (EnumValue<CellValues>)CellValues.Number;
            cell.DataType = enumValue;
            CellValue cellValue = new CellValue(value.ToString((IFormatProvider)CultureInfo.CurrentCulture));
            cell.CellValue = cellValue;
            Cell newChild = cell;
            newRow.AppendChild<Cell>(newChild);
        }
    }
}

using System.Collections.Generic;

namespace TM_Impronet_Interface.Classes
{
    public class EbExcelExport
    {
        public string EmployeeNo { get; set; }

        public string Employee { get; set; }

        public string Department { get; set; }

        public string Roster { get; set; }

        public List<DateInOut> DateAndTimes { get; set; }

        public double NormalTime { get; set; }

        public double Time15 { get; set; }

        public double DoubleTime { get; set; }

        public double SundayTime { get; set; }

        public double LostTime { get; set; }

        public double TotalShift { get; set; }
    }
}

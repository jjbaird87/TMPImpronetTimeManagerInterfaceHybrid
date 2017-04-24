using System;

namespace TM_Impronet_Interface.Classes
{
    public class ProgressEventArgs : EventArgs
    {
        public int Progress { get; set; }
        public int TotalRecords { get; set; }
        public string Status { get; set; }
    }
}

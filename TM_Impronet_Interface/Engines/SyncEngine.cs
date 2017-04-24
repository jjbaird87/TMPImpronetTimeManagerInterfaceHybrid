using System;
using System.ComponentModel;
using TM_Impronet_Interface.Export_Classes;

namespace TM_Impronet_Interface.Engines
{
    public class SyncEngine : Engine
    {
        public sealed override BackgroundWorker BackgroundWorker { get; set; }        

        public SyncEngine(TimeSpan timeSpan) : base(timeSpan)
        {
            BackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            ReadAuthorization = true;
            Authorized = true;

            SyncImpro.OnProgressHandler += (sender, args) =>
            {
                BackgroundWorker.ReportProgress(0, args);
            };
            BackgroundWorker.DoWork += (sender, args) =>
            {
                SyncImpro.StartSync();
            };            
        }        
    }
}

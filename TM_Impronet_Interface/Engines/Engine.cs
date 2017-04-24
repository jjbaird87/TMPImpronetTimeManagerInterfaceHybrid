using System;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace TM_Impronet_Interface.Engines
{
    public abstract class Engine
    {        
        public event EventHandler OnSecondsHandler;
        public class EngineProgressEventArgs : EventArgs
        {
            public int BaseSeconds { get; set; }
            public int CurrentSeconds { get; set; }   
            public string Status { get; set; }
        }

        public void OnSecondsChange(int baseSeconds, int currentSeconds, string status = "")
        {
            try
            {
                var onSecondsHandler = OnSecondsHandler;
                if (onSecondsHandler == null)
                    return;
                var progressEventArgs =
                    new EngineProgressEventArgs {BaseSeconds = baseSeconds, CurrentSeconds = currentSeconds, Status =  status};
                
                onSecondsHandler(null, progressEventArgs);
            }
            catch 
            {
                //Do nothing
            }
        }

        public abstract BackgroundWorker BackgroundWorker { get; set; }
        public bool ReadAuthorization { get; set; }
        public bool Authorized { get; set; }
        private readonly Timer _timer = new Timer();
        private int _remainingSeconds;
        private int _baseSeconds;

        protected Engine(TimeSpan timeSpan)
        {
            _remainingSeconds = -1;
            _baseSeconds = Convert.ToInt32(timeSpan.TotalSeconds);

            //Timer Settings
            _timer.Interval = 1000;
            _timer.AutoReset = true;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_remainingSeconds == 0)
            {                
                _timer.Stop();
                if (ReadAuthorization && !Authorized)
                {
                    OnSecondsChange(0, 0, "Waiting for an operation to complete");
                    while (!Authorized)
                    {
                        Thread.Sleep(50);
                    }
                }
                OnSecondsChange(0, 0, "Running");
                BackgroundWorker.RunWorkerAsync();
                //Wait for background worker to finish
                while (BackgroundWorker.IsBusy)
                {
                    Thread.Sleep(50);
                }
                _remainingSeconds = _baseSeconds;
                _timer.Start();
            }
            else if (_remainingSeconds < 0)
                _remainingSeconds = _baseSeconds;
            else
                _remainingSeconds--;
            
            OnSecondsChange(_baseSeconds, _remainingSeconds);
        }

        public void StartEngine()
        {
            _timer.Start();
        }

        public void StopEngine()
        {
            _timer.Stop();
        }

        public void ChangeInterval(TimeSpan timeSpan)
        {
            _remainingSeconds = -1;
            _baseSeconds = Convert.ToInt32(timeSpan.TotalSeconds);
        }
    }
}

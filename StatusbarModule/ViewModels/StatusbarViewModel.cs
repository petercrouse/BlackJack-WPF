using Game.Framework.Logging;
using Prism.Events;
using Prism.Regions;
using Shared.Events;
using Shared.ViewModels;
using System;

namespace StatusbarModule.ViewModels
{
    public class StatusbarViewModel : GameViewModel
    {

        public StatusbarViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(regionManager, eventAggregator, logger)
        {
            EventAggregator.GetEvent<GameMessageEvent>().Subscribe(GameMessage);

            System.Timers.Timer clockTimer = new System.Timers.Timer(1000);
            clockTimer.Interval = 1000;
            clockTimer.Elapsed += ClockTimer_Elapsed;
            clockTimer.Start();
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                SetProperty( ref _time, value);                
            }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        private void ClockTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void GameMessage(string message)
        {
            Message = message;
        }
    }
}

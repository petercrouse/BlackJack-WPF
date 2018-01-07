using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Shared.Events;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatusbarModule.ViewModels
{
    public class StatusbarViewModel : GameViewModel
    {

        public StatusbarViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
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

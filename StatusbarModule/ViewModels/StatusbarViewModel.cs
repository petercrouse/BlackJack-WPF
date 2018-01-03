using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusbarModule.ViewModels
{
    public class StatusbarViewModel : GameViewModel
    {

        public StatusbarViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {

        }
    }
}

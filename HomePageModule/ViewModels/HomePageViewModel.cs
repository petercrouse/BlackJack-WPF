using Game.Core.System;
using Game.Framework.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Shared;
using Shared.ViewModels;

namespace HomePageModule.ViewModels
{
    public class HomePageViewModel : GameViewModel
    {
        public DelegateCommand NavigateToPlayBlackjackCommand { get; set; }

        public HomePageViewModel(ISystemService systemService, IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(systemService, regionManager, eventAggregator, logger)
        {
            NavigateToPlayBlackjackCommand = new DelegateCommand(NavigateToPlayBlackjack);
            
        }

        private void NavigateToPlayBlackjack()
        {
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.PlayBlackjack);
        }
    }
}

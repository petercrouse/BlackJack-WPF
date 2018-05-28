using Game.Core.System;
using Game.Framework.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Shared;
using Shared.ViewModels;
using System.Windows;

namespace ToolbarModule.ViewModels
{
    public class ToolBarViewModel : GameViewModel
    {
        public DelegateCommand NavigateToPlayBlackjackCommand { get; set; }
        public DelegateCommand NavigateToHomePageCommand { get; set; }
        public DelegateCommand ExitApplicationCommand { get; set; }

        public ToolBarViewModel(ISystemService systemService, IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(systemService, regionManager, eventAggregator, logger)
        {
            NavigateToPlayBlackjackCommand = new DelegateCommand(PlayBlackjackGame);
            NavigateToHomePageCommand = new DelegateCommand(NavigateToHomePage);
            ExitApplicationCommand = new DelegateCommand(ExitApplication);
        }

        private void PlayBlackjackGame()
        {
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.PlayBlackjack);
        }

        private void NavigateToHomePage()
        {
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.HomePage);
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}

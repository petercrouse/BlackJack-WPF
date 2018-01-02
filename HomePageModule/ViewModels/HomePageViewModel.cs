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

        public HomePageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator): base(regionManager, eventAggregator)
        {
            NavigateToPlayBlackjackCommand = new DelegateCommand(NavigateToPlayBlackjack);
        }

        private void NavigateToPlayBlackjack()
        {
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.PlayBlackjack);
        }
    }
}

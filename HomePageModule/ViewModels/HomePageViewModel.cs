using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Shared;
using Shared.ViewModels;

namespace HomePageModule.ViewModels
{
    public class HomePageViewModel : GameViewModel
    {
        public DelegateCommand PlayBlackjackGameCommand { get; set; }

        public HomePageViewModel(IRegionManager regionManager, IEventAggregator eventAggregator): base(regionManager, eventAggregator)
        {
            PlayBlackjackGameCommand = new DelegateCommand(PlayBlackjackGame);
        }

        private void PlayBlackjackGame()
        {
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.PlayBlackjack);
        }
    }
}

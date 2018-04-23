using Game.Framework.Logging;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Shared.ViewModels
{
    public class GameViewModel : BindableBase, INavigationAware
    {
        protected IRegionManager RegionManager;
        protected IEventAggregator EventAggregator;
        protected ILogger Logger;

        public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
            Logger = logger;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}

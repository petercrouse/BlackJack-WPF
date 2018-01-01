using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Shared.ViewModels
{
    public class GameViewModel : BindableBase, INavigationAware
    {
        protected IRegionManager RegionManager;
        protected IEventAggregator EventAggregator;

        public GameViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
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

using Game.Core.Response;
using Game.Framework.Logging;
using Game.Framework.Utilities;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows;

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

        async protected void PerformServiceCall<TReturn>(Func<ServiceResponse<TReturn>> action, Action<ServiceResponse<TReturn>> callback)
        {
            Guard.ArgumentNotNull(action, "action");
            Guard.ArgumentNotNull(callback, "callback");

            ServiceResponse<TReturn> response = new ServiceResponse<TReturn>();
            var task = Task.Run(action);

            response = await task;

            callback(response);
        }
    }
}

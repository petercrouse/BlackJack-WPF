using Game.Core.Response;
using Game.Core.System;
using Game.Framework.Logging;
using Game.Framework.Utilities;
using Game.Models.Dto;
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
        protected ISystemService SystemService;
        protected IRegionManager RegionManager;
        protected IEventAggregator EventAggregator;
        protected ILogger Logger;


        public GameViewModel(ISystemService systemService, IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger)
        {
            SystemService = systemService;
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

            var response = await Task.Run(action);

            callback(response);
        }

        public static class State
        {
            public static string LoggedInUser { get; set; }
        }

        public static class StateBag
        {
            public static GameUserDto LoggedInUser { get; set; }
        }
    }
}

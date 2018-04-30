using Game.Core.Response;
using Game.Framework.Logging;
using Game.Framework.Utilities;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Runtime.Remoting.Messaging;
using System.Windows;

namespace Shared.ViewModels
{
    public class GameViewModel : BindableBase, INavigationAware
    {
        protected IRegionManager RegionManager;
        protected IEventAggregator EventAggregator;
        protected ILogger Logger;

        protected delegate void AsyncMethodCaller<TReturn>(Func<ServiceResponse<TReturn>> action, out ServiceResponse<TReturn> response);

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

        protected void PerformServiceCall<TReturn>(Func<ServiceResponse<TReturn>> action, Action<ServiceResponse<TReturn>> callback)
        {
            Guard.ArgumentNotNull(action, "action");
            Guard.ArgumentNotNull(callback, "callback");

            var caller = new AsyncMethodCaller<TReturn>(DoWork);
            ServiceResponse<TReturn> response = new ServiceResponse<TReturn>();

            IAsyncResult result = caller.BeginInvoke(action, out response, new AsyncCallback(EndCall<TReturn>), callback);
        }

        private void DoWork<TReturn>(Func<ServiceResponse<TReturn>> action, out ServiceResponse<TReturn> response)
        {
            response = action.Invoke();
        }

        private void EndCall<TReturn>(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            AsyncMethodCaller<TReturn> caller = (AsyncMethodCaller<TReturn>)result.AsyncDelegate;
            Action<ServiceResponse<TReturn>> callback = (Action<ServiceResponse<TReturn>>)ar.AsyncState;
            ServiceResponse<TReturn> response = new ServiceResponse<TReturn>();

            caller.EndInvoke(out response, result);

            if (Application.Current != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    callback.Invoke(response);
                });
            }            
        }
    }
}

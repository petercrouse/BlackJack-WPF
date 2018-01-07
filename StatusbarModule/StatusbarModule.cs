using StatusbarModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shared;

namespace StatusbarModule
{
    public class StatusbarModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public StatusbarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<Statusbar>();
            _regionManager.RegisterViewWithRegion(Constants.Regions.StatusbarRegion, typeof(Statusbar));
        }
    }
}
using HomePageModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shared;

namespace HomePageModule
{
    public class HomePageModuleModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public HomePageModuleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<HomePage>();
            _regionManager.RegisterViewWithRegion(Constants.Regions.MainRegion, typeof(HomePage));
        }
    }
}
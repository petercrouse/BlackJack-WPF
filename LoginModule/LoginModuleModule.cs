using LoginModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shared;

namespace LoginModule
{
    public class LoginModuleModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public LoginModuleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<Login>();
            _regionManager.RegisterViewWithRegion(Constants.Regions.MainRegion,typeof(Login));
        }
    }
}
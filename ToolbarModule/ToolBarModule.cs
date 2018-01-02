using ToolbarModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shared;

namespace ToolbarModule
{
    public class ToolBarModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ToolBar>();
            _regionManager.RegisterViewWithRegion(Constants.Regions.ToolbarRegion, typeof(ToolBar));
        }
    }
}
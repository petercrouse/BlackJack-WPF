using PlayBlackjackModule.Views;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shared;

namespace PlayBlackjackModule
{
    public class PlayBlackjackModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public PlayBlackjackModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<PlayBlackjack>();
            _regionManager.RegisterViewWithRegion(Constants.Regions.MainRegion, typeof(PlayBlackjack));
        }
    }
}
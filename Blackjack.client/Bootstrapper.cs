using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using PlayBlackjackModule.Views;
using Shared;
using System.Windows.Controls;
using HomePageModule.Views;
using StatusbarModule.Views;
using Game.Client.Views;
using Game.Core.Entities;
using Game.Persistence;
using Game.Persistence.Repositories;
using System.Data.Entity.Infrastructure;

namespace Game.Client
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(HomePageModule.HomePageModuleModule));
            moduleCatalog.AddModule(typeof(ToolbarModule.ToolBarModule));
            moduleCatalog.AddModule(typeof(StatusbarModule.StatusbarModule));
            moduleCatalog.AddModule(typeof(PlayBlackjackModule.PlayBlackjackModule));
            
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IDbContextFactory<GameContext>, ContextFactory>();
            Container.RegisterType<IRepository<GameUser>, GameUserRepository>();
            Container.RegisterType<IRepository<Scoreboard>, ScoreboardRepository>();

            Container.RegisterType(typeof(object), typeof(PlayBlackjack), Constants.Views.PlayBlackjack);
            Container.RegisterType(typeof(object), typeof(HomePage), Constants.Views.HomePage);
            Container.RegisterType(typeof(object), typeof(ToolBar), Constants.Views.ToolBar);
            Container.RegisterType(typeof(object), typeof(Statusbar), Constants.Views.Statusbar);
        }

    }
}

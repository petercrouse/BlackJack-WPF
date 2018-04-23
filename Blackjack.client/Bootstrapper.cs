using Game.Client.Views;
using Game.Framework.Logging;
using Game.Models.Entities;
using Game.Persistence;
using Game.Persistence.Repositories;
using HomePageModule.Views;
using Microsoft.Practices.Unity;
using PlayBlackjackModule.Views;
using Prism.Modularity;
using Prism.Unity;
using Shared;
using StatusbarModule.Views;
using System.Data.Entity.Infrastructure;
using System.Windows;
using System.Windows.Controls;

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
            Container.RegisterType<ILogger, Logger>();

            Container.RegisterType(typeof(object), typeof(PlayBlackjack), Constants.Views.PlayBlackjack);
            Container.RegisterType(typeof(object), typeof(HomePage), Constants.Views.HomePage);
            Container.RegisterType(typeof(object), typeof(ToolBar), Constants.Views.ToolBar);
            Container.RegisterType(typeof(object), typeof(Statusbar), Constants.Views.Statusbar);
        }

    }
}

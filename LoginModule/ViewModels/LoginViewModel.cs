using Game.Framework.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule.ViewModels
{
    public class LoginViewModel : GameViewModel
    {
        public LoginViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(regionManager, eventAggregator, logger)
        {
            SignInCommand = new DelegateCommand(SignIn);
        }

        string _username;
        string _password;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand SignInCommand { get; }

        private void SignIn()
        {
            throw new NotImplementedException();
        }
    }
}
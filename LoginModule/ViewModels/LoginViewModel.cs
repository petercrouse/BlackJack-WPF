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
using System.Configuration;
using Auth0.OidcClient;
using IdentityModel.OidcClient;
using System.Diagnostics;
using Game.Core.System;
using Game.Core.Requests.GameUserRequests;
using Game.Core.Response;
using Game.Models.Dto;

namespace LoginModule.ViewModels
{
    public class LoginViewModel : GameViewModel
    {
        public LoginViewModel(ISystemService systemService, IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(systemService, regionManager, eventAggregator, logger)
        {
            SignInCommand = new DelegateCommand<string>(SignIn);
        }

        private string _username;
        private string _password;

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

        public DelegateCommand<string> SignInCommand { get; }

        async private void SignIn(string connection)
        {
            string domain = ConfigurationManager.AppSettings["Auth0:Domain"];
            string clientId = ConfigurationManager.AppSettings["Auth0:ClientId"];

            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = domain,
                ClientId = clientId
            });

            var extraParameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(connection))
                extraParameters.Add("connection", connection);

            LoginResult loginResult = await client.LoginAsync();

            if (!loginResult.IsError)
            {
                var userDetails = new Dictionary<string, string>();
                foreach (var claim in loginResult.User.Claims)
                {
                    if (claim.Type != "updated_at")
                    {
                        userDetails.Add(claim.Type, claim.Value);
                    }
                }
                PerformServiceCall(() => SystemService.GameUserService.CreateUser(CreateUserRequest.Create(userDetails)), SignInComplete);
            }            
            
        }

        private void SignInComplete(ServiceResponse<GameUserDto> user)
        {
            Username = user.Response.Alias;
            Password = user.Response.email;
        }
    }
}


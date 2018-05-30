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
using Shared;
using Shared.Events;

namespace LoginModule.ViewModels
{
    public class LoginViewModel : GameViewModel
    {
        public LoginViewModel(ISystemService systemService, IRegionManager regionManager, IEventAggregator eventAggregator, ILogger logger) : base(systemService, regionManager, eventAggregator, logger)
        {
            SignInCommand = new DelegateCommand<string>(SignIn);
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
                userDetails.Add(loginResult.User.Claims.Last().Type, loginResult.User.Claims.Last().Value);
                PerformServiceCall(() => SystemService.GameUserService.CreateUser(CreateUserRequest.Create(userDetails)), SignInComplete);
            }            
            
        }

        private void SignInComplete(ServiceResponse<GameUserDto> result)
        {
            if (result.Notifications.HasErrors())
            {
                var error = result.Notifications.Errors().FirstOrDefault().Text;
                var errorCode = result.Notifications.Errors().FirstOrDefault().Code;
                EventAggregator.GetEvent<GameMessageEvent>().Publish($"[{errorCode}] {error}");
            }
            StateBag.LoggedInUser = result.Response;
            RegionManager.RequestNavigate(Constants.Regions.MainRegion, Constants.Views.HomePage);
        }
    }
}


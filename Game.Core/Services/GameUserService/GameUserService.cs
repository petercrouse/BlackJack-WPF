﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Core.Requests.GameUserRequests;
using Game.Core.Response;
using Game.Framework.Logging;
using Game.Models.Dto;
using Game.Models.Entities;
using Game.Persistence;

namespace Game.Core.Services.GameUserService
{
    public class GameUserService : ServiceManager, IGameUserService
    {
        public GameUserService(IRepository<GameUser> userRepository, ILogger logger) : base(logger)
        {
            _userRepository = userRepository;
        }

        private IRepository<GameUser> _userRepository;

        public ServiceResponse<GameUserDto> CreateUser(CreateUserRequest request)
        {
            return Execute<ServiceResponse<GameUserDto>>(request, (result) =>
            {
                string name = request.UserInfo["name"];
                var user = _userRepository.FindBy(x => x.Alias == name).FirstOrDefault();
                if (user == null)
                {
                    GameUser newUser = new GameUser()
                    {
                        Alias = request.UserInfo["name"],
                        Email = null
                    };
                    _userRepository.Add(newUser);
                    _userRepository.Save();

                    result.Response = AsDto(newUser);
                }
                else
                {
                    result.Response = AsDto(user);
                }                
            });
        }

        #region helper methods

        private GameUserDto AsDto(GameUser user)
        {
            return new GameUserDto()
            {
                Alias = user.Alias,
                email = user.Email
            };
        }

        #endregion
    }
}

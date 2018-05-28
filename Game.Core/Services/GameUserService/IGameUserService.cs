using Game.Core.Requests.GameUserRequests;
using Game.Core.Response;
using Game.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Services.GameUserService
{
    public interface IGameUserService
    {
        ServiceResponse<GameUserDto> CreateUser(CreateUserRequest createUserRequest);
    }
}

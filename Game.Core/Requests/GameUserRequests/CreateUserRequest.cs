using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Requests.GameUserRequests
{
    public class CreateUserRequest: ValidateableRequest
    {
        public Dictionary<string, string> UserInfo { get; set; }

        public static CreateUserRequest Create(Dictionary<string, string> userInfo)
        {
            return new CreateUserRequest
            {
                UserInfo = userInfo
            };
        }
    }
}

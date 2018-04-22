using Game.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Requests
{
    public abstract class ValidateableRequest : IValidateableRequest
    {
        public virtual NotificationCollection Validate()
        {
            return NotificationCollection.CreateEmpty();
        }
    }
}

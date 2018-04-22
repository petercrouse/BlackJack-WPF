using Game.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Response
{
    public class ServiceResponse<T> : INotificationResponse
    {
        public ServiceResponse()
        {
            Notifications = NotificationCollection.CreateEmpty();
        }

        public NotificationCollection Notifications { get; set; }
        public T Response { get; set; }
    }
}

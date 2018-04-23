using Game.Framework.Notifications;

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

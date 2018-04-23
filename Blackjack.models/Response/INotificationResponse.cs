using Game.Framework.Notifications;

namespace Game.Core.Response
{
    public interface INotificationResponse
    {
        NotificationCollection Notifications { get; set; }
    }
}
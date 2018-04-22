using Game.Framework.Notifications;

namespace Game.Core.Requests
{
    public interface IValidateableRequest
    {
        NotificationCollection Validate();
    }
}

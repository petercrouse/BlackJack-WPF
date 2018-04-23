using Game.Framework.Notifications;

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

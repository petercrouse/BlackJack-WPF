using Game.Framework.Notifications;
using System;

namespace Game.Framework.Extensions
{
    public static class NotificationCollectionExtensions
    {
        public static NotificationCollection AddError(this NotificationCollection instance, string error)
        {
            return instance.AddError(error, string.Empty);
        }

        public static NotificationCollection AddError(this NotificationCollection instance, string error, string errorCode)
        {
            var notification = new Notification(error, NotificationSeverity.Error);

            if (!string.IsNullOrEmpty(errorCode))
            {
                notification.Code = errorCode;
            }

            instance.AddMessage(notification);

            return instance;
        }

        public static NotificationCollection AddException(this NotificationCollection instance, Exception exception)
        {
            return instance.AddError(exception.Message);
        }
    }
}

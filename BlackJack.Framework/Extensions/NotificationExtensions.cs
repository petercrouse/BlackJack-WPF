using Game.Framework.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Extensions
{
    public static class NotificationExtensions
    {
        public static bool HasErrors(this IEnumerable<Notification> notifications)
        {
            return notifications.Any(m => m.Severity == NotificationSeverity.Error);
        }

        public static bool HasMessages(this IEnumerable<Notification> notifications)
        {
            return notifications.Any();
        }

        public static bool HasWarnings(this IEnumerable<Notification> notifications)
        {
            return notifications.Any(m => m.Severity == NotificationSeverity.Warning);
        }
    }
}

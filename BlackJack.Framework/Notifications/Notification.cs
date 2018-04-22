using System.Globalization;

namespace Game.Framework.Notifications
{
    public class Notification
    {
        public Notification(string text)
        {
            Text = text;
            Severity = NotificationSeverity.Information;
        }

        public Notification(string text, NotificationSeverity severity)
        {
            Text = text;
            Severity = severity;
        }

        public Notification(string text, NotificationSeverity severity, object tag)
        {
            Text = text;
            Severity = severity;
            Tag = tag;
        }

        public string Code { get; set; }
        public string Grouping { get; set; }
        public string Hint { get; set; }
        public NotificationSeverity Severity { get; set; }

        public object Tag { get; set; }
        public string Text { get; set; }


        public static Notification Create(string message, NotificationSeverity notificationSeverity)
        {
            return new Notification(message, notificationSeverity);
        }

        public static Notification Create(string code, string message, NotificationSeverity notificationSeverity)
        {
            return new Notification(message, notificationSeverity) { Code = code };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} : {1}", Severity, Text);
        }

    }
}

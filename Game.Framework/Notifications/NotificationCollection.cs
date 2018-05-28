using Game.Framework.Extensions;
using Game.Framework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Game.Framework.Notifications
{
    public sealed class NotificationCollection : IFormattable, IEnumerable<Notification>
    {
        #region Private Fields

        private readonly List<Notification> _messages = new List<Notification>();

        #endregion Private Fields

        #region Public Methods

        public static NotificationCollection Add(NotificationCollection left, NotificationCollection right)
        {
            return left + right;
        }

        public static NotificationCollection Create(Notification notification)
        {
            NotificationCollection notificationCollection = CreateEmpty();
            notificationCollection.AddMessage(notification);
            return notificationCollection;
        }

        public static NotificationCollection Create(IList<Notification> notifications)
        {
            NotificationCollection notificationCollection = CreateEmpty();
            notificationCollection.AddMessage(notifications);
            return notificationCollection;
        }

        public static NotificationCollection CreateEmpty()
        {
            return new NotificationCollection();
        }

        public static implicit operator string(NotificationCollection notification)
        {
            return notification.ToString();
        }

        public static NotificationCollection operator +(NotificationCollection left, NotificationCollection right)
        {
            Guard.ArgumentNotNull(left, "left");

            if (right != null)
            {
                left.AddMessage(right);
            }
            return left;
        }

        public static NotificationCollection operator +(NotificationCollection left, Notification right)
        {
            Guard.ArgumentNotNull(left, "left");

            if (right != null)
            {
                left.AddMessage(right);
            }
            return left;
        }

        public void AddMessage(Notification notification)
        {
            if (notification != null)
            {
                _messages.Add(notification);
            }
        }

        public void AddMessage(Notification notification, int index)
        {
            if (notification != null)
            {
                _messages.Insert(index, notification);
            }
        }

        public void AddMessage(IEnumerable<Notification> notifications)
        {
            if (notifications != null)
            {
                _messages.AddRange(notifications);
            }
        }

        public NotificationCollection Errors()
        {
            var errors = _messages.Where(m => m.Severity == NotificationSeverity.Error).ToList();

            NotificationCollection errorCollection = Create(errors);

            return errorCollection;
        }

        IEnumerator<Notification> IEnumerable<Notification>.GetEnumerator()
        {
            for (int i = 0; i < _messages.Count; i++)
            {
                yield return _messages[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Notification>)this).GetEnumerator();
        }

        public bool HasErrors()
        {
            return _messages.HasErrors();
        }

        public bool HasMessages()
        {
            return _messages.HasMessages();
        }

        public bool HasWarnings()
        {
            return _messages.HasWarnings();
        }

        public string ToConcatenatedString()
        {
            return string.Join(" || ", this.ToList().Select(x => x.Text));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();
            foreach (Notification message in _messages)
            {
                builder.Append(string.Format(CultureInfo.InvariantCulture, "{0}{1}", builder.Length > 0 ? Environment.NewLine : null, message));
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        #endregion Public Methods
    }
}

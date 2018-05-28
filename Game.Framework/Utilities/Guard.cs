using System;

namespace Game.Framework.Utilities
{
    public static class Guard
    {
        /// <summary>
        /// Validates that the <paramref name="argument"/> is not null.
        /// </summary>
        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Validates that the <paramref name="value"/> is not null.
        /// </summary>
        public static void InstanceNotNull(object value, string instanceName)
        {
            if (value == null)
            {
                throw new NullReferenceException("Instance expected but not supplied. " + instanceName);
            }
        }
    }
}

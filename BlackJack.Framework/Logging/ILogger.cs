using System;

namespace Game.Framework.Logging
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }

        void Debug(string data);
        void Info(string data);
        void Error(string data, Exception exception);
        void Warning(string data);
    }
}

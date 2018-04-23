using log4net;
using System;

namespace Game.Framework.Logging
{
    public class Logger : ILogger
    {
        public Logger()
        {
            _log = LogManager.GetLogger("Game.Logger");
        }

        private ILog _log;

        public bool IsDebugEnabled
        {
            get
            {
                return _log.IsDebugEnabled;
            }
        }
        public bool IsErrorEnabled
        {
            get
            {
                return _log.IsErrorEnabled;
            }
        }
        public bool IsFatalEnabled
        {
            get
            {
                return _log.IsFatalEnabled;
            }
        }
        public bool IsInfoEnabled
        {
            get
            {
                return _log.IsInfoEnabled;
            }
        }
        public bool IsWarnEnabled
        {
            get
            {
                return _log.IsWarnEnabled;
            }
        }

        public void Debug(string data)
        {
            if (data != null && IsDebugEnabled)
            {
                _log.Debug(data);
            }
        }

        public void Info(string data)
        {
            if (data != null && IsInfoEnabled)
            {
                _log.Info(data);
            }
        }

        public void Error(string data, Exception exception)
        {
            if (data != null && IsErrorEnabled)
            {
                if (exception != null)
                {
                    _log.Error($" [Exception]: {exception.ToString()} [Message]: {data}");
                }
            }
        }

        public void Warning(string data)
        {
            throw new NotImplementedException();
        }
    }
}

using log4net;
using log4net.Config;
using System;

namespace Game.Framework.Logging
{
    public class Logger : ILogger
    {
        public Logger()
        {
            XmlConfigurator.Configure();
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
            if (IsDebugEnabled)
            {
                _log.Debug(data);
            }
        }

        public void Info(string data)
        {
            if (IsInfoEnabled)
            {
                _log.Info(data);
            }
        }

        public void Error(string data, Exception exception = null)
        {
            if (IsErrorEnabled)
            {
                if (exception != null)
                {
                    _log.Error($" [Exception]: {exception} [Exception Message]: {exception.Message} [Message]: {data}");
                }
                else
                {
                    _log.Error(data);
                }
            }
        }

        public void Warning(string data)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(data);
            }
        }
    }
}

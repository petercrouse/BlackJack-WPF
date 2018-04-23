using Game.Core.Requests;
using Game.Core.Response;
using Game.Framework.Extensions;
using Game.Framework.Logging;
using System;
using System.Diagnostics;

namespace Game.Core.Services
{
    public class ServiceManager
    {
        public ServiceManager(ILogger logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; set; }

        protected TReturn Execute<TReturn>(IValidateableRequest request, Action<TReturn> action)
            where TReturn : INotificationResponse, new()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = new TReturn();

            try
            {
                if (request != null)
                {
                    response.Notifications += request.Validate();

                    if (response.Notifications.HasErrors())
                    {
                        return response;
                    }
                }
                action.Invoke(response);
            }
            catch(Exception ex)
            {
                Logger.Error($"[Class]: { GetType() } [Method]: { (new StackTrace()).GetFrame(1).GetMethod().Name }. ", ex);
                response.Notifications.AddError($"An unexpected error occured: { ex.Message }.");
            }
            finally
            {
                stopwatch.Stop();
                Logger.Info($"[Class]: { GetType() }. [Method]: { (new StackTrace()).GetFrame(1).GetMethod().Name }. [CompletionTime]: {stopwatch.ElapsedMilliseconds}ms ");                             
            }
            return response;
        }
    }
}

using Game.Core.Requests;
using Game.Core.Response;
using Game.Framework.Extensions;
using System;
using System.Diagnostics;

namespace Game.Core.Services
{
    public class ServiceManager
    {
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
            catch(Exception e)
            {
                response.Notifications.AddError($"An unexpected error occured: { e.ToString() }");
            }
            finally
            {
                stopwatch.Stop();               
            }
            return response;
        }
    }
}

using System;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Net.Http;

namespace Extensibility.Host
{
    public class LoggerTracingInterceptor : IServiceClientTracingInterceptor
    {
        private readonly ILogger log;

        public LoggerTracingInterceptor(ILogger log)
        {
            this.log = log;
        }

        public void Configuration(string source, string name, string value)
            => log.LogDebug($"{nameof(Configuration)}: name='{name}', value='{value}'");

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
            => log.LogDebug($"{nameof(EnterMethod)}: invocationId='{invocationId}', instance='{instance}', method='{method}', parameters='{parameters}'");

        public void ExitMethod(string invocationId, object returnValue)
            => log.LogDebug($"{nameof(ExitMethod)}: invocationId='{invocationId}', returnValue='{returnValue}'");

        public void Information(string message)
            => log.LogDebug($"{nameof(Information)}: message='{message}'");
 
        public void ReceiveResponse(string invocationId, HttpResponseMessage response)
            => log.LogDebug($"{nameof(ReceiveResponse)}: invocationId='{invocationId}', response='{response}'");

        public void SendRequest(string invocationId, HttpRequestMessage request)
            => log.LogDebug($"{nameof(SendRequest)}: invocationId='{invocationId}', request='{request}'");

        public void TraceError(string invocationId, Exception exception)
            => log.LogDebug($"{nameof(TraceError)}: invocationId='{invocationId}', exception='{exception}'");
    }
}

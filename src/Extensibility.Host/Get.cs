using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Extensibility.Core.Messages;
using Microsoft.Rest;

namespace Extensibility.Host
{
    public static class Get
    {
        [FunctionName("Get")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            ServiceClientTracing.IsEnabled = true;
            ServiceClientTracing.AddTracingInterceptor(new LoggerTracingInterceptor(log));

            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonConvert.DeserializeObject<GetRequest>(requestBody);

            var response = await Providers.TryGetProvider(request.Body!.Import!.Provider!)!.Get(request, cancellationToken);
            var responseBody = JsonConvert.SerializeObject(response);

            return new OkObjectResult(responseBody);
        }
    }
}

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Seneca.AzureFunctions.NET5.Sample
{
    public class HttpFunction
    {
        private readonly IService service;
        private readonly ILogger<HttpFunction> logger;

        public HttpFunction(IService service, ILogger<HttpFunction> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [Function("HttpFunction")]
        public static HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            ////<docsnippet_logging>
            //var logger = executionContext.GetLogger("HttpFunction");
            //logger.LogInformation("message logged");
            ////</docsnippet_logging>

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Date", DateTime.UtcNow.ToString());
            response.Headers.Add("Content", "Content - Type: text / html; charset = utf - 8");

            response.WriteString("Welcome to .NET 5!!");

            return response;
        }
    }
}

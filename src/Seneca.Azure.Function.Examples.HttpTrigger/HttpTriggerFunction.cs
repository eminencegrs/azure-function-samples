using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Seneca.Azure.Function.Examples.HttpTrigger
{
    public class HttpTriggerFunction
    {
        private readonly TelemetryClient telemetryClient;
        private readonly ILogger<HttpTriggerFunction> logger;

        public HttpTriggerFunction(
            TelemetryClient telemetryClient,
            ILogger<HttpTriggerFunction> logger)
        {
            this.logger = logger;
            this.telemetryClient = telemetryClient;
        }

        [FunctionName("GetAsync")]
        public async Task<IActionResult> GetAsync(
            [HttpTrigger(AuthorizationLevel.System, "get", Route = "some_resources/{id}")]HttpRequest req,
            string id,
            ExecutionContext context)
        {
            try
            {
                string methodName = nameof(HttpTriggerFunction.GetAsync);
                var telemetryProperties = new Dictionary<string, string>
                {
                    { "MethodName", methodName },
                };

                var message = $"'{methodName}' has started processing the request.";
                this.logger.LogInformation(message);
                this.telemetryClient.TrackTrace(
                    message,
                    Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information,
                    telemetryProperties);

                return (ActionResult)new OkObjectResult("The request has been successfully processed.");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError(ex.Message, ex);
                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return new BadRequestResult();
            }
        }

        [FunctionName("PostAsync")]
        public async Task<IActionResult> PostAsync(
            [HttpTrigger(AuthorizationLevel.System, "post", Route = "some_resources")] HttpRequest request,
            ExecutionContext context)
        {
            try
            {
                string methodName = nameof(HttpTriggerFunction.PostAsync);
                var telemetryProperties = new Dictionary<string, string>
                {
                    { "MethodName", methodName },
                };

                var message = $"'{methodName}' has started processing the request.";
                this.logger.LogInformation(message);
                this.telemetryClient.TrackTrace(
                    message,
                    Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information,
                    telemetryProperties);

                return (ActionResult)new OkObjectResult("The request has been successfully processed.");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError(ex.Message, ex);
                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return new BadRequestResult();
            }
        }

        [FunctionName("PutAsync")]
        public async Task<IActionResult> PutAsync(
            [HttpTrigger(AuthorizationLevel.System, "put", Route = "some_resources/{id}")] HttpRequest req,
            string id,
            ExecutionContext context)
        {
            try
            {
                string methodName = nameof(HttpTriggerFunction.PutAsync);
                var telemetryProperties = new Dictionary<string, string>
                {
                    { "MethodName", methodName },
                };

                var message = $"'{methodName}' has started processing the request.";
                this.logger.LogInformation(message);
                this.telemetryClient.TrackTrace(
                    message,
                    Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information,
                    telemetryProperties);

                return (ActionResult)new OkObjectResult("The request has been successfully processed.");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError(ex.Message, ex);
                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return new BadRequestResult();
            }
        }

        [FunctionName("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(
            [HttpTrigger(AuthorizationLevel.System, "delete", Route = "some_resources/{id}")] HttpRequest req,
            string id,
            ExecutionContext context)
        {
            try
            {
                string methodName = nameof(HttpTriggerFunction.DeleteAsync);
                var telemetryProperties = new Dictionary<string, string>
                {
                    { "MethodName", methodName },
                };

                var message = $"'{methodName}' has started processing the request.";
                this.logger.LogInformation(message);
                this.telemetryClient.TrackTrace(
                    message,
                    Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information,
                    telemetryProperties);

                return (ActionResult)new OkObjectResult("The request has been successfully processed.");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.LogError(ex.Message, ex);
                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return new BadRequestResult();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Seneca.Azure.Function.Examples
{
    public class EventHubTriggerFunction
    {
        private readonly ILogger<EventHubTriggerFunction> logger;

        public EventHubTriggerFunction(ILogger<EventHubTriggerFunction> logger)
        {
            this.logger = logger;
        }

        [FunctionName(nameof(EventHubTriggerFunction))]
        public async Task Run([EventHubTrigger("%EventHubName%", Connection = "EventHubConnection")] EventData[] events)
        {
            var exceptions = new List<Exception>();

            foreach (EventData eventData in events)
            {
                try
                {
                    this.logger.LogInformation("Function has started processing event.");

                    string messageBody = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);

                    this.logger.LogInformation("Function has finished processing event.");

                    await Task.Yield();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }
    }
}

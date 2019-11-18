using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Seneca.Azure.Function.Examples.TimeTrigger
{
    public class TimeTriggerFunction
    {
        private readonly ILogger<TimeTriggerFunction> logger;

        public TimeTriggerFunction(ILogger<TimeTriggerFunction> logger)
        {
            this.logger = logger;
        }

        [FunctionName("TimeTriggerFunction")]
        public async Task Run(
            [TimerTrigger("%TimeInterval%")]TimerInfo timerInfo,
            ExecutionContext context)
        {
            try
            {
                // Do some job.

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                // Handle some exceptional case.
            }
        }
    }
}
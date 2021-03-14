using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace Seneca.AzureFunctions.NET5.Sample
{
    public class SampleMiddleware : IFunctionsWorkerMiddleware
    {
        public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            context.Items.Add("Greeting", "Hello from our middleware");
            return next(context);
        }
    }
}

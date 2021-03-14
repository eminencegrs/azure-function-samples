using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Seneca.AzureFunctions.NET5.Sample
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Debugger.Launch();

            //var host = new HostBuilder()
            //    .ConfigureFunctionsWorkerDefaults()
            //    .ConfigureServices(s =>
            //    {
            //        s.AddSingleton<IService, Service>();
            //    })
            //    .Build();

            var host = new HostBuilder()
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddCommandLine(args);
                    configurationBuilder.AddEnvironmentVariables();
                })
                .ConfigureFunctionsWorkerDefaults(builder => builder.UseMiddleware<SampleMiddleware>())
                .ConfigureFunctionsWorker(
                    (c, b) =>
                    {
                        b.UseFunctionExecutionMiddleware();

                        c.HostingEnvironment.ApplicationName = "My Sample App";
                        c.HostingEnvironment.EnvironmentName = "DEV";
                    },
                    options => { }
                )
                .ConfigureServices(s =>
                {
                    s.AddHttpClient();
                    s.AddSingleton<IService, Service>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}

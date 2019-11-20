using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueExample.QueueService;

namespace QueueExample.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await CreateHostBuilder(args).Build().RunAsync();
            }
            catch (OperationCanceledException) { }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(service =>
                {
                    service.AddSingleton<IQueueHandler, QueueHandler>();
                    service.AddHostedService<QueueBackgroundService>();
                    service.AddHostedService<InputService>();
                });
    }
}

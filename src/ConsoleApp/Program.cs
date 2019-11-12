using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueExample.QueueService;
using QueueExample.QueueService.EventHandlers;
using QueueExample.QueueService.Items;

namespace QueueExample.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var task = host.RunAsync();
            var program = new Program(host.Services.GetRequiredService<IQueueHandler>());
            program.Run();
            await task;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(service =>
                {
                    service.AddSingleton<IQueueHandler, QueueHandler>();
                    service.AddHostedService<QueueBackgroundService>();
                });

        private readonly IQueueHandler _queue;
        
        public Program(IQueueHandler queue)
        {
            _queue = queue;
        }

        public void Run()
        {
            while(true)
            {
                var title = Console.ReadLine();
                var item = new DelayedQueueItem(new QueueItemEventHandler(), title, "", 5);
                _queue.Enqueue(item);
                Console.WriteLine($"Item {title} queued with Id: {item.Id}");
            }
        }
    }

    public class QueueItemEventHandler : IQueueItemEventHandler
    {
        public Task ItemIsCompleted(string id, string message)
        {
            Console.WriteLine($"item ({id}) is Completed.");
            return Task.CompletedTask;
        }

        public Task ItemIsRunning(string id)
        {
            Console.WriteLine($"item ({id}) is Running.");
            return Task.CompletedTask;
        }
    }
}

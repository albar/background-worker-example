using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using QueueExample.QueueService;
using QueueExample.QueueService.EventHandlers;
using QueueExample.QueueService.Items;

namespace QueueExample.ConsoleApp
{
    public class InputService : BackgroundService
    {
        private readonly IQueueHandler _queue;

        public InputService(IQueueHandler queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var title = await Task.Run(Console.ReadLine, token);
                var item = new DelayedQueueItem(new QueueItemEventHandler(), title, "", 5);
                _queue.Enqueue(item);
                Console.WriteLine($"Item {title} queued with Id: {item.Id}");
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
}

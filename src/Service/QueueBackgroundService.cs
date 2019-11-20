using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace QueueExample.QueueService
{
    public class QueueBackgroundService : BackgroundService
    {
        private readonly IQueueHandler _queue;

        public QueueBackgroundService(IQueueHandler queue)
        {
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var item = await _queue.DequeueAsync(token);
                await item.HandleAsync(token);
            }
        }
    }
}
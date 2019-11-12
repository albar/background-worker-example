using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using QueueExample.QueueService.Items;

namespace QueueExample.QueueService
{
    public class QueueHandler : IQueueHandler
    {
        private readonly ConcurrentQueue<IQueueItem> _queue = new ConcurrentQueue<IQueueItem>();
        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void Enqueue(IQueueItem item)
        {
            _queue.Enqueue(item);
            _signal.Release();
        }

        public async Task<IQueueItem> DequeueAsync(CancellationToken token)
        {
            await _signal.WaitAsync(token);
            _queue.TryDequeue(out var item);
            return item;
        }
    }
}
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using QueueExample.QueueService.Items;

namespace QueueExample.QueueService
{
    public class QueueHandler : IQueueHandler
    {
        private readonly ConcurrentQueue<IQueuedItem> _queue = new ConcurrentQueue<IQueuedItem>();
        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void Enqueue(IQueuedItem item)
        {
            _queue.Enqueue(item);
            _signal.Release();
        }

        public async Task<IQueuedItem> DequeueAsync(CancellationToken token)
        {
            await _signal.WaitAsync(token);
            _queue.TryDequeue(out var item);
            return item;
        }
    }
}
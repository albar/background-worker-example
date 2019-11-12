using System.Threading;
using System.Threading.Tasks;
using QueueExample.QueueService.Items;

namespace QueueExample.QueueService
{
    public interface IQueueHandler
    {
        void Enqueue(IQueueItem item);
        Task<IQueueItem> DequeueAsync(CancellationToken token);
    }
}
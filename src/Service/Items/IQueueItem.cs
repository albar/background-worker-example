using System.Threading;
using System.Threading.Tasks;

namespace QueueExample.QueueService.Items
{
    public interface IQueueItem
    {
        string Id { get; }
        Task HandleAsync(CancellationToken token);
    }
}
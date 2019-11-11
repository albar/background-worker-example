using System.Threading;
using System.Threading.Tasks;

namespace QueueExample.QueueService.Items
{
    public interface IQueuedItem
    {
        string Id { get; }
        Task DoSomethingAsync(CancellationToken token);
    }
}
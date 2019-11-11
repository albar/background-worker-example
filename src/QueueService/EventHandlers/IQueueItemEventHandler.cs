using System.Threading.Tasks;

namespace QueueExample.QueueService.EventHandlers
{
    public interface IQueueItemEventHandler
    {
        Task ItemIsRunning(string id);
        Task ItemIsCompleted(string id, string message);
    }
}
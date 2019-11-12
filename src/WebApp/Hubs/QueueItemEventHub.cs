using Microsoft.AspNetCore.SignalR;
using QueueExample.QueueService.EventHandlers;

namespace QueueExample.QueueService.Hubs
{
    public class QueueItemEventHub : Hub<IQueueItemEventHandler>
    {
    }
}
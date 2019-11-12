using Microsoft.AspNetCore.SignalR;
using QueueExample.QueueService.EventHandlers;

namespace QueueExample.WebApp.Hubs
{
    public class QueueItemEventHub : Hub<IQueueItemEventHandler>
    {
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QueueExample.QueueService;
using QueueExample.QueueService.EventHandlers;
using QueueExample.QueueService.Hubs;
using QueueExample.QueueService.Items;

namespace QueueExample.Controllers
{
    public class QueueController
    {
        private readonly IQueueHandler _queue;
        private readonly IHubContext<QueueItemEventHub, IQueueItemEventHandler> _hub;

        public QueueController(IQueueHandler queue,
            IHubContext<QueueItemEventHub, IQueueItemEventHandler> hub)
        {
            _queue = queue;
            _hub = hub;
        }

        [HttpPost("queue")]
        public object Queue([FromBody] RequestItem request)
        {
            var item = new DelayedQueueItem(_hub.Clients.All, request.Title, request.Message, request.Delay);
            _queue.Enqueue(item);
            return new { item.Id };
        }

        public class RequestItem
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public int Delay { get; set; }
        }
    }
}
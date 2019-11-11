using System;
using System.Threading;
using System.Threading.Tasks;
using QueueExample.QueueService.EventHandlers;

namespace QueueExample.QueueService.Items
{
    public class DelayedQueueItem : IQueuedItem
    {
        private readonly IQueueItemEventHandler _evt;
        private readonly string _title;
        private readonly string _message;
        private readonly int _delay;

        public DelayedQueueItem(IQueueItemEventHandler evt,
            string title, string message, int delay)
        {
            Id = Guid.NewGuid().ToString();
            _evt = evt;
            _title = title;
            _message = message;
            _delay = delay;
        }

        public string Id { get;}

        public async Task DoSomethingAsync(CancellationToken token)
        {
            // notify event handler that the item is running
            await _evt.ItemIsRunning(Id);

            // run specified delay
            await Task.Delay(TimeSpan.FromSeconds(_delay));

            // // notify event handler that the item is completed and send the message
            await _evt.ItemIsCompleted(Id, _message);
        }
    }
}
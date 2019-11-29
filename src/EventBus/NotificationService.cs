using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using QueueExample.EventBus.Abstractions;

namespace QueueExample.EventBus
{
    public class NotificationService : BackgroundService
    {
        private readonly IEventBus _bus;
        private readonly IServiceClient _client;

        public NotificationService(IEventBus bus, IServiceClient client)
        {
            _bus = bus;
            _client = client;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // get notifications
                var notifications = await _client.GetNotificationsAsync();

                // notify event bus
                _bus.Notify(notifications);

                // wait for 10 seconds
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}

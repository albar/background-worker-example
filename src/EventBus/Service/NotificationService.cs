using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace QueueExample.EventBus.Service
{
    public class NotificationService : BackgroundService
    {
        private readonly IEventBus _bus;

        public NotificationService(IEventBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // get notifications
                var notifications = await GetNotificationAsync();

                // notify event bus
                _bus.Notify(notifications);

                // wait for 10 seconds
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        private Task<IEnumerable<NotificationItem>> GetNotificationAsync()
        {
            // request notification from server
            throw new NotImplementedException();
        }
    }
}

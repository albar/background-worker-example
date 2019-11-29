using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QueueExample.NotificationRequestLoop
{
    public class NotificationService
    {

        public async Task RunAsync(INotificationHandler handler, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // get notifications
                var notifications = await GetNotificationsAsync();

                // notify handler
                handler.OnNewNotifications(notifications);

                // wait for 10 seconds
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        private Task<IEnumerable<NotificationItem>> GetNotificationsAsync()
        {
            // get from server
            throw new NotImplementedException();
        }
    }
}

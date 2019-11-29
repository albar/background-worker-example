using System;
using System.Collections.Generic;

namespace QueueExample.NotificationRequestLoop
{
    public class NotificationWindow : INotificationHandler
    {
        public void OnNewNotifications(IEnumerable<NotificationItem> notifications)
        {
            // show notification items
            throw new NotImplementedException();
        }
    }
}

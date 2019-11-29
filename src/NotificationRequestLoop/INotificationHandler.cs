using System.Collections.Generic;

namespace QueueExample.NotificationRequestLoop
{
    public interface INotificationHandler
    {
        void OnNewNotifications(IEnumerable<NotificationItem> notifications);
    }
}

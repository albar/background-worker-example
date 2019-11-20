using System;
using System.Collections.Generic;

namespace QueueExample.EventBus.Service
{
    public class NotificationEventBus : IEventBus
    {
        public event Action<NotificationItem> OnNewNotification;
        public event Action<Item> OnShowItem;

        public void Notify(IEnumerable<NotificationItem> notifications)
        {
            foreach (var notification in notifications)
            {
                OnNewNotification(notification);
            }
        }

        public void ShowItem(Item item)
        {
            OnShowItem(item);
        }
    }
}

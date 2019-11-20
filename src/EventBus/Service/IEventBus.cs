using System;
using System.Collections.Generic;

namespace QueueExample.EventBus.Service
{
    public interface IEventBus
    {
        event Action<NotificationItem> OnNewNotification;
        event Action<Item> OnShowItem;

        void Notify(IEnumerable<NotificationItem> notifications);
        void ShowItem(Item item);
    }
}

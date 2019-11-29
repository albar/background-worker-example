using System;
using System.Collections.Generic;

namespace QueueExample.EventBus.Abstractions
{
    public interface IEventBus
    {
        event Action<Item> OnNewNotification;
        event Action<Item> OnShowItem;

        void Notify(IEnumerable<Item> items);
        void ShowItem(Item item);
    }
}

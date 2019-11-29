using System;
using System.Collections.Generic;
using System.Linq;
using QueueExample.EventBus.Abstractions;

namespace QueueExample.EventBus
{
    public class NotificationEventBus : IEventBus
    {
        private readonly IStorage _storage;

        public NotificationEventBus(IStorage storage)
        {
            _storage = storage;
        }

        public event Action<Item> OnNewNotification;
        public event Action<Item> OnShowItem;

        public void Notify(IEnumerable<Item> items)
        {
            var newItems = _storage.Store(items.ToArray());
            foreach (var item in newItems)
            {
                OnNewNotification(item);
            }
        }

        public void ShowItem(Item item)
        {
            OnShowItem(item);
        }

        public void AddToStorage(params Item[] item)
        {
            _storage.Store(item);
        }
    }
}

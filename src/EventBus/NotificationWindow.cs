using System;
using QueueExample.EventBus.Service;

namespace QueueExample.EventBus
{
    public class NotificationWindow
    {
        private readonly IEventBus _bus;

        public NotificationWindow(IEventBus bus)
        {
            _bus = bus;
            _bus.OnNewNotification += OnNewNotification;
        }

        public void NotificationItem_Click()
        {
            var item = FindItem();
            _bus.ShowItem(item);
        }

        private Item FindItem()
        {
            // find specified item
            throw new NotImplementedException();
        }

        private void OnNewNotification(NotificationItem item)
        {
            // show notification
        }
    }
}

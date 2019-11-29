using System;
using QueueExample.EventBus.Abstractions;

namespace QueueExample.EventBus.Windows
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
            // Get selected item from notification window
            throw new NotImplementedException();
        }

        private void OnNewNotification(Item item)
        {
            // show notification
        }
    }
}

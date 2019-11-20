using System;
using QueueExample.EventBus.Service;

namespace QueueExample.EventBus
{
    public class MainWindow
    {
        private readonly IEventBus _bus;

        public MainWindow(IEventBus bus)
        {
            _bus = bus;
            _bus.OnShowItem += OnShowItem;
        }

        private void OnShowItem(Item item)
        {
            // show specified item
        }
    }
}

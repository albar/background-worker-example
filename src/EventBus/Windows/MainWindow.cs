using QueueExample.EventBus.Abstractions;

namespace QueueExample.EventBus.Windows
{
    public class MainWindow
    {
        private readonly IEventBus _bus;
        private readonly IServiceClient _client;

        public MainWindow(IEventBus bus, IServiceClient client)
        {
            _bus = bus;
            _client = client;
            _bus.OnShowItem += OnShowItem;
        }

        private void OnShowItem(Item item)
        {
            // show specified item
        }

        private void StoreItem_Click()
        {
            Item item; // get the item from the form
            _client.StoreAsync(item).Wait();
            _bus.AddToStorage(item);
        }
    }
}

using QueueExample.EventBus.Abstractions;

namespace QueueExample.EventBus.Windows
{
    public class MainWindow
    {
        private readonly IEventBus _bus;
        private readonly IServiceClient _client;
        private readonly IStorage _storage;

        public MainWindow(IEventBus bus,
            IServiceClient client,
            IStorage storage)
        {
            _bus = bus;
            _client = client;
            _storage = storage;
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
            _storage.Store(item);
        }
    }
}

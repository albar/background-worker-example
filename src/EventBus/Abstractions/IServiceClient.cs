using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueExample.EventBus.Abstractions
{
    public interface IServiceClient
    {
        Task StoreAsync(Item item);
        Task<Item> ListAsync(IReadOnlyDictionary<string, string> options);
        Task<IEnumerable<Item>> GetNotificationsAsync();
    }
}

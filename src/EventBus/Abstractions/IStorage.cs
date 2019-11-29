using System;
using System.Collections.Generic;

namespace QueueExample.EventBus.Abstractions
{
    public interface IStorage
    {
        ///
        /// Store many items and returns items that is not already in the storage
        ///
        IEnumerable<Item> Store(params Item[] item);

        ///
        /// Get all stored items
        ///
        IEnumerable<Item> List();
    }
}

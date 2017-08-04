//  --------------------------------------------------------------------------------------
// InventoryService.InventoryDataStore.cs
// 2017/08/03
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using InventoryService.Model;

namespace InventoryService
{
    public class InventoryDataStore
    {
        static InventoryDataStore instance;

        private InventoryDataStore()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public static InventoryDataStore Instance =>
            instance ?? (instance = new InventoryDataStore());

        public IList<InventoryItem> InventoryItems { get; }
    }
}
//  --------------------------------------------------------------------------------------
// InventoryService.InventoryService.cs
// 2017/08/03
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using InventoryService.Model;

namespace InventoryService
{
    public class InventoryService : IInventoryService
    {
        readonly InventoryDataStore dataStore = InventoryDataStore.Instance;

        public void AddInventoryItem(InventoryItem newItem)
        {
            Divider("Received AddInventoryItem Request");
            dataStore.InventoryItems.Add(newItem);
            Console.WriteLine($"Received:  {FormatItem(newItem)}");
            Divider("End AddInventoryItem");
        }

        public InventoryItem GetInventoryItem(Guid id)
        {
            Divider($"Received GetInventoryItem Request - ID:  {id}");
            var result = dataStore.InventoryItems.FirstOrDefault(p => p.Sku == id) ??
                         CreateAndAddItem(id);
            Console.WriteLine($"Returning Item {FormatItem(result)}");
            Divider("End GetInventoryItem");
            return result;
        }

        public IList<InventoryItem> GetInventoryItems()
        {
            Divider("Received GetInventoryItems Request");
            foreach (var item in dataStore.InventoryItems)
                Console.WriteLine(FormatItem(item));
            Divider("End GetInventoryItems");
            return dataStore.InventoryItems;
        }

        static void Divider(string header)
        {
            Console.WriteLine($"============= {header} =============");
        }

        static string FormatItem(InventoryItem item)
        {
            return $"{item.Sku} - {item.ProductName} - {item.Price:C}";
        }

        InventoryItem CreateAndAddItem(Guid id)
        {
            Console.WriteLine($"==>Item {id} does not exist. Creating.");
            var price = new Random().NextDouble() * 100;
            var result = new InventoryItem
                         {
                             Sku = id,
                             ProductName = "ProductName",
                             Price = (decimal) price
                         };
            // Just add the generated item to the datastore so it'll show up in GetInventoryItems, etc.
            dataStore.InventoryItems.Add(result);
            return result;
        }
    }
}
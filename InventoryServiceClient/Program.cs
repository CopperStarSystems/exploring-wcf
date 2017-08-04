//  --------------------------------------------------------------------------------------
// InventoryServiceClient.Program.cs
// 2017/08/03
//  --------------------------------------------------------------------------------------

using System;
using InventoryServiceClient.Inventory;

namespace InventoryServiceClient
{
    static class Program
    {
        static void AddItem(Inventory.InventoryServiceClient service)
        {
            Divider("Begin Add Inventory Item");
            var item = new InventoryItem
                       {
                           Sku = Guid.NewGuid(),
                           ProductName = "Added Product",
                           Price = 19.95M
                       };
            Console.WriteLine($"Adding Inventory Item {FormatItem(item)}");
            service.AddInventoryItem(item);
            Divider("End Add Inventory Item");
        }

        static void DisplayHeader()
        {
            Console.WriteLine("Inventory Service Client Console");
            Console.WriteLine(
                "Enter a Command and hit <Return>.  Use Menu to discover options.");
        }

        static void Divider(string header)
        {
            Console.WriteLine($"============= {header} =============");
        }

        static string FormatItem(InventoryItem item)
        {
            return $"{item.Sku} - {item.ProductName} - {item.Price:C}";
        }

        static void GetItemFromService(Inventory.InventoryServiceClient service, string input)
        {
            var id = new Guid(input);
            Divider("Begin Get Item from Service");
            Console.WriteLine($"Getting item {id} from service.");
            var result = service.GetInventoryItem(id);

            Console.WriteLine($"Service Returned Item: {FormatItem(result)}");
            Divider("End Get Item from Service");
        }

        static void GetItems(Inventory.InventoryServiceClient service)
        {
            Divider("Begin GetItems");
            var result = service.GetInventoryItems();
            var index = 1;
            foreach (var inventoryItem in result)
            {
                Console.WriteLine($"Item {index}: {FormatItem(inventoryItem)}");
                index++;
            }
            Divider("End GetItems");
        }

        static void Main(string[] args)
        {
            DisplayHeader();
            var service = new Inventory.InventoryServiceClient();

            ProcessInput(service);
        }

        static void ProcessInput(Inventory.InventoryServiceClient service)
        {
            var input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input) && input.ToLower() != "exit")
            {
                var split = input.Split(' ');
                var newId = string.Empty;
                if (split.Length == 2)
                    GetItemFromService(service, split[1]);
                else
                    switch (input.ToLower())
                    {
                        case "getitem":
                            GetItemFromService(service, Guid.NewGuid().ToString());
                            break;
                        case "additem":
                            AddItem(service);
                            break;
                        case "getitems":
                            GetItems(service);
                            break;
                        case "menu":
                            WriteMenu();
                            break;
                        default:
                            Console.WriteLine("Please select a valid command.");
                            WriteMenu();
                            break;
                    }

                input = Console.ReadLine();
            }
        }

        static void WriteMenu()
        {
            Console.WriteLine("Command Menu:");
            Console.WriteLine("Menu - Displays this Menu");
            Console.WriteLine("GetItem - Gets an item from Inventory");
            Console.WriteLine("GetItems - Gets all items from Inventory");
            Console.WriteLine("AddItem - Adds an item to the Inventory");
            Console.WriteLine();
            Console.WriteLine("Exit - Exits the Application");
        }
    }
}
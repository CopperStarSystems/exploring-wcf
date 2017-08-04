using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InventoryServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inventory Service Host Application");
            Console.WriteLine("Service output will be logged here.");
            Console.WriteLine("========================================");
            Console.WriteLine("Press <Enter> to exit the application.");
            using (var inventoryService = new ServiceHost(typeof(InventoryService.InventoryService)))
            {
                inventoryService.Open();

                var input = Console.ReadLine();
                //while (!string.IsNullOrEmpty(input) && input.ToLower() != "exit")
                //{
                //    switch (input.ToLower())
                //    {
                //        case "get":
                //            inventoryService.
                //            break;
                //    }


                //    input = Console.ReadLine();
                //}

            }
        }
    }
}

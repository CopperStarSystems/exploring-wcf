//  --------------------------------------------------------------------------------------
// InventoryService.InventoryItem.cs
// 2017/08/03
//  --------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace InventoryService.Model
{
    [DataContract]
    public class InventoryItem
    {
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public Guid Sku { get; set; }

        public override string ToString()
        {
            return $"{Sku} - {ProductName} - {Price:C}";
        }
    }
}
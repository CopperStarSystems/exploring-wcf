//  --------------------------------------------------------------------------------------
// InventoryService.IInventoryService.cs
// 2017/08/03
//  --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using InventoryService.Model;

namespace InventoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService
    {
        [OperationContract]
        InventoryItem GetInventoryItem(Guid id);

        [OperationContract]
        IList<InventoryItem> GetInventoryItems();

        [OperationContract]
        void AddInventoryItem(InventoryItem newItem);
    }
}
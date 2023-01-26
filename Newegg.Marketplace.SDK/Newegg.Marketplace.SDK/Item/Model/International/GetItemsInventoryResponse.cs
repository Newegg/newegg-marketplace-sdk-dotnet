using Newegg.Marketplace.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetItemsInventoryResponse : ResponseModel<InventoryItemResultBody>
    {
        public GetItemsInventoryResponse()
        {
            OperationType = "GetInventoryList";
        }
    }
}

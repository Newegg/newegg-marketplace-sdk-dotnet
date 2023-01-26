using Newegg.Marketplace.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{

    [XmlRoot("NeweggAPIResponse")]
    public class GetUsbOrCanInventorysResponse : ResponseModel<UsbOrCanInventoryItemResultBody>
    {
        public GetUsbOrCanInventorysResponse()
        {
            OperationType = "GetInventoryList";
        }
    }

    public class UsbOrCanInventoryItemResultBody
    {

        [XmlArrayItem("InventoryResult")]
        public List<InventoryResultOther> ItemList { get; set; }
        /// <summary>
        ///  数量
        /// </summary>
        public int TotalCount { get; set; }
    }


    /// <summary>
    /// CAN USB 
    /// </summary>
    [XmlRoot("InventoryResult")]
    public class InventoryResultOther
    {

        public string ItemNumber { get; set; }

        public string SellerPartNumber { get; set; }

        public string FulfillmentOption { get; set; }

        public string Active { get; set; }

        public int AvailableQuantity { get; set; }

        public List<Warehouse> WarehouseAllocation { set; get; }
    }
}

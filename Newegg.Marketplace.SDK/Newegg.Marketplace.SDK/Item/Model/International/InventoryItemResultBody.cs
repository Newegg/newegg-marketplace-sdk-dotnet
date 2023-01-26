using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    public class InventoryItemResultBody
    {
        [XmlArrayItem("InventoryResult")]
        public List<InventoryResult> ItemList { get; set; }
        /// <summary>
        ///  数量
        /// </summary>
        public int TotalCount { get; set; }
    }


    public class InventoryResult
    {

        public string ItemNumber { set; get; }

        public string SellerPartNumber { set; get; }


        /// <summary>
        ///  1: New
        ///  2: Refurbished
        ///  3: Used – Like New
        ///  4: Used – Very Good
        ///  5: Used – Good
        ///  6: Used – Acceptable
        /// </summary>
        public int? Condition { get; set; }


        [XmlArrayItem("Inventory")]
        public List<Inventory> InventoryAllocation { set; get; }
    }




    public class Inventory
    {
        /// <summary>
        ///  
        /// </summary>
        public string WarehouseLocation { set; get; }

        /// <summary>
        ///  0: ShipBySeller 1: ShipByNewegg
        /// </summary>
        public string FulfillmentOption { set; get; }

        /// <summary>
        ///  
        /// </summary>
        public int AvailableQuantity { set; get; }

        /// <summary>
        /// 仓储明细
        /// </summary>
        [XmlArrayItem("Warehouse")]
        public List<Warehouse> WarehouseAllocation { set; get; }


    }

    public class Warehouse
    {
        public string WarehouseCode { set; get; }
        public int Quantity { set; get; }
    }
}

/**
Newegg Marketplace SDK Copyright ? 2000-present Newegg Inc. 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the ?Software?), to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
THE SOFTWARE IS PROVIDED ?AS IS?, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("ContentQueryCriteria")]
    public class GetItemInternationalInventoryRequest
    {
        public ItemCondition? Condition { set; get; }
        public bool ShouldSerializeCondition()
        {
            return Condition.HasValue;
        }
        public ItemQueryType? Type { set; get; }
        public bool ShouldSerializeType()
        {
            return Type.HasValue;
        }
        public string Value { set; get; }

        [XmlArrayItem("WarehouseLocation"), JsonConverter(typeof(JsonMoreLevelSeConverter), "WarehouseLocation")]
        public List<string> WarehouseList { set; get; }
       
    }

    [XmlRoot("InventoryResult")]
    public class GetItemInternationalInventoryResponse
    {
        public string SellerID { set; get; }
        public string ItemNumber { set; get; }
        public string SellerPartNumber { set; get; }

        [XmlArrayItem("Inventory"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Inventory")]
        public List<Inventory> InventoryAllocation { set; get; }

        public class Inventory
        {
            public string WarehouseLocation { set; get; }
            public FulfillmentOption FulfillmentOption { set; get; }          
            public int AvailableQuantity { set; get; }

            [XmlArrayItem("Warehouse"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Warehouse")]
            public List<Warehouse> WarehouseAllocation { set; get; }

            public class Warehouse
            {
                public string WarehouseCode { set; get; }
                public int Quantity { set; get; }
            }
        }

       
    }

    
}

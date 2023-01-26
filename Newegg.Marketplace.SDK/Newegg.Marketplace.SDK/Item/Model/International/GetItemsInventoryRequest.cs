using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{

    [XmlRoot("ContentQueryCriteria")]
    public class GetItemsInventoryRequest
    {
        public ItemQueryType? Type { get; set; }

        [XmlArrayItem("Key")]
        public List<string> Values { get; set; }

        [XmlArrayItem("WarehouseLocation")]
        public List<string> WarehouseList { get; set; }
    }
}

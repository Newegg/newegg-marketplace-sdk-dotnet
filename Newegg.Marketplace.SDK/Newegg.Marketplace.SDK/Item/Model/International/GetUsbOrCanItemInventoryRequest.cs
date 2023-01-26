using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("ContentQueryCriteria")]
    public class GetUsbOrCanItemInventoryRequest
    {
        public ItemQueryType? Type { get; set; }

        [XmlArrayItem("Key")]
        public List<string> Values { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("ContentQueryCriteria")]
    public class GetInternationalItemPriceListRequest : GetCanOrUsbItemPriceRequest
    {

        [XmlArrayItem("CountryCode")]
        public List<string> CountryList { set; get; }
    }

    [XmlRoot("ContentQueryCriteria")]
    public class GetCanOrUsbItemPriceRequest
    {
        public ItemQueryType? Type
        {
            get; set;
        }

        [XmlArrayItem("Key")]
        public List<string> Values { set; get; }
    }
}

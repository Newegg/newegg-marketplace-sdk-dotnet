using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    public class PriceItemResultBody
    {
        [XmlArrayItem("PriceResult")]
        public List<PriceResult> ItemList { get; set; }

        /// <summary>
        ///  数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}

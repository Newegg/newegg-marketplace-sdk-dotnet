using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Item.Model
{
    public class PriceResult
    {
        public string ItemNumber { set; get; }
        public string SellerPartNumber { set; get; }

        [XmlArrayItem("Price")]
        public List<ItemPrice> PriceList { set; get; }

    }
    public class ItemPrice
    {
        public string CountryCode { set; get; }
        public string Currency { set; get; }
        public int Active { set; get; }
        public decimal MSRP { set; get; }

        [XmlElement("MAP"), JsonProperty("MAP")]
        public string _MAP { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? MAP
        {
            get
            {
                if (string.IsNullOrEmpty(_MAP))
                    return null;
                return decimal.Parse(_MAP);
            }
        }


        public int CheckoutMAP { set; get; }
        public decimal SellingPrice { set; get; }
        public int EnableFreeShipping { set; get; }
        public string OnPromotion { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int ShipByNewegg { get; set; }

        [XmlElement("LimitQuantity"), JsonProperty("LimitQuantity")]
        public string _LimitQuantity { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? LimitQuantity
        {
            get
            {
                if (string.IsNullOrEmpty(_LimitQuantity))
                    return null;
                return decimal.Parse(_LimitQuantity);
            }
        }
    }
}

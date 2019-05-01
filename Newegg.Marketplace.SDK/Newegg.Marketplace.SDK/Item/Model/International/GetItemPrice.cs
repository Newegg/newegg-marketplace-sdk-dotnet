/**
Newegg Marketplace SDK Copyright © 2000-present Newegg Inc. 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the “Software”), to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/


using System.Xml.Serialization;

using Newtonsoft.Json;




namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("ContentQueryCriteria")]
    public class GetItemPriceRequest
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

       
    }

    [XmlRoot("PriceResult")]
    public class GetItemPriceResponse
    {
        public string SellerID { set; get; }
        public string ItemNumber { set; get; }
        public string SellerPartNumber { set; get; }
        public int ShipByNewegg { set; get; }
        public ItemActive Active { set; get; }
        [XmlElement("MSRP"), JsonProperty("MSRP")]
        public string _MSRPP { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? MSRP
        {
            get
            {
                if (string.IsNullOrEmpty(_MSRPP))
                    return null;
                return decimal.Parse(_MSRPP);
            }
            set { }
        }

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
            set { }
        }

        public CheckoutMAP CheckoutMAP { set; get; }

        [XmlElement("SellingPrice"), JsonProperty("SellingPrice")]
        public string _SellingPriceMAP { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? SellingPrice
        {
            get
            {
                if (string.IsNullOrEmpty(_SellingPriceMAP))
                    return null;
                return decimal.Parse(_SellingPriceMAP);
            }
            set { }
        }

        public FulfillmentOption EnableFreeShipping { set; get; }
        public string OnPromotion { set; get; }

       
    }
}

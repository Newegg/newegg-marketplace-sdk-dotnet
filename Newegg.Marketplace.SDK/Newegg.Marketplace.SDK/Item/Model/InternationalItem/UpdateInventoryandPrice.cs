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
    [XmlRoot("ItemInventoryAndPriceInfo")]
    public class UpdateInventoryandPriceRequest
    {
        public ItemQueryType? Type { set; get; }
        public bool ShouldSerializeType()
        {
            return Type.HasValue;
        }
        public string Value { set; get; }
        public int Inventory { set; get; }
     
        public decimal MSRP { set; get; }
        public decimal MAP { set; get; }

        public CheckoutMAP? CheckoutMAP { set; get; }
        public bool ShouldSerializeCheckoutMAP()
        {
            return CheckoutMAP.HasValue;
        }

        public decimal SellingPrice { set; get; }

        public FreeShipping? EnableFreeShipping { set; get; }
        public bool ShouldSerializeEnableFreeShipping()
        {
            return EnableFreeShipping.HasValue;
        }

        public ItemActive? Active { set; get; }
        public bool ShouldSerializeActive()
        {
            return Active.HasValue;
        }

        public FulfillmentOption? FulfillmentOption { set; get; }
        public bool ShouldSerializeFulfillmentOption()
        {
            return FulfillmentOption.HasValue;
        }

        public ItemCondition? Condition { set; get; }

        public bool ShouldSerializeCondition()
        {
            return Condition.HasValue;
        }
    }

    [XmlRoot("UpdateInventoryAndPriceResult")]
    public class UpdateInventoryandPriceResponse
    {
        public string SellerID { set; get; }
        public string ItemNumber { set; get; }
        public string SellerPartNumber { set; get; }
        public string FulfillmentOption { set; get; }
        public ItemActive Active { set; get; }
        public int Result { set; get; }
        public int AvailableQuantity { set; get; }

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
        
      
       
    }
}

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


using System;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [XmlRoot("NeweggEnvelope")]
    [JsonConverter(typeof(JsonMoreLevelSeClassConverter), "NeweggEnvelope")]
    public class ItemPromotionFeedRequest : SubmitFeedRequest<ItemPromotionFeedRequestBody>
    {
        public ItemPromotionFeedRequest() : base("1.0", "ItemPromotion")
        {
        }
    }
    public class ItemPromotionFeedRequestBody
    {
        [XmlElement("Item")]
        public ItemPromotionFeedItem[] Item { get; set; }

        public class ItemPromotionFeedItem
        {
            public int? TabID { get; set; }
            public bool ShouldSerializeTabID()
            {
                return TabID.HasValue;
            }
            
            [XmlIgnore]
            public string SellerPartNumber { get; set; }
            [XmlElement("SellerPartNumber"), JsonIgnore]
            public XmlNode CDATASellerPartNumber
            {
                get
                {
                    if (string.IsNullOrEmpty(SellerPartNumber))
                        return null;
                    return new XmlDocument().CreateCDataSection(SellerPartNumber);
                }
                set { SellerPartNumber = value.Value; }
            }

            public string NeweggItemNumber { get; set; }

            public decimal? PromoMSRP { get; set; }
            public bool ShouldSerializePromoMSRP()
            {
                return PromoMSRP.HasValue;
            }

            public decimal PromoSellingPrice { get; set; }

            public FeedShipping? PromoShipping { get; set; }
            public bool ShouldSerializePromoShipping()
            {
                return PromoShipping.HasValue;
            }

            [XmlIgnore, JsonIgnore]
            public DateTime PromoStartDate { get; set; }
            [XmlElement("PromoStartDate"), JsonProperty("PromoStartDate")]
            public string _PromoStartDate
            {
                get
                {
                    return this.PromoStartDate.ToString("mm/dd/yyyy");
                }
                set { }
            }

            [XmlIgnore, JsonIgnore]
            public DateTime PromoEndDate { get; set; }
            [XmlElement("PromoEndDate"), JsonProperty("PromoEndDate")]
            public string _PromoEndDate
            {
                get
                {
                    return this.PromoEndDate.ToString("mm/dd/yyyy");
                }
                set { }
            }

            public int? LimitQty { get; set; }
            public bool ShouldSerializeLimitQty()
            {
                return LimitQty.HasValue;
            }

            public int? MaxQty { get; set; }
            public bool ShouldSerializeMaxQty()
            {
                return MaxQty.HasValue;
            }

            public int? MinInventory { get; set; }
            public bool ShouldSerializeMinInventory()
            {
                return MinInventory.HasValue;
            }

            public FeedInventoryLocked? InventoryLocked { get; set; }
            public bool ShouldSerializeInventoryLocked()
            {
                return InventoryLocked.HasValue;
            }

            public string Note { get; set; }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class ItemPromotionFeedResponse : SubmitFeedResponse
    { }
}

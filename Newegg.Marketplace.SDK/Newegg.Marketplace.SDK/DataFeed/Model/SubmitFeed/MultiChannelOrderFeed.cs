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


using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [XmlRoot("NeweggEnvelope")]
    [JsonConverter(typeof(JsonMoreLevelSeClassConverter), "NeweggEnvelope")]
    public class MultiChannelOrderFeedRequest : SubmitFeedRequest<MultiChannelOrderFeedRequestBody>
    {
        public MultiChannelOrderFeedRequest() : base("1.0", "MultiChannelOrderCreation")
        { }
    }

    public class MultiChannelOrderFeedRequestBody
    {
        public MultiChannelOrderFeedBasicInfo MultiChannelOrder { get; set; }
        public class MultiChannelOrderFeedBasicInfo
        {
            public MultiChannelOrderFeedOrderInfo Order { get; set; }
        }
        public class MultiChannelOrderFeedOrderInfo
        {
            public string OrderDate { get; set; }
            public string SalesChannel { get; set; }
            public string SellerOrderID { get; set; }

            public FeedShippingMethod? ShippingMethod { get; set; }
            public bool ShouldSerializeShippingMethod()
            {
                return ShippingMethod.HasValue;
            }

            public string ShipToFirstName { get; set; }
            public string ShipToLastName { get; set; }
            public string ShipToCompany { get; set; }
            public string ShipToAddressLine1 { get; set; }
            public string ShipToAddressLine2 { get; set; }
            public string ShipToCity { get; set; }
            public string ShipToState { get; set; }
            public string ShipToPostalCode { get; set; }
            public string ShipToCountry { get; set; }
            public string ShipToPhoneNumber { get; set; }

            [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
            public List<MultiChannelOrderFeedItemInfo> ItemList { get; set; }

            public class MultiChannelOrderFeedItemInfo
            {
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
                public int Quantity { get; set; }
            }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class MultiChannelOrderFeedResponse : SubmitFeedResponse
    { }
}

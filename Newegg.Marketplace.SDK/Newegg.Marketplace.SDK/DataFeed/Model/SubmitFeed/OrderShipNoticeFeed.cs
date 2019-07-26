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
    public class OrderShipNoticeFeedRequest : SubmitFeedRequest<OrderShipNoticeFeedRequestBody>
    {
        public OrderShipNoticeFeedRequest() : base("1.0", "ShipNotice")
        { }
    }

    public class OrderShipNoticeFeedRequestBody
    {
        public OrderShipNoticeFeedBasicInfo ShipNotice { get; set; }

        public class OrderShipNoticeFeedBasicInfo
        {
            [XmlElement("Package")]
            public OrderShipNoticeFeedPackageInfo[] Package { get; set; }
        }

        public class OrderShipNoticeFeedPackageInfo
        {
            public int OrderNumber { get; set; }
            public string ActualShippingCarrier { get; set; }
            public string ActualShippingMethod { get; set; }
            public string TrackingNumber { get; set; }

            [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
            public List<OrderShipNoticeFeedShipItemInfo> ItemInformation { get; set; }

            public class OrderShipNoticeFeedShipItemInfo
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
                public int ShippedQuantity { get; set; }
            }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class OrderShipNoticeFeedResponse : SubmitFeedResponse
    { }
}

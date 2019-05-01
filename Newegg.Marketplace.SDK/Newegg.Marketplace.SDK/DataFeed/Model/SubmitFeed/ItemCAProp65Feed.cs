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
    public class ItemCAProp65FeedRequest : SubmitFeedRequest<ItemCAProp65FeedRequestBody>
    {
        public ItemCAProp65FeedRequest() : base("4.0", "AddingCAProp65")
        { }
    }

    public class ItemCAProp65FeedRequestBody
    {
        [XmlArrayItem("Item")]
        [JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<ItemCAProp65FeedItem> Itemfeed { get; set; }

        public class ItemCAProp65FeedItem
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

            public FeedWarningTypeID? WarningType_ID { get; set; }
            public bool ShouldSerializeWarningType_ID()
            {
                return WarningType_ID.HasValue;
            }

            public string ChemicalName_Carcinogen { get; set; }
            public string ChemicalName_ReproductiveToxicant { get; set; }
            public string ChemicalName_Both { get; set; }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class ItemCAProp65FeedResponse : SubmitFeedResponse
    { }
}

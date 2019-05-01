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
using System.Xml;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [XmlRoot("NeweggEnvelope")]
    [JsonConverter(typeof(JsonMoreLevelSeClassConverter), "NeweggEnvelope")]
    public class ItemPremierMarkFeedRequest : SubmitFeedRequest<ItemPremierMarkFeedRequestBody>
    {
        public ItemPremierMarkFeedRequest() : base("1.0", "BatchPremierMarkUpdate")
        {
        }
    }
    public class ItemPremierMarkFeedRequestBody
    {
        [XmlElement("Item")]
        public ItemPremierMarkFeedItem[] Item { get; set; }

        public class ItemPremierMarkFeedItem
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

            public FeedPremierMark? PremierMark { get; set; }
            public bool ShouldSerializePremierMark()
            {
                return PremierMark.HasValue;
            }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class ItemPremierMarkFeedResponse : SubmitFeedResponse
    { }
}

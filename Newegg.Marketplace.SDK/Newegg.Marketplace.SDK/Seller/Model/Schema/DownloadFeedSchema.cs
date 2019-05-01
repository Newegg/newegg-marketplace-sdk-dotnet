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

using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class DownloadFeedSchemaRequest : RequestModel<DownloadFeedSchemaRequestBody>
    {
        public DownloadFeedSchemaRequest()
        {
            OperationType = "GetFeedSchemaRequest";
        }
        public DownloadFeedSchemaRequest(int feedType, string industryCode = null)
        {
            OperationType = "GetFeedSchemaRequest";
            RequestBody = new DownloadFeedSchemaRequestBody()
            {
                GetFeedSchema = new DownloadFeedSchemaRequestBody.DownloadFeedSchemaInfo()
                {
                    FeedType = feedType,
                    IndustryCode = industryCode
                }
            };
        }
    }

    public class DownloadFeedSchemaRequestBody
    {
        public DownloadFeedSchemaInfo GetFeedSchema { get; set; }

        public class DownloadFeedSchemaInfo
        {
            /// <summary>
            /// 1:ITEM_DATA (ALL)
            /// 2:ORDER_SHIP_NOTICE_DATA (USA), INVENTORY_AND_PRICE_DATA (B2B/CAN)
            /// 3:ORDER_SHIP_NOTICE_DATA (B2B/CAN)
            /// 4:ITEM_BATCH_UPDATE (ALL)
            /// 5:MULTICHANNEL_ORDER_DATA (B2B/CAN)
            /// 6:ITEM_DATA_UPCMATCH (ALL)
            /// 7:ITEM_PROMOTION_DATA (USA)
            /// 8:VOLUME_DISCOUNT_DATA (ALL)
            /// 9:ExcludeSellCountry
            /// 10:INVENTORY_DATA (USA)
            /// 11:PRICE_DATA (USA)
            /// 12:ITEM_PREMIER_MARK_DATA (USA)
            /// 100:3PL_ITEM_DATA
            /// </summary>
            public int FeedType { get; set; }

            /// <summary>
            /// Required if FeedType = ITEM_DATA
            /// </summary>
            public string IndustryCode { get; set; }
        }
    }
}

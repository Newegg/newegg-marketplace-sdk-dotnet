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

using Newegg.Marketplace.SDK.Base.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [XmlRoot("NeweggEnvelope"), JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggEnvelope")]
    public class GetFeedResultResponse : SubmitFeedRequest<GetFeedResultResponseBody>
    {
    }
    public class GetFeedResultResponseBody
    {
        public GetFeedResultProcessReport ProcessingReport { get; set; }
    }

    public class GetFeedResultProcessReport
    {
        public string OriginalMessageName { get; set; }
        public string StatusCode { get; set; }
        public string OriginalMessageType { get; set; }
        public string MessageType { get; set; }
        public string ProcessedStamp { get; set; }

        public GetFeedResultProcessingSummary ProcessingSummary { get; set; }

        [XmlElement("Result")]
        public GetFeedResult[] ResultList { get; set; }

        public class GetFeedResultProcessingSummary
        {
            public int ProcessedCount { get; set; }
            public int SuccessCount { get; set; }
            public int WithErrorCount { get; set; }
        }

        
    }
    public class GetFeedResult
    {
        public GetFeedResultAdditionalInfo AdditionalInfo { get; set; }

        [XmlArrayItem("ErrorDescription")]
        public List<string> ErrorList { get; set; }
        [XmlArrayItem("ErrorDescription")]
        public List<string> Error { get; set; }

        public class GetFeedResultAdditionalInfo
        {
            public string SubCategoryID { get; set; }
            public string SellerPartNumber { get; set; }
            public string ManufacturerPartsNumber { get; set; }
            public string NeweggItemNumber { get; set; }
            public string CountryCode { get; set; }
            public string WareHouseLocation { get; set; }
            public string UPCOrISBN { get; set; }
            public string OrderNumber { get; set; }
            public string TrackingNumber { get; set; }
            public string WarningType_ID { get; set; }
            public string SellerOrderID { get; set; }
        }
    }

    public class GetFeedResultError
    {
        public string ErrorElement { get; set; }
        public string ErrorDescription { get; set; }
    }
}

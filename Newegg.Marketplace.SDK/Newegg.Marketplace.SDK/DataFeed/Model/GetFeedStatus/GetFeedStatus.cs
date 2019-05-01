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

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetFeedStatusRequest : RequestModel<GetFeedStatusRequestBody>
    {
        public GetFeedStatusRequest()
        {
            OperationType = "GetFeedStatusRequest";
        }
        public GetFeedStatusRequest(string[] RequestIDs, FeedRequestStatus requestStatus = FeedRequestStatus.ALL)
        {
            OperationType = "GetFeedStatusRequest";
            RequestBody = new GetFeedStatusRequestBody()
            {
                GetRequestStatus = new GetFeedStatusRequestBody.GetFeedStatusRequestCriteria()
                {
                    RequestIDList = new List<string>(),
                    RequestStatus = requestStatus
                }
            };
            foreach (string RequestID in RequestIDs)
            {
                RequestBody.GetRequestStatus.RequestIDList.Add(RequestID);
            }
        }
    }
    public class GetFeedStatusRequestBody
    {
        public GetFeedStatusRequestCriteria GetRequestStatus { get; set; }
        public class GetFeedStatusRequestCriteria
        {
            [XmlArrayItem("RequestID")]
            [JsonConverter(typeof(JsonMoreLevelSeConverter), "RequestID")]
            public List<string> RequestIDList { get; set; }
            public int MaxCount { get; set; } = 100;

            public FeedRequestStatus? RequestStatus { get; set; } = FeedRequestStatus.ALL;
            public bool ShouldSerializeRequestStatus()
            {
                return RequestStatus.HasValue;
            }

            public string RequestDateFrom { get; set; }
            public string RequestDateTo { get; set; }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class GetFeedStatusResponse : ResponseModel<GetFeedStatusResponseBody>
    {

    }
    public class GetFeedStatusResponseBody
    {
        [XmlArray]
        public List<ResponseInfo> ResponseList { get; set; }
        public class ResponseInfo
        {
            public string RequestId { get; set; }
            public string RequestType { get; set; }
            public string RequestDate { get; set; }
            public FeedRequestStatus RequestStatus { get; set; }
        }
    }
}

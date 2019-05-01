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

namespace Newegg.Marketplace.SDK.RMA.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetCourtesyRefundRequestStatusRequest : RequestModel<GetCourtesyRefundRequestStatusRequestBody>
    {
        public GetCourtesyRefundRequestStatusRequest()
        {
            OperationType = "GetCourtesyRefundStatusRequest";
        }
    }
    public class GetCourtesyRefundRequestStatusRequestBody
    {
        public GetCourtesyRefundRequestStatusInfo GetRequestStatus { get; set; }
        public class GetCourtesyRefundRequestStatusInfo
        {
            [XmlArrayItem("RequestID")]
            [JsonConverter(typeof(JsonMoreLevelSeConverter), "RequestID")]
            public List<string> RequestIDList { get; set; }

            public int? MaxCount { get; set; }
            public bool ShouldSerializeMaxCount()
            {
                return MaxCount.HasValue;
            }

            public CourtesyRefundRequestStatus? RequestStatus { get; set; }
            public bool ShouldSerializeRequestStatus()
            {
                return RequestStatus.HasValue;
            }

            public string RequestDateFrom { get; set; }
            public string RequestDateTo { get; set; }
        }
    }

    [XmlRoot("NeweggAPIResponse")]
    [JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggAPIResponse")]
    public class GetCourtesyRefundRequestStatusResponse : ResponseModel<GetCourtesyRefundRequestStatusResponseBody>
    {
    }
    public class GetCourtesyRefundRequestStatusResponseBody
    {
        public ResponseInfos ResponseList { get; set; }
        public class ResponseInfos
        {
            public GetCourtesyRefundRequestStatusResponseInfo ResponseInfo { get; set; }
            public class GetCourtesyRefundRequestStatusResponseInfo
            {
                public string RequestId { get; set; }
                public string RequestType { set; get; }
                public string RequestDate { set; get; }
                public CourtesyRefundRequestStatus RequestStatus { set; get; }
                public string ProcessMemo { set; get; }
                [XmlElement("Result"), JsonProperty("Result")]
                public Results Result { get; set; }

                public class Results
                {
                    public GetCourtesyRefundInfo CourtesyRefundInfo { get; set; }
                    public class GetCourtesyRefundInfo
                    {
                        public string CourtesyRefundID { set; get; }
                        public int SONumber { set; get; }
                        public decimal SOAmount { set; get; }
                        public int InvoiceNumber { set; get; }
                        public decimal RefundAmount { set; get; }
                        public CourtesyRefundReason ReasonCode { set; get; }
                        public string Reason { set; get; }
                        public string NoteToCustomer { set; get; }
                        public CourtesyRefundStatus Status { set; get; }
                        public bool IsNeweggRefund { set; get; }
                        public string InUserName { set; get; }
                        public string InDate { set; get; }
                        public string EditUserName { set; get; }
                        public string EditDate { set; get; }
                    }
                }
            }
        }
    }
}

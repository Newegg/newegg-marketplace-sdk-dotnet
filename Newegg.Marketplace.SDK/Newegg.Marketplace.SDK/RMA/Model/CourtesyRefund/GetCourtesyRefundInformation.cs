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
using System.Collections.Generic;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.RMA.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetCourtesyRefundInformationRequest : RequestModel<GetCourtesyRefundInformationRequestBody>
    {
        public GetCourtesyRefundInformationRequest()
        {
            OperationType = "GetCourtesyRefundInfo";
        }
    }
    public class GetCourtesyRefundInformationRequestBody
    {
        public GetCourtesyRefundInformationRequestBody()
        {
            PageInfo = new CommondPageInfo();
        }

        public CommondPageInfo PageInfo { get; set; }

        public CourtesyRefundKeywordsType? KeywordsType { get; set; }
        public bool ShouldSerializeKeywordsType()
        {
            return KeywordsType.HasValue;
        }

        public string KeywordsValue { get; set; }

        public CourtesyRefundStatus? Status { get; set; }
        public bool ShouldSerializeStatus()
        {
            return Status.HasValue;
        }

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }

    [XmlRoot("NeweggAPIResponse")]
    [JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggAPIResponse")]
    public class GetCourtesyRefundInformationResponse : ResponseModel<GetCourtesyRefundInformationResponseBody>
    {
    }
    public class GetCourtesyRefundInformationResponseBody
    {
        public CommondPageInfo PageInfo { get; set; }

        [XmlArrayItem("CourtesyrefundInfo"), JsonConverter(typeof(JsonMoreLevelDeConverter), "CourtesyrefundInfo")]
        public List<GetCourtesyRefundInfo> CourtesyRefundInfoList { get; set; }

        public class GetCourtesyRefundInfo
        {
            public string CourtesyRefundID { get; set; }
            public string SONumber { get; set; }
            public decimal SOAmount { get; set; }
            public string InvoiceNumber { get; set; }
            public decimal RefundAmount { get; set; }
            public CourtesyRefundReason ReasonCode { get; set; }
            public string Reason { get; set; }
            public string NoteToCustomer { get; set; }
            public string Status { get; set; }
            public string IsNeweggRefund { get; set; }
            public string InUserName { get; set; }
            public string InDate { get; set; }
            public string EditUserName { get; set; }
            public string EditDate { get; set; }
        }
    }
}

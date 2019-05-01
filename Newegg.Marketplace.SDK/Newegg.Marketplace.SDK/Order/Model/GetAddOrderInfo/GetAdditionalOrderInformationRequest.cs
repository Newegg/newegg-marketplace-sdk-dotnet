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
using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;

namespace Newegg.Marketplace.SDK.Order.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetAdditionalOrderInformationRequest : RequestModel<GetAdditionalOrderInformationRequestBody>
    {
        public GetAdditionalOrderInformationRequest()
        {
            OperationType = "GetAddOrderInfoRequest";
        }
        public GetAdditionalOrderInformationRequest(GetAdditionalOrderInformationRequestCriteria criteria)
        {
            OperationType = "GetAddOrderInfoRequest";
            RequestBody = new GetAdditionalOrderInformationRequestBody()
            {
                RequestCriteria = criteria
            };
        }
    }

    [XmlRoot("RequestBody")]
    public class GetAdditionalOrderInformationRequestBody
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetAdditionalOrderInformationRequestCriteria RequestCriteria { get; set; }

        public GetAdditionalOrderInformationRequestBody()
        {
            PageIndex = 1;
            PageSize = 100;
        }
    }

    [XmlRoot("RequestCriteria")]
    public class GetAdditionalOrderInformationRequestCriteria
    {
        [XmlArrayItem("OrderNumber"), JsonConverter(typeof(JsonMoreLevelSeConverter), "OrderNumber")]
        public string[] OrderNumberList { get; set; }

        [XmlArrayItem("SellerOrderNumber"), JsonConverter(typeof(JsonMoreLevelSeConverter), "OrderNumber")]
        public string[] SellerOrderNumberList { get; set; }

        public AddOrderStatus? Status { get; set; }
        public bool ShouldSerializeStatus()
        {
            return Status.HasValue;
        }

        public OrderType? Type { get; set; }
        public bool ShouldSerializeType()
        {
            return Type.HasValue;
        }

        public string OrderDateFrom { get; set; }

        public string OrderDateTo { get; set; }

        public string CountryCode { get; set; }

        public string SellerID { get; set; }

        public OrderVoidSoon? VoidSoon { get; set; }
        public bool ShouldSerializeVoidSoon()
        {
            return VoidSoon.HasValue;
        }

        public OrderDownload? OrderDownloaded { get; set; }
        public bool ShouldSerializeOrderDownloaded()
        {
            return OrderDownloaded.HasValue;
        }
    }
}

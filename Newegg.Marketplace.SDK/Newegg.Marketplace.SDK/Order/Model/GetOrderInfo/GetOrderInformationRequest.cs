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


namespace Newegg.Marketplace.SDK.Order.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetOrderInformationRequest : RequestModel<GetOrderInformationRequestBody>
    {
        public GetOrderInformationRequest()
        {
            OperationType = "GetOrderInfoRequest";
        }
        public GetOrderInformationRequest(GetOrderInformationRequestCriteria criteria)
        {
            OperationType = "GetOrderInfoRequest";
            RequestBody = new GetOrderInformationRequestBody()
            {
                RequestCriteria = criteria
            };
        }
    }

    [XmlRoot("RequestBody")]
    public class GetOrderInformationRequestBody
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetOrderInformationRequestCriteria RequestCriteria { get; set; }

        public GetOrderInformationRequestBody()
        {
            PageIndex = 1;
            PageSize = 100;
        }
    }

    [XmlRoot("RequestCriteria")]
    public class GetOrderInformationRequestCriteria
    {
        [XmlArrayItem("OrderNumber")]
        public string[] OrderNumberList { get; set; }

        [XmlArrayItem("SellerOrderNumber")]
        public string[] SellerOrderNumberList { get; set; }

        public OrderStatus? Status { get; set; }
        public bool ShouldSerializeStatus()
        {
            return Status.HasValue;
        }

        public OrderInfoType? Type { get; set; }
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

        /// <summary>
        /// Only for USA
        /// </summary>
        public OrderPremier? PremierOrder { get; set; }
        public bool ShouldSerializePremierOrder()
        {
            return PremierOrder.HasValue;
        }
    }
}

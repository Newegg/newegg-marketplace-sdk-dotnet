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
using System;
using System.Xml.Serialization;

using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.Report.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class SubmitOrderListReportRequest : RequestModel<SubmitOrderListReportRequestBody>
    {
        public SubmitOrderListReportRequest()
        {
            OperationType = "OrderListReportRequest";
          
        }

        public string IssueUser { set; get; }

        
    }
    public class SubmitOrderListReportRequestBody
    {
         

        public RequestOrderReportCriteria OrderReportCriteria { get; set; }

    }

    public class RequestOrderReportCriteria
    {
        public RequestOrderReportCriteria(DateTime dateFrom, DateTime dateTo)
        {
            RequestType = ReportRequestType.ORDER_LIST_REPORT.ToString();
            OrderDateFrom = dateFrom.ToString("yyyy-MM-dd");
            OrderDateTo = dateTo.ToString("yyyy-MM-dd");
            Type = ReportInfoType.All;
            KeywordsType = ReportKeywordsType.All;
        }
        public RequestOrderReportCriteria()
            : this(DateTime.Now, DateTime.Now)
        { }
        public string RequestType { set; get; }
       
        public ReportKeywordsType? KeywordsType { get; set; }
        public bool ShouldSerializeKeywordsType()
        {
            return KeywordsType.HasValue;
        }
        public string KeywordsValue { get; set; }

        public ReportStatus? Status { get; set; }
        public bool ShouldSerializeStatus()
        {
            return Status.HasValue;
        }

        public ReportInfoType? Type { get; set; }
        public bool ShouldSerializeType()
        {
            return Type.HasValue;
        }
        public string OrderDateFrom { get; set; }

        public string OrderDateTo { get; set; }

        public ReportVoidSoon? VoidSoon { get; set; }
        public bool ShouldSerializeVoidSoon()
        {
            return VoidSoon.HasValue;
        }

        public string OrderDownloaded { get; set; }
       
        public string CountryCode { set; get; }

        public ReportPremier? PremierOrder { get; set; }
        public bool ShouldSerializePremierOrder()
        {
            return PremierOrder.HasValue;
        }
    }


}

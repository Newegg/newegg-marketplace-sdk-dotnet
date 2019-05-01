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
    public class SettlementSummaryReportRequest : RequestModel<SettlementSummaryReportRequestBody>
    {
        public SettlementSummaryReportRequest()
        {
            OperationType = "SettlementSummaryReportRequest";
          
        }
       
    }
    public class SettlementSummaryReportRequestBody
    {
        public SettlementSummaryReportCriteria SettlementSummaryReportCriteria
        {
            get;
            set;
        }

    }

    public class SettlementSummaryReportCriteria
    {
       
        public SettlementSummaryReportCriteria(DateTime dateFrom, DateTime dateTo)
        {
            RequestType = ReportRequestType.SETTLEMENT_SUMMARY_REPORT.ToString();
            DateFrom = dateFrom.ToString("yyyy-MM-dd");
            DateTo = dateTo.ToString("yyyy-MM-dd");
           
        }
        public SettlementSummaryReportCriteria()
            : this(DateTime.Now, DateTime.Now)
        { }

        public string RequestType { set; get; }
        public string DateFrom { set; get; }
       
        public string DateTo { set; get; }
        

    }
    
}

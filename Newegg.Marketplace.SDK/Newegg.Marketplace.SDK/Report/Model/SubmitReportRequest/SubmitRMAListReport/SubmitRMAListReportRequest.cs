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
    public class SubmitRMAListReportRequest : RequestModel<SubmitRMAListReportRequestBody>
    {
        public SubmitRMAListReportRequest()
        {
            OperationType = "RMAListReportRequest";         
        }     
    }
    public class SubmitRMAListReportRequestBody
    {
        public RMAListReportCriteria RMAListReportCriteria { get; set; }      
    }

    
    public class RMAListReportCriteria
    {
     
        public RMAListReportCriteria() : this(DateTime.Now, DateTime.Now)
        { }
        public RMAListReportCriteria(DateTime RMADateFrom, DateTime RMADateTo)
        {
            this.RequestType = ReportRequestType.RMA_LIST_REPORT.ToString();
            this.RMADateFrom = RMADateFrom.ToString("yyyy-MM-dd");
            this.RMADateTo = RMADateTo.ToString("yyyy-MM-dd");

        }
 
        public string RequestType { get; set; }
       
        public ReportKeywordsType KeywordsType { get; set; }
       
        public string KeywordsValue { get; set; }

        public RMAReportStatus Status { get; set; }
      
        public string RMADateFrom { get; set; }
   
        public string RMADateTo { get; set; }

        public ReportRMAType RMAType { get; set; }
        
        public ReportProcessedBy ProcessedBy { get; set; }
      

    }

   
}

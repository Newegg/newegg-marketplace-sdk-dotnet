using Newegg.Marketplace.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Report.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class SubmittemBasicInformationReportRequest : RequestModel<IttemBasicInformationReportBody>
    {
        public SubmittemBasicInformationReportRequest()
        {
            OperationType = "ItemBasicInfoReportRequest";
        }
    }

    public class IttemBasicInformationReportBody
    {
        public IttemBasicInformationReportCriteria ItemBasicInfoReportCriteria { set; get; }

    }

    public class IttemBasicInformationReportCriteria
    {
        public IttemBasicInformationReportCriteria()
        {
            this.RequestType = ReportRequestType.ITEM_BASIC_INFO_REPORT.ToString();
            this.FileType = ReportFileType.TXT;
        }
        public string RequestType { get; set; }
        public ReportFileType FileType { get; set; }

    }
}

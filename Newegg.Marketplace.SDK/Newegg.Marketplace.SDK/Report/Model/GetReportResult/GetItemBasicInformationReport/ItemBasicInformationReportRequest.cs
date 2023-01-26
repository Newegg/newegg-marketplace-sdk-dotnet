using Newegg.Marketplace.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Report.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class ItemBasicInformationReportRequest : RequestModel<ItemBasicInformationReportRequestBody>
    {
        public ItemBasicInformationReportRequest()
        {
            OperationType = "ItemBasicInfoReportRequest";

        }
    }

    public class ItemBasicInformationReportRequestBody
    {
        public string RequestID { set; get; }
        public PageInfo PageInfo { set; get; }
    }
}

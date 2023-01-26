using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Report.Model
{
    [XmlRoot("NeweggAPIResponse")]
    [JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggAPIResponse")]
    public class ItemBasicInformationReportResponse : ResponseModel<ItemBasicInformationReportResponseBody>
    {
        public ItemBasicInformationReportResponse()
        {
            OperationType = "ItemBasicInfoReportResponse";

        }
        public string Memo { get; set; }
    }

    public class ItemBasicInformationReportResponseBody
    {


        public string RequestID { get; set; }


        public string RequestType { get; set; }


        public string RequestDate { get; set; }

        public string ReportFileURL { get; set; }

    }
}

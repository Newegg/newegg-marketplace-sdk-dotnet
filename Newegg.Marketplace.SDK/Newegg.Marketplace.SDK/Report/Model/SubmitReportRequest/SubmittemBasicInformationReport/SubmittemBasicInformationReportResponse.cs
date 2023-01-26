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
    public class SubmitItemBasicInformationReportResponse : ResponseModel<SubmitItemBasicInformationReportResponseBody>
    {

        public string sellerID { get; set; }
        public SubmitItemBasicInformationReportResponse()
        {
            OperationType = "ItemBasicInfoReportResponse";

        }

    }

    public class SubmitItemBasicInformationReportResponseBody
    {
        public SubmitItemBasicInformationReportResponseBody()
        {
            this.ResponseList = new List<ItemBasicInformationReport>();

        }

        [XmlArrayItem("ResponseInfo"), JsonConverter(typeof(JsonMoreLevelSeConverter), "ResponseInfo")]
        public List<ItemBasicInformationReport> ResponseList { set; get; }
    }

    public class ItemBasicInformationReport : GetResponseInfoStatus
    {
    }
}

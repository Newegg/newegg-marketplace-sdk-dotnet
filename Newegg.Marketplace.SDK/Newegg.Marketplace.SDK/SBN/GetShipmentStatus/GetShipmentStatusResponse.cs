
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Item.Model;

namespace Newegg.Marketplace.SDK.SBN.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetShipmentStatusResponse : ResponseModel<GetShipmentStatusResponseBody>
    {
        public string Memo { get; set; }

        public GetShipmentStatusResponse()
        {
            this.OperationType = "GetShipmentStatusResponse";
        }
    }

    public class GetShipmentStatusResponseBody
    {
        public GetShipmentStatusResponseBody()
        {
            this.ResponseList = new List<ShipmentStatus>();
        }

        [XmlArrayItem("ResponseInfo"), JsonConverter(typeof(JsonMoreLevelSeConverter), "ResponseInfo")]
        public List<ShipmentStatus> ResponseList { get; set; }
    }

    public class ShipmentStatus
    {
        public string RequestId { get; set; }


        public string ActionCodeString { set; get; }

        public ItemActionCode ActionCode { set; get; }


        public string RequestDate { get; set; }

        public string RequestStatus { get; set; }

        public string Memo { get; set; }
    }
}

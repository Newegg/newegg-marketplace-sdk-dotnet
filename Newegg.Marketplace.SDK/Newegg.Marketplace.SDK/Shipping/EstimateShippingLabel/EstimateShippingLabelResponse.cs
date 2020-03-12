using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Shipping.EstimateShippingLabel
{
    [XmlRoot("NeweggAPIResponse")]
    public class EstimateShippingLabelResponse : ResponseModel<ShippingLabelEstimateResponseBody>
    {
        public EstimateShippingLabelResponse()
        {
            this.OperationType = "EstimateShippingLabelResponse";
        }
    }

    public class ShippingLabelEstimateResponseBody
    {
        [XmlElement("Shipment")]
        public EstimateShipment Shipment { get; set; }
    }

    public class EstimateShipment
    {
        public int OrderNumber { get; set; }
        public string EstimatedDate { get; set; }
        [XmlArrayItem("Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        public List<EstimatPackage> PackageList { get; set; }
        public string OrderStatus { get; set; }
        public string ShipDate { get; set; }

    }

    public class EstimatPackage
    {
        public decimal PackageWeight { get; set; }

        public decimal PackageLength { get; set; }

        public decimal PackageHeight { get; set; }

        public decimal PackageWidth { get; set; }

        public string SignatureOptions { get; set; }

        public string ProcessResult { get; set; }

        public string ErrorMessage { get; set; }
        public EstimatedRate EstimatedRate { get; set; }
    }

    public class EstimatedRate
    {
        public string EstimatedArriveBy { get; set; }
        public decimal EstimatedShippingAmount { get; set; }
        public decimal EstimatedSignatureOptions { get; set; }
        public decimal EstimatedTotal { get; set; }
        public decimal EstimatedShipWeight { get; set; }
    }
}

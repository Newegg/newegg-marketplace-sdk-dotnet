using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Shipping.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Shipping.CreateShippingLabel
{
    [XmlRoot("NeweggAPIResponse")]
    public class CreateShippingLabelResponse : ResponseModel<ShippingLabelCreateResponseBody>
    {
        public CreateShippingLabelResponse()
        {
            this.OperationType = "CreateShippingLabelResponse";
        }
    }
    public class ShippingLabelCreateResponseBody
    {
        [XmlElement("Shipment")]
        public CreateShipment Shipment { get; set; }
    }

    public class CreateShipment
    {
        public int OrderNumber { get; set; }

        public string ShipDate { get; set; }
        [XmlArrayItem("Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        public List<CreatePackage> PackageList { get; set; }
    }

    public class CreatePackage
    {
        public string TrackingNumber { get; set; }

        public string ProcessResult { get; set; }

        public string ErrorMessage { get; set; }

        public string SignatureOptions { get; set; }

        public string LabelUrl { get; set; }

        public string PackingListUrl { get; set; }

        public Rate Rate { get; set; }
        [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<SumbitPackageItemlist> ItemList { get; set; }
    }
    public class Rate
    {
        public decimal ShipWeight { get; set; }
        public string ArriveBy { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal SignatureOptions { get; set; }
        public decimal Total { get; set; }
    }
}


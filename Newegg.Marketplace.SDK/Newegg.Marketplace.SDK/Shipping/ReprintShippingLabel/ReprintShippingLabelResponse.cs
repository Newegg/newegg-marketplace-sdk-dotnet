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

namespace Newegg.Marketplace.SDK.Shipping.ReprintShippingLabel
{
    [XmlRoot(ElementName = "NeweggAPIResponse")]
    public class ReprintShippingLabelResponse : ResponseModel<ShippingLabelReprintResponseBody>
    {
        public ReprintShippingLabelResponse()
        {
            this.OperationType = "ReprintShippingLabelResponse";
        }
    }

    public class ShippingLabelReprintResponseBody
    {
        [XmlElement("Shipment")]
        public ReprintShipment Shipment { get; set; }
    }

    public class ReprintShipment
    {
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ErrorMessage { get; set; }
        [XmlArrayItem("Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        public List<RepintPackage> PackageList { get; set; }
    }

    public class RepintPackage
    {
        public string TrackingNumber { get; set; }
        public string SignatureOptions { get; set; }

        public string LabelUrl { get; set; }
        public string PackingListUrl { get; set; }

        [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<SumbitPackageItemlist> ItemList { get; set; }
    }
}
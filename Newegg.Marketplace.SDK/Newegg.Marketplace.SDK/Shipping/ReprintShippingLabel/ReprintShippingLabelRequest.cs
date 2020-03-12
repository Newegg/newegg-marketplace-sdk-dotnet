using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Shipping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Shipping.ReprintShippingLabel
{
    [XmlRoot("NeweggAPIRequest")]
    public class ReprintShippingLabelRequest : RequestModel<ReprintShippingRequestBody>
    {
        public string SellerID { get; set; }
        public ReprintShippingLabelRequest()
        {
            this.OperationType = "ReprintShippingLabel";
        }
    }

    public class ReprintShippingRequestBody
    {
        [XmlElement("Shipment")]
        public ReprintShipment Shipment { get; set; }
    }
}

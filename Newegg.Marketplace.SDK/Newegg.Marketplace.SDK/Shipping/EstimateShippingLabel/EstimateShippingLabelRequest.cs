using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Shipping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Shipping.EstimateShippingLabel
{
    [XmlRoot("NeweggAPIRequest")]
    public class EstimateShippingLabelRequest : RequestModel<SubmitShippingRequestBody>
    {
        public string SellerID { get; set; }
        public EstimateShippingLabelRequest()
        {
            this.OperationType = "EstimateShippingLabel";
        }
    }
}

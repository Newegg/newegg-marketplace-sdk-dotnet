using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Shipping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Shipping.CreateShippingLabel
{
    [XmlRoot("NeweggAPIRequest")]
    public class CreateShippingLabelRequest : RequestModel<SubmitShippingRequestBody>
    {
        public string SellerID { get; set; }
        public CreateShippingLabelRequest()
        {
            this.OperationType = "CreateShippingLabel";
        }
    }
}
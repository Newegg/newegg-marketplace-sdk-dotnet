/**
Newegg Marketplace SDK Copyright © 2000-present Newegg Inc. 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
documentation files (the “Software”), to deal in the Software without restriction, including without limitation the 
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
**/

using System.Collections.Generic;
using System.Xml.Serialization;

using Newegg.Marketplace.SDK.Base.Util;
using Newtonsoft.Json;
namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class SubmitShipment
    {
        public int OrderNumber { get; set; }

        public int ShippingCarrierCode { get; set; }

        public int ShippingServiceCode { get; set; }

       [JsonIgnore] [XmlIgnore]
        public int? ShippingLabelServiceCode
        {
            get
            {
                int code;
                if (string.IsNullOrWhiteSpace(ShippingServiceCode.ToString())
                    || string.Equals(ShippingServiceCode.ToString(), "-1", System.StringComparison.InvariantCultureIgnoreCase)
                    || !int.TryParse(ShippingServiceCode.ToString(), out code))
                {
                    return null;
                }
                return code;
            }
            set { }
        }

        public string ShipFromFirstName { get; set; }

        public string ShipFromLastName { get; set; }

        public string ShipFromPhoneNumber { get; set; }

        public string ShipFromAddress1 { get; set; }

        public string ShipFromAddress2 { get; set; }

        public string ShipFromCityName { get; set; }

        public string ShipFromStateCode { get; set; }

        public string ShipFromZipCode { get; set; }

        public string ShipFromCountryCode { get; set; }

        [XmlArrayItem("Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        public List<SubmitPackage> PackageList { get; set; }

      
    }
}
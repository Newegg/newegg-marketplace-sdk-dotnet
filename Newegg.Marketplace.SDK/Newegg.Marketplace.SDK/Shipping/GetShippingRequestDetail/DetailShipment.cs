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

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class DetailShipment
    {
        [XmlElement("CustomerName", Order = 1)]
        public string CustomerName { get; set; }

        [XmlElement("CustomerPhoneNumber", Order = 2)]
        public string CustomerPhoneNumber { get; set; }

        [XmlElement("CustomerEmailAddress", Order = 3)]
        public string CustomerEmailAddress { get; set; }

        [XmlElement("ShipToAddress1", Order = 4)]
        public string ShipToAddress1 { get; set; }

        [XmlElement("ShipToAddress2", Order = 5)]
        public string ShipToAddress2 { get; set; }

        [XmlElement("ShipToCityName", Order = 6)]
        public string ShipToCityName { get; set; }

        [XmlElement("ShipToStateCode", Order = 7)]
        public string ShipToStateCode { get; set; }

        [XmlElement("ShipToZipCode", Order = 8)]
        public string ShipToZipCode { get; set; }

        [XmlElement("ShipToCountryCode", Order = 9)]
        public string ShipToCountryCode { get; set; }

        [XmlElement("ShippingCarrierCode", Order = 10)]
        public int ShippingCarrierCode { get; set; }

        [XmlElement("ShippingServiceCode", Order = 11)]
        public string ShippingServiceCode { get; set; }

        [XmlElement("ShipmentStatus", Order = 12)]
        public string ShipmentStatus { get; set; }

        [XmlElement("ErrorCode", Order = 13)]
        public string ErrorCode { get; set; }
        
        [XmlElement("ErrorMessage", Order = 14)]
        public string ErrorMessage { get; set; }

      

        [XmlElement("ShipDate", Order = 15)]
        public string ShipDate
        {
            get
            {
                if (this.ShipDateObj.HasValue)
                {
                    return this.ShipDateObj.Value.ToString("MM\\/dd\\/yyyy HH:mm:ss");
                }
                return string.Empty;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ShipDateObj = null;
                    return;
                }
                this.ShipDateObj = DateTime.Parse(value);
            }
        }
        [XmlIgnore]
        [JsonIgnore]
        public DateTime? ShipDateObj { get; set; }
        
        [XmlElement("PartneredEstimate", Order = 16)]
        public DetailPartneredEstimate PartneredEstimate { get; set; }

        [XmlElement("ShipFromFirstName", Order = 17)]
        public string ShipFromFirstName { get; set; }

        [XmlElement("ShipFromLastName", Order = 18)]
        public string ShipFromLastName { get; set; }

        [XmlElement("ShipFromPhoneNumber", Order = 19)]
        public string ShipFromPhoneNumber { get; set; }

        [XmlElement("ShipFromAddress1", Order = 20)]
        public string ShipFromAddress1 { get; set; }

        [XmlElement("ShipFromAddress2", Order = 21)]
        public string ShipFromAddress2 { get; set; }

        [XmlElement("ShipFromCityName", Order = 22)]
        public string ShipFromCityName { get; set; }

        [XmlElement("ShipFromStateCode", Order = 23)]
        public string ShipFromStateCode { get; set; }

        [XmlElement("ShipFromZipCode", Order = 24)]
        public string ShipFromZipCode { get; set; }

        [XmlElement("ShipFromCountryCode", Order = 25)]
        public string ShipFromCountryCode { get; set; }


        [XmlArrayItem("Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        [XmlArray("PackageList", Order = 26)]
        public List<DetailPackage> PackageList { get; set; }

        

    }
}
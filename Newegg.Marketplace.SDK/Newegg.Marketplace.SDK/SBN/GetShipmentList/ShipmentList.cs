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

using Newegg.Marketplace.SDK.Base.Util;
using Newtonsoft.Json;


namespace Newegg.Marketplace.SDK.SBN.Model
{
    public class ShipmentList
    {
        public ShipmentList()
        {
            this.PackageList = new List<ShipmentPackage>();
            this.ItemList = new List<ShipmentItem>();
        }

        [XmlIgnore, JsonIgnore]
        public Guid TransactionID { get; set; }

        public string ShipmentID { get; set; }

        public string Status { get; set; }

        public string CreateDate { get; set; }
       
        public string LastEditDate { get; set; }
        
        public string ShipFrom { get; set; }

        public string ShipToWarehouseCode { get; set; }

        public string ShipToAddress1 { get; set; }

        public string ShipToAddress2 { get; set; }

        public string ShipToCityName { get; set; }

        public string ShipToStateCode { get; set; }

        public string ShipToZipCode { get; set; }

        public string ShipToCountryCode { get; set; }
      
        public int ShippingMethodCode { get; set; }

        public int? ShippingCarrierCode { get; set; }
        public bool ShouldSerializeShippingCarrierCode()
        {
            return this.ShippingCarrierCode.HasValue;
        }

        public string OtherCarrierName { get; set; }

        [XmlArrayItem(ElementName = "Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]
        public List<ShipmentPackage> PackageList { get; set; }

        [XmlArrayItem(ElementName = "Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<ShipmentItem> ItemList { get; set; }
        
    }
}

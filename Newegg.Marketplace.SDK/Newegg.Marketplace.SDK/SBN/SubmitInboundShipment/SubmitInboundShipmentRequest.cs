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
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.SBN.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class SubmitInboundShipmentRequest : RequestModel<SubmitInboundShipmentRequestBody>
    {
        public SubmitInboundShipmentRequest()
        {
            this.OperationType = "SubmitShipmentRequest";
        }
    }

    public class SubmitInboundShipmentRequestBody
    {
        public SubmitInboundShipment Shipment { get; set; }
    }

    public class SubmitInboundShipment
    {

        public string SellerShipmentRefNumber { get; set; }

        public string ShipmentID { get; set; }
        public int ActionCode { get; set; }
        public string ShipFromAddress1 { get; set; }
        public string ShipFromAddress2 { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromZipcode { get; set; }
        public string ShipFromCountry { get; set; }
        public string ShipFromPhoneNumber { get; set; }
        public string ShipToWarehouseCode { get; set; }
   
        public int ShippingMethodCode { get; set; }
        
        public int? ShippingCarrierCode { get; set; }
        public bool ShouldSerializeShippingCarrierCode()
        {
            return this.ShippingCarrierCode.HasValue;
        }
        public string OtherCarrierName { get; set; }
       

        [XmlArrayItem(ElementName="Package"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Package")]    
        public List<SubmitShipmentPackage> PackageList { get; set; }
        [XmlArrayItem(ElementName = "Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<SubmitInboundShipmentItem> ItemList { get; set; }
    }

    
    public class SubmitInboundShipmentItem
    {
        [XmlElement("SellerPartNumber"), XmlIgnore]
        public string SellerPartNumber { get; set; }
        [XmlElement("SellerPartNumber"), JsonIgnore]
        public XmlNode CDATASellerPartNumber
        {
            get
            {
                if (string.IsNullOrEmpty(SellerPartNumber))
                    return null;
                return new XmlDocument().CreateCDataSection(SellerPartNumber);
            }
            set { SellerPartNumber = value.Value; }
        }
        public int Quantity { get; set; }

        public int? NumberofPackage { get; set; }
        public bool ShouldSerializeNumberofPackage()
        {
            return this.NumberofPackage.HasValue;
        }

        [XmlElement("ORM-D")]
        [JsonProperty("ORM-D")]
        public int? ORM_D{get;set;}
        public bool ShouldSerializeORM_D()
        {
            return this.ORM_D.HasValue;
        }

        public string MSDSURL{get;set;}
    }




    public class SubmitShipmentPackage
    {
        public string TrackingNumber { get; set; }
        public decimal PackageWeight { get; set; }
        public decimal PackageLength { get; set; }
        public decimal PackageHeight { get; set; }
        public decimal PackageWidth { get; set; }
    }
}

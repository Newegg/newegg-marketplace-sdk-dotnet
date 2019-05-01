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

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.SBN.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetInboundShipmentPlanResponse : ResponseModel<GetInboundShipmentPlanResponseBody>
    {
        public GetInboundShipmentPlanResponse()
        {
            OperationType = "GetPlanSuggestionResponse";
        }
    }

    public class GetInboundShipmentPlanResponseBody
    {
        public GetInboundShipmentPlanResponseBody()
        {
            ShipmentList = new List<ShipmentSuggestion>();
        }

        [XmlArrayItem(ElementName = "Shipment"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Shipment")]
        public List<ShipmentSuggestion> ShipmentList { set; get; }
    }

    public class ShipmentSuggestion
    {
        public string ShipToWarehouseCode { set; get; }

        public string ShipToAddress1 { set; get; }

        public string ShipToAddress2 { set; get; }

        public string ShipToCityName { set; get; }

        public string ShipToStateCode { set; get; }

        public string ShipToZipCode { set; get; }

        public string ShipToCountryCode { set; get; }

        [XmlArrayItem(ElementName = "Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<SuggestionItem> ItemList { set; get; }
    }

    public class SuggestionItem
    {
        public string SellerPartNumber { set; get; }

        public string NeweggItemNumber { set; get; }

        public int Quantity { set; get; }

        public int? NumberofCartons { set; get; }

        public bool ShouldSerializeNumberofCartons()
        {
            return NumberofCartons.HasValue;
        }
    }
}

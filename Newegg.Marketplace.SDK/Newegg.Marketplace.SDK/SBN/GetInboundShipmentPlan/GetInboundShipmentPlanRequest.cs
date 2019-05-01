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
    public class GetInboundShipmentPlanRequest : RequestModel<GetInboundShipmentPlanRequestBody>
    {
        public GetInboundShipmentPlanRequest()
        {
            OperationType = "GetPlanSuggestionRequest";
        }
    }

    public class GetInboundShipmentPlanRequestBody
    {
        public PlanSuggestion PlanSuggestion { set; get; }
    }

    public class PlanSuggestion
    {
        [XmlArrayItem(ElementName = "Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public List<PlanItem> ItemList { set; get; }
    }

    public class PlanItem
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

        public int PlannedQuantity { set; get; }

        public int QuantityPerCarton { set; get; }
    }
}

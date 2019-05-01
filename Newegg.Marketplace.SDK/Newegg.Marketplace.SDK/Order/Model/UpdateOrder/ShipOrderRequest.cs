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


using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Newegg.Marketplace.SDK.Order.Model
{
    [XmlRoot("UpdateOrderStatus")]
    public class ShipOrderRequest : UpdateOrderStatusRequest
    {
        public ShipOrderRequest() : base()
        { }
        public ShipOrderRequest(ShipmentInfo shipmentInfo, Base.APIFormat apiformat) :
            base(OrderAction.ShipOrder)
        {
            Value = new ShipOrderInfo(shipmentInfo);
        }

        [XmlIgnore]
        public ShipOrderInfo Value { get; set; }
        [XmlElement("Value"), JsonIgnore]
        public System.Xml.XmlNode CDATAValue
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(new SDK.Base.Util.XmlSerializer().Serialize<ShipmentInfo>(Value.Shipment, true, true));
            }
            set { }
        }

        public class ShipOrderInfo
        {
            public ShipOrderInfo() { }
            public ShipOrderInfo(ShipmentInfo shipmentInfo)
            {
                Shipment = shipmentInfo;
            }

            public ShipmentInfo Shipment { get; set; }
        }
    }
}

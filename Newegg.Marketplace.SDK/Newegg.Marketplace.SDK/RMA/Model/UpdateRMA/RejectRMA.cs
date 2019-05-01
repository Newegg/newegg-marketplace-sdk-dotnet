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
using System.Collections.Generic;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.RMA.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class RejectRMARequest : RequestModel<RejectRMARequestBody>
    {
        public RejectRMARequest()
        {
            OperationType = "RejectRMARequest";
        }
    }
    public class RejectRMARequestBody
    {
        public RejectRMARequestInfo RejectRMAInfo { get; set; }
        public class RejectRMARequestInfo
        {
            public int RMANumber { get; set; }

            public RejectRMAReason? RejectReason { get; set; }
            public bool ShouldSerializeRejectReason()
            {
                return RejectReason.HasValue;
            }

            public RejectRMAShipCarrier? ShipCarrier { get; set; }
            public bool ShouldSerializeShipCarrier()
            {
                return ShipCarrier.HasValue;
            }

            public string OtherShipCarrier { get; set; }
            public string ShipService { get; set; }

            [XmlArrayItem("TrackingNumber"), JsonConverter(typeof(JsonMoreLevelSeConverter), "TrackingNumber")]
            public List<string> TrackingNumberList { get; set; }
        }
    }

    [XmlRoot("NeweggAPIResponse"), JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggAPIResponse")]
    public class RejectRMAResponse : UpdateRMAResponse
    {

    }
}

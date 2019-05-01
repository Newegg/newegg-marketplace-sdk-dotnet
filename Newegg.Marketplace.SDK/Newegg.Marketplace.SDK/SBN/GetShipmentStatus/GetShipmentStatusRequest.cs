
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
    [XmlRoot("NeweggAPIRequest")]
    public class GetShipmentStatusRequest : RequestModel<GetShipmentStatusRequestBody>
    {
        public GetShipmentStatusRequest()
        {
            this.OperationType = "GetShipmentStatusRequest";
        }
    }

    public class GetShipmentStatusRequestBody
    {

       // [XmlElement("GetRequestStatus")]
        public GetShipmentStatusRequestSBN GetRequestStatus { get; set; }
    }

    public class GetShipmentStatusRequestSBN
    {
        [XmlArrayItem(ElementName = "RequestID"), JsonConverter(typeof(JsonMoreLevelSeConverter), "RequestID")]
        public List<string> RequestIDList { get; set; }

        int maxCount = 100;//GQC:100/PRD:100
        public int MaxCount
        {
            get
            {
                return maxCount;
            }
            set
            {
                if (value >= 100 || value <= 0)
                    maxCount = 100;
                else maxCount = value;
            }
        }
        public int? ActionCode { get; set; }
        public bool ShouldSerializeActionCode()
        {
            return ActionCode.HasValue;
        }
        public string RequestStatus { get; set; }

        public string RequestDateFrom { get; set; }

        public string RequestDateTo { get; set; }
    }
}





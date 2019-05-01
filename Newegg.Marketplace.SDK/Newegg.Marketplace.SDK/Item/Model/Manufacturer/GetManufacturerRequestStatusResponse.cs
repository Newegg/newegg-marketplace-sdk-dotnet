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

using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetManufacturerRequestStatusResponse : ResponseModel<GetManufacturerRequestStatusResponseBody>
    {
        public GetManufacturerRequestStatusResponse()
        {
            OperationType = "GetManufacturerStatusResponse";
        }

    }

    public class GetManufacturerRequestStatusResponseBody
    {

        [XmlArrayItem(ElementName = "Manufacturer")]
        public List<MftProcessStatus> ManufacturerList { get; set; }
    }

    public class MftProcessStatus
    {

        #region OringinalManufactureName

        // [XmlIgnore]
        public string RequestName { get; set; }

        //[XmlElement("RequestName"), JsonIgnore]
        //public XmlNode CDATARequesName
        //{
        //    get { return new XmlDocument().CreateCDataSection(RequestName); }
        //    set { }
        //}
        #endregion

        #region ApprovedName

        //  [XmlIgnore]
        public string ApprovedName { get; set; }

        //[XmlElement("ApprovedName"), JsonIgnore]
        //public XmlNode CDATAApprovedName
        //{
        //    get { return new XmlDocument().CreateCDataSection(ApprovedName); }
        //    set { }
        //}
        #endregion
        public string Status { get; set; }
        public string RequestDate { get; set; }
        public string ProcessDate { get; set; }

        #region DeclineReason
        // [XmlIgnore]
        public string DeclineReason { get; set; }

        //[XmlElement("DeclineReason"), JsonIgnore]
        //public XmlNode CDATADeclineReason
        //{
        //    get { return new XmlDocument().CreateCDataSection(DeclineReason); }
        //    set { }
        //}
        #endregion
    }
}

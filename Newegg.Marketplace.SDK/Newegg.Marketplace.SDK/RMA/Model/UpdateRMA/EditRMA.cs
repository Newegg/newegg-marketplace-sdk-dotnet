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
using System.Xml;
using System;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.RMA.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class EditRMARequest : RequestModel<EditRMARequestBody>
    {
        public EditRMARequest()
        {
            OperationType = "EditRMARequest";
        }
    }
    public class EditRMARequestBody
    {
        public EditRMARequestInfo EditRMAInfo { get; set; }
        public class EditRMARequestInfo
        {
            public string RMANumber { get; set; }

            public RMAType? RMAType { get; set; }
            public bool ShouldSerializeRMAType()
            {
                return RMAType.HasValue;
            }

            public string SellerRMANumber { get; set; }
            public string RMANote { get; set; }

            [XmlArrayItem("RMATransaction"), JsonConverter(typeof(JsonMoreLevelSeConverter), "RMATransaction")]
            public List<RMATransactionInfo> RMATransactionList { get; set; }

            public class RMATransactionInfo
            {
                [XmlIgnore]
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
                public int ReturnQuantity { get; set; }

                public decimal? ReturnUnitPrice { get; set; }
                public bool ShouldSerializeReturnUnitPrice()
                {
                    return ReturnUnitPrice.HasValue;
                }

                public decimal? RefundShippingPrice { get; set; }
                public bool ShouldSerializeRefundShippingPrice()
                {
                    return RefundShippingPrice.HasValue;
                }

                public RMAReason? RMAReason { get; set; }
                public bool ShouldSerializeRMAReason()
                {
                    return RMAReason.HasValue;
                }
            }
        }
    }

    [XmlRoot("NeweggAPIResponse"), JsonConverter(typeof(JsonMoreLevelDeConverter), "NeweggAPIResponse")]
    public class EditRMAResponse : UpdateRMAResponse
    {

    }

    public class UpdateRMAResponse : ResponseModel<UpdateRMAResponseBody>
    {
    }
    public class UpdateRMAResponseBody
    {
        public UpdateRMAResponseRMAInfo RMAInfo { get; set; }
        public class UpdateRMAResponseRMAInfo
        {
            public string RMANumber { get; set; }
            public RMAType? RMAType { get; set; }
            public string RMATypeDescription { get; set; }
            public string SourceSONumber { get; set; }
            public string SellerRMANumber { get; set; }
            public string IssueUser { get; set; }
            [XmlElement("RMAShipMethod"), JsonProperty("RMAShipMethod")]
            public string _RMAShipMethod { get; set; }
            [XmlIgnore, JsonIgnore]
            public RMAShipMethods? RMAShipMethod
            {
                get
                {
                    if (string.IsNullOrEmpty(_RMAShipMethod))
                        return null;
                    return CommonManager.GetXmlEnum<RMAShipMethods>(_RMAShipMethod);
                }
                set { }
            }

            public string RMAShipMethodDescription { get; set; }
            public string RMANote { get; set; }

            [XmlArrayItem("RMATransaction"), JsonConverter(typeof(JsonMoreLevelDeConverter), "RMATransaction")]
            public List<RMATransactionInfo> RMATransactionList { get; set; }

            public class RMATransactionInfo
            {
                public string SellerPartNumber { get; set; }
                public int ReturnQuantity { get; set; }

                [XmlElement("ReturnUnitPrice"), JsonProperty("ReturnUnitPrice")]
                public string _ReturnUnitPrice { get; set; }
                [XmlIgnore, JsonIgnore]
                public decimal? ReturnUnitPrice
                {
                    get
                    {
                        if (string.IsNullOrEmpty(_ReturnUnitPrice))
                            return null;
                        return decimal.Parse(_ReturnUnitPrice);
                    }
                    set { }
                }

                [XmlElement("RefundShippingPrice"), JsonProperty("RefundShippingPrice")]
                public string _RefundShippingPrice { get; set; }
                [XmlIgnore, JsonIgnore]
                public decimal? RefundShippingPrice
                {
                    get
                    {
                        if (string.IsNullOrEmpty(_RefundShippingPrice))
                            return null;
                        return decimal.Parse(_RefundShippingPrice);
                    }
                    set { }
                }

                public RMAReason RMAReason { get; set; }
                public string RMAReasonDescription { get; set; }
            }
        }
    }
}

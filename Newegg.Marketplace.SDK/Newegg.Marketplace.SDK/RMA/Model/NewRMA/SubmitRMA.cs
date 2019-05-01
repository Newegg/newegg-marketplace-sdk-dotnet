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

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.RMA.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class SubmitRMARequest : RequestModel<SubmitRMARequestBody>
    {
        public SubmitRMARequest()
        {
            OperationType = "IssueRMARequest";
        }
    }
    public class SubmitRMARequestBody
    {
        public SubmitRMAInfo IssueRMA { get; set; }
        public class SubmitRMAInfo
        {
            public RMAType? RMAType { get; set; }
            public bool ShouldSerializeRMAType()
            {
                return RMAType.HasValue;
            }

            public int SourceSONumber { get; set; }
            public string SellerRMANumber { get; set; }

            public RMADiffShippedByPartyAction? DiffShippedByPartyAction { get; set; }
            public bool ShouldSerializeDiffShippedByPartyAction()
            {
                return DiffShippedByPartyAction.HasValue;
            }

            public SubmitRMARequestAutoReceiveMark? AutoReceiveMark { get; set; }
            public bool ShouldSerializeAutoReceiveMark()
            {
                return AutoReceiveMark.HasValue;
            }

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
    public class SubmitRMAResponse : ResponseModel<SubmitRMAResponseBody>
    {
    }
    public class SubmitRMAResponseBody
    {
        public SubmitRMAResponseRMAInfo RMAInfo { get; set; }
        public class SubmitRMAResponseRMAInfo
        {
            public string RMANumber { get; set; }
            public RMAType RMAType { get; set; }
            public string RMATypeDescription { get; set; }
            public string SellerRMANumber { get; set; }
            public string IssueUser { get; set; }
            public string RMADate { get; set; }
            public RMAStatus RMAStatus { get; set; }
            public string RMAStatusDescription { get; set; }
            public RMAShipMethods RMAShipMethod { get; set; }
            public string RMAShipMethodDescription { get; set; }
            public string OrderNumber { get; set; }
            public string OrderDate { get; set; }
            public string InvoiceNumber { get; set; }
            public decimal OrderAmount { get; set; }
            public decimal AvailableRefundAmount { get; set; }
            public string RMAProcessedBy { get; set; }
            public string RMAReceiveDate { get; set; }
            public string RMANote { get; set; }
            public decimal PriorRefundAmount { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public string CustomerEmailAddress { get; set; }
            public string ShipToAddress1 { get; set; }
            public string ShipToAddress2 { get; set; }
            public string ShipToCityName { get; set; }
            public string ShipToStateCode { get; set; }
            public string ShipToZipCode { get; set; }
            public string ShipToCountryCode { get; set; }
            public string ShipToLastName { get; set; }
            public string ShipToFirstName { get; set; }
            public string ShipToCompany { get; set; }

            [XmlArrayItem("RMATransaction"), JsonConverter(typeof(JsonMoreLevelDeConverter), "RMATransaction")]
            public List<RMATransactionInfo> RMATransactionList { get; set; }

            public class RMATransactionInfo
            {
                public string SellerPartNumber { get; set; }
                public string MfrPartNumber { get; set; }
                public string NeweggItemNumber { get; set; }
                public string Description { get; set; }
                public decimal UnitPrice { get; set; }
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

                public RMAShipBy ShippedBy { get; set; }
                public RMAReason RMAReason { get; set; }
                public string RMAReasonDescription { get; set; }
            }
        }
    }
}

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
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.Report.Model

{
    [XmlRoot("NeweggAPIResponse")]
    public class GetRMAListReportResponse : ResponseModel<GetRMAListReportResponseBody>
    {

        public string sellerID { get; set; }
        public GetRMAListReportResponse()
        {
            OperationType = "GetRMAListInfoResponse";
        }
        public string Memo { get; set; }

    }

    public class GetRMAListReportResponseBody
    {
        [DataMember(Order = 0)]
        public GetReportPageInfo PageInfo { get; set; }

        [DataMember(Order = 1)]
        public string RequestID { get; set; }

        [DataMember(Order = 2)]
        public string RequestDate { get; set; }



        [XmlArrayItem("RMAInfo"), JsonConverter(typeof(JsonMoreLevelSeConverter), "RMAInfo")]
        [DataMember(Order = 3)]
        public List<GetRMAOrderInfo> RMAInfoList { get; set; }
    }



    public class GetRMAOrderInfo
    {
        public string SellerID { get; set; }
        public int RMANumber { get; set; }
        public ReportRMAType RMAType { get; set; }
        public string RMATypeDescription { get; set; }
        public string SellerRMANumber { get; set; }
        public string ReplacementOrderNumber { get; set; }
        public string RMADate { get; set; }
        public RMAReportStatus RMAStatus { get; set; }
        public string RMAStatusDescription { get; set; }
        public string LastEditDate { get; set; }
        public string LastEditUser { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public int InvoiceNumber { get; set; }

        [XmlElement("OrderAmount"), JsonProperty("OrderAmount")]
        public string _OrderAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? OrderAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_OrderAmount))
                    return null;
                return decimal.Parse(_OrderAmount);
            }
            set { }
        }

        public string RMAProcessedBy { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string RMAReceiveDate { get; set; }
        public string RMANote { get; set; }
        public string RefundGSTorHSTAmount { get; set; }
        public string RefundPSTorQSTAmount { get; set; }

        [XmlArrayItem("RMATransaction"), JsonConverter(typeof(JsonMoreLevelDeConverter), "RMATransaction")]
        public List<RMATransactionInfo> RMATransactionList { get; set; }
        public class RMATransactionInfo
        {
            public string SellerPartNumber { get; set; }
            public string MfrPartNumber { get; set; }
            public string NeweggItemNumber { get; set; }
            public string Description { get; set; }

            [XmlElement("UnitPrice"), JsonProperty("UnitPrice")]
            public string _UnitPrice { get; set; }
            [XmlIgnore, JsonIgnore]
            public decimal? UnitPrice
            {
                get
                {
                    if (string.IsNullOrEmpty(_UnitPrice))
                        return null;
                    return decimal.Parse(_UnitPrice);
                }
                set { }
            }
           public RAMReplacementInfo ReplacementInfo { get; set; }

        }
    }

    public class RAMReplacementInfo
    {
        public int? ItemReturnQty { get; set; }
        public bool ShouldSerializeItemReturnQty()
        {
            return ItemReturnQty.HasValue;
        }
        public int? ItemRefundPerQty { get; set; }
        public bool ShouldSerializeItemRefundPerQty()
        {
            return ItemRefundPerQty.HasValue;
        }

        [XmlElement("ItemShippingRefund"), JsonProperty("ItemShippingRefund")]
        public string _ItemShippingRefund { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ItemShippingRefund
        {
            get
            {
                if (string.IsNullOrEmpty(_ItemShippingRefund))
                    return null;
                return decimal.Parse(_ItemShippingRefund);
            }
            set { }
        }

        [XmlElement("RMATotalRefund"), JsonProperty("RMATotalRefund")]
        public string _RMATotalRefund { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? RMATotalRefund
        {
            get
            {
                if (string.IsNullOrEmpty(_RMATotalRefund))
                    return null;
                return decimal.Parse(_RMATotalRefund);
            }
            set { }
        }

        public int RefundReason { get; set; }
        public string RMAReasonDescription { get; set; }

        public ReportRAMShippedBy ShippedBy { get; set; }

        public int RMAShipMethod { get; set; }
        public string RMAShipMethodDescription { get; set; }

        public int ReplacementReason { get; set; }

        public string ReplacementReasonDescription { get; set; }



        [XmlElement("AvailableRefundAmount"), JsonProperty("AvailableRefundAmount")]
        public string _AvailableRefundAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? AvailableRefundAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_AvailableRefundAmount))
                    return null;
                return decimal.Parse(_AvailableRefundAmount);
            }
            set { }
        }

        [XmlElement("PriorRefundAmount"), JsonProperty("PriorRefundAmount")]
        public string _PriorRefundAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PriorRefundAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_PriorRefundAmount))
                    return null;
                return decimal.Parse(_PriorRefundAmount);
            }
            set { }
        }
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


    }
}

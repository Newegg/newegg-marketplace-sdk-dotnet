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
    public class OrderListReportResponse : ResponseModel<OrderListReportResponseBody>
    {
        public string sellerID { get; set; }
        public OrderListReportResponse()
        {
            OperationType = "GetOrderInfoResponse";
        }
        public string Memo { get; set; }
       
    }

    public class OrderListReportResponseBody
    {
        [DataMember(Order = 0)]
        public GetReportPageInfo PageInfo { get; set; }

        [DataMember(Order = 1)]
        public string RequestID { get; set; }

        [DataMember(Order = 2)]
       
        public string RequestDate { get; set; }


        [XmlArrayItem("OrderInfo"), JsonConverter(typeof(JsonMoreLevelSeConverter), "OrderInfo")]
        [DataMember(Order = 3)]
        public List<GetOrderInfo> OrderInfoList { get; set; }
    }
   

    [DataContract(Name = "OrderInfo")]
    public class GetOrderInfo
    {
        public string SellerID { get; set; }
        public int OrderNumber { get; set; }
        public string SellerOrderNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public bool OrderDownloaded { get; set; }
        public string OrderDate { get; set; }
        public ReportOrderStatus OrderStatus { get; set; }
        public string OrderStatusDescription { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCityName { get; set; }
        public string ShipToStateCode { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCountryCode { get; set; }
        public string ShipService { get; set; }
        public string ShipToFirstName { get; set; }
        public string ShipToLastName { get; set; }
        public string ShipToCompany { get; set; }

      

        [XmlElement("OrderItemAmount"), JsonProperty("OrderItemAmount")]
        public string _OrderItemAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? OrderItemAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_OrderItemAmount))
                    return null;
                return decimal.Parse(_OrderItemAmount);
            }
            set { }
        }
      
        [XmlElement("ShippingAmount"), JsonProperty("ShippingAmount")]
        public string _ShippingAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ShippingAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_ShippingAmount))
                    return null;
                return decimal.Parse(_ShippingAmount);
            }
            set { }
        }
       
        [XmlElement("DiscountAmount"), JsonProperty("DiscountAmount")]
        public string _DiscountAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? DiscountAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_DiscountAmount))
                    return null;
                return decimal.Parse(_DiscountAmount);
            }
            set { }
        }
    
        [XmlElement("GSTorHSTAmount"), JsonProperty("GSTorHSTAmount")]
        public string _GSTorHSTAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? GSTorHSTAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_GSTorHSTAmount))
                    return null;
                return decimal.Parse(_GSTorHSTAmount);
            }
            set { }
        }
        [XmlElement("PSTorQSTAmount"), JsonProperty("PSTorQSTAmount")]
        public string _PSTorQSTAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PSTorQSTAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_PSTorQSTAmount))
                    return null;
                return decimal.Parse(_PSTorQSTAmount);
            }
            set { }
        }

        [XmlElement("EHFAmount"), JsonProperty("EHFAmount")]
        public string _EHFAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? EHFAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_EHFAmount))
                    return null;
                return decimal.Parse(_EHFAmount);
            }
            set { }
        }

        public int OrderQty { get; set; }

        [XmlElement("RefundAmount"), JsonProperty("RefundAmount")]
        public string _RefundAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? RefundAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_RefundAmount))
                    return null;
                return decimal.Parse(_RefundAmount);
            }
            set { }
        }
        [XmlElement("SalesTax"), JsonProperty("SalesTax")]
        public string _SalesTax { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? SalesTax
        {
            get
            {
                if (string.IsNullOrEmpty(_SalesTax))
                    return null;
                return decimal.Parse(_SalesTax);
            }
            set { }
        }

        [XmlElement("VATTotal"), JsonProperty("VATTotal")]
        public string _VATTotal { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? VATTotal
        {
            get
            {
                if (string.IsNullOrEmpty(_VATTotal))
                    return null;
                return decimal.Parse(_VATTotal);
            }
            set { }
        }

        [XmlElement("DutyTotal"), JsonProperty("DutyTotal")]
        public string _DutyTotal { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? DutyTotal
        {
            get
            {
                if (string.IsNullOrEmpty(_DutyTotal))
                    return null;
                return decimal.Parse(_DutyTotal);
            }
            set { }
        }

        [XmlElement("RecyclingFeeAmount"), JsonProperty("RecyclingFeeAmount")]
        public string _RecyclingFeeAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? RecyclingFeeAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_RecyclingFeeAmount))
                    return null;
                return decimal.Parse(_RecyclingFeeAmount);
            }
            set { }
        }

        [XmlElement("OrderTotalAmount"), JsonProperty("OrderTotalAmount")]
        public string _OrderTotalAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? OrderTotalAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_OrderTotalAmount))
                    return null;
                return decimal.Parse(_OrderTotalAmount);
            }
            set { }
        }

        public bool IsAutoVoid { get; set; }
        public ReportSalesChannel SalesChannel { get; set; }
        public ReportFulfillmentOption FulfillmentOption { get; set; }

        [XmlArrayItem("ItemInfo"), JsonConverter(typeof(JsonMoreLevelSeConverter), "ItemInfo")]
        public List<GetOrderItemInfo> ItemInfoList { get; set; }

      
    }

    public class GetOrderItemInfo
    {
        public string SellerPartNumber { get; set; }
        public string NeweggItemNumber { get; set; }
        public string MfrPartNumber { get; set; }
        public string UPCCode { get; set; }
        public string Description { get; set; }
        public int OrderedQty { get; set; }
        public int ShippedQty { get; set; }

      
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
       
        [XmlElement("ExtendUnitPrice"), JsonProperty("ExtendUnitPrice")]
        public string _ExtendUnitPrice { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ExtendUnitPrice
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendUnitPrice))
                    return null;
                return decimal.Parse(_ExtendUnitPrice);
            }
            set { }
        }

        [XmlElement("ExtendShippingCharge"), JsonProperty("ExtendShippingCharge")]
        public string _ExtendShippingCharge { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ExtendShippingCharge
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendShippingCharge))
                    return null;
                return decimal.Parse(_ExtendShippingCharge);
            }
            set { }
        }

        [XmlElement("ExtendSalesTax"), JsonProperty("ExtendSalesTax")]
        public string _ExtendSalesTax { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ExtendSalesTax
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendSalesTax))
                    return null;
                return decimal.Parse(_ExtendSalesTax);
            }
            set { }
        }

        [XmlElement("ExtendVAT"), JsonProperty("ExtendVAT")]
        public string _ExtendVAT { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ExtendVAT
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendVAT))
                    return null;
                return decimal.Parse(_ExtendVAT);
            }
            set { }
        }

        [XmlElement("ExtendDuty"), JsonProperty("ExtendDuty")]
        public string _ExtendDuty { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ExtendDuty
        {
            get
            {
                if (string.IsNullOrEmpty(_ExtendDuty))
                    return null;
                return decimal.Parse(_ExtendDuty);
            }
            set { }
        }
        

        public OrderReportStatus Status { get; set; }
        public string StatusDescription { get; set; }
        public string AutoRegWarranty { get; set; }

    }



}

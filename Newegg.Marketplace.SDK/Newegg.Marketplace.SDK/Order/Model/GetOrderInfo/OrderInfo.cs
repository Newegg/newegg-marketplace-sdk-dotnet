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
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Order.Model
{
    public class OrderInfo
    {
        public string SellerOrderNumber { get; set; }
        public string CustomerPONumber { get; set; }
        public string SellerCustomerNumber { get; set; }
        public string SellerID { get; set; }
        public string OrderNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public bool OrderDownloaded { get; set; }
        public string OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
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
        public decimal OrderItemAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal DiscountAmount { get; set; }

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

        public decimal RefundAmount { get; set; }
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
        }



        public decimal OrderTotalAmount { get; set; }
        public int OrderQty { get; set; }
        public bool IsAutoVoid { get; set; }
        public OrderSalesChannel? SalesChannel { set; get; }
        public OrderFulfillmentOption? FulfillmentOption { set; get; }

        public string OnTimeShipDueDate { get; set; }
        public string DeliverDueDate { get; set; }

        [XmlArrayItem("ItemInfo")]
        [JsonConverter(typeof(JsonMoreLevelDeConverter), "ItemInfo")]
        public List<OrderItemInfo> ItemInfoList { get; set; }

        [XmlArrayItem("PackageInfo")]
        [JsonConverter(typeof(JsonMoreLevelDeConverter), "PackageInfo")]
        public List<OrderPackageInfo> PackageInfoList { get; set; }
    }

    public class OrderItemInfo
    {
        public string SellerPartNumber { get; set; }
        public string NeweggItemNumber { get; set; }
        public string MfrPartNumber { get; set; }
        public string UPCCode { get; set; }
        public string Description { get; set; }
        public int OrderedQty { get; set; }
        public int ShippedQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ExtendUnitPrice
        {
            get
            {
                return OrderedQty * UnitPrice;
            }
        }

        [XmlElement("UnitShippingCharge"), JsonProperty("UnitShippingCharge")]
        public string _UnitShippingCharge { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? UnitShippingCharge
        {
            get
            {
                if (string.IsNullOrEmpty(_UnitShippingCharge))
                    return null;
                return decimal.Parse(_UnitShippingCharge);
            }
        }

        public decimal? ExtendShippingCharge
        {
            get
            {
                if (string.IsNullOrEmpty(_UnitShippingCharge))
                    return null;
                return OrderedQty * decimal.Parse(_UnitShippingCharge);
            }
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
        }

        public int Status { get; set; }

        public string StatusDescription { get; set; }
        public string AutoRegWarranty { get; set; }
        
    }

    public class OrderPackageInfo
    {
        public string PackageType { get; set; }
        public string ShipCarrier { get; set; }
        public string ShipService { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipDate { get; set; }
        public string ShipFromAddress { get; set; }
        public string ShipFromAddress2 { get; set; }
        public string ShipFromCity { get; set; }
        public string ShipFromState { get; set; }
        public string ShipFromZipCode { get; set; }
        public string ShipFromName { get; set; }

        [XmlArrayItem("ItemInfo")]
        [JsonConverter(typeof(JsonMoreLevelDeConverter), "ItemInfo")]
        public List<OrderPackageItemInfo> ItemInfoList { get; set; }
    }

    public class OrderPackageItemInfo
    {
        public string SellerPartNumber { get; set; }
        public string MfrPartNumber { get; set; }
        public int ShippedQty { get; set; }
        public string FufillmentCenter { get; set; }
    }
}
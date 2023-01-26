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
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Newegg.Marketplace.SDK.Report.Model
{
    public enum CancelOrderReason
    {
        OutOfStock = 24,
        CustomerRequestedToCancel = 72,
        PriceError = 73,
        UnableToFulfillOrder = 74
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportKeywordsType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        OrderNumber,
        [XmlEnum("2"), EnumMember(Value = "2")]
        InvoiceNumber,
        [XmlEnum("3"), EnumMember(Value = "3")]
        CustomerName,
        /// <summary>
        ///  only available for version=307
        /// </summary>
        [XmlEnum("4"), EnumMember(Value = "4")]
        SellerRMANumber,
        [XmlEnum("5"), EnumMember(Value = "5")]
        NeweggItemNumber,
        [XmlEnum("6"), EnumMember(Value = "6")]
        CustomerPhoneNumber,
        [XmlEnum("7"), EnumMember(Value = "7")]
        TitleDescription,
        [XmlEnum("8"), EnumMember(Value = "8")]
        Manufacturer,
        [XmlEnum("9"), EnumMember(Value = "9")]
        SellerOrderNumber
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportStatus
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Unshipped,
        [XmlEnum("1"), EnumMember(Value = "1")]
        PartiallyShipped,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Shipped,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Invoiced,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Voided,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Closed,
        [XmlEnum("6"), EnumMember(Value = "6")]
        Processing
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAReportStatus
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Open,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Received,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Rejected,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Voided,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Closed,
        [XmlEnum("6"), EnumMember(Value = "6")]
        Processing
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        SBN,
        [XmlEnum("2"), EnumMember(Value = "2")]
        SBS,
        [XmlEnum("3"), EnumMember(Value = "3")]
        NISP
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportVoidSoon
    {
        [XmlEnum("24"), EnumMember(Value = "24")]
        Hours24,
        [XmlEnum("48"), EnumMember(Value = "48")]
        Hours48
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportInfoType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        SBN,
        [XmlEnum("2"), EnumMember(Value = "2")]
        SBS,
        [XmlEnum("3"), EnumMember(Value = "3")]
        MultiChannel
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportPremier
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        PremierOrderOnly,
        [XmlEnum("2"), EnumMember(Value = "2")]
        NoPremierOrder
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportStatusType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Unshipped,
        [XmlEnum("1"), EnumMember(Value = "1")]
        PartiallyShipped,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Shipped,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Invoiced,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Void,
        [XmlEnum("99"), EnumMember(Value = "99")]
        Processing,
        [XmlEnum("-1"), EnumMember(Value = "-1")]
        UnKnown
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportSalesChannel
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        NeweggOrder,
        [XmlEnum("1"), EnumMember(Value = "1")]
        MultiChannelOrder,
        [XmlEnum("2"), EnumMember(Value = "2")]
        ReplacementOrder
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportFulfillmentOption
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        ShipBySeller,
        [XmlEnum("1"), EnumMember(Value = "1")]
        ShipByNewegg
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportRAMShippedBy
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        SBS_ShipBySeller,
        [XmlEnum("1"), EnumMember(Value = "1")]
        SBN_ShipByNewegg
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportReplacementReason
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Carrier_damage,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Defective,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Incompatible,
        [XmlEnum("3"), EnumMember(Value = "3")]
        No_longer_needed,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Not_match_what_we_show,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Ordered_wrong_item,
        [XmlEnum("6"), EnumMember(Value = "6")]
        Sent_wrong_item,
        [XmlEnum("7"), EnumMember(Value = "7")]
        MultiChannelFee,
        [XmlEnum("8"), EnumMember(Value = "8")]
        Unsatisfied,
        [XmlEnum("9"), EnumMember(Value = "9")]
        Personal_Reason_Or_Other_Reason
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportTransactionType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Order,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Refund,
        [XmlEnum("3"), EnumMember(Value = "3")]
        CreditRequest,
        [XmlEnum("4"), EnumMember(Value = "4")]
        ChargeBack,
        [XmlEnum("5"), EnumMember(Value = "5")]
        MonthlyFee,
        [XmlEnum("6"), EnumMember(Value = "6")]
        FulfillByNeweggFee,
        [XmlEnum("7"), EnumMember(Value = "7")]
        MultiChannelFee,
        [XmlEnum("8"), EnumMember(Value = "8")]
        RMAProcessingFee,
        [XmlEnum("9"), EnumMember(Value = "9")]
        TaxandDuty,
        [XmlEnum("10"), EnumMember(Value = "10")]
        StorageFee,
        [XmlEnum("11"), EnumMember(Value = "11")]
        RMABuyoutFee,
        [XmlEnum("12"), EnumMember(Value = "12")]
        AdjustmentFee,
        [XmlEnum("13"), EnumMember(Value = "13")]
        MonthlyFeeByCC,
        [XmlEnum("14"), EnumMember(Value = "14")]
        SBNInboundFee,
        [XmlEnum("15"), EnumMember(Value = "15")]
        MerchandisingFee,
        [XmlEnum("16"), EnumMember(Value = "16")]
        NeweggPremierFee,
        [XmlEnum("17"), EnumMember(Value = "17")]
        NeweggShippingLabelFee,
        [XmlEnum("18"), EnumMember(Value = "18")]
        ReturnAndDisposalFee,
        [XmlEnum("19"), EnumMember(Value = "19")]
        NeweggRelabelingFee
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportCondition
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        New,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Refurbished,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Used_LikeNew,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Used_VeryGood,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Used_Good,
        [XmlEnum("6"), EnumMember(Value = "6")]
        Used_Acceptable
    }


    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportProcessedBy
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Seller,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Newegg,
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportOrderStatus
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Unshipped,
        [XmlEnum("1"), EnumMember(Value = "1")]
        PartiallyShipped,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Shipped,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Invoiced,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Voided
    }

    public enum OrderAction
    {
        CancelOrder = 1,
        ShipOrder = 2
    }
    public enum ItemStatus
    {
        NULL = 0,
        Unshipped = 'U',
        Shipped = 'S',
        Canceled = 'C',
    }

    public enum OrderStatus
    {
        Unshipped = 'U',
        PartiallyShipped = 'P',
        Shipped = 'S',
        Invoiced = 'I',
        Voided = 'V'
    }

    public enum ReportStatusOfInt32
    {
        Unshipped = 1,
        PartiallyShipped = 2,
        Shipped = 3,
        Invoiced = 4,
        Voided = 5
    }


    public enum ReportRequestStatus
    {
        SUBMITTED,
        IN_PROGRESS,
        FINISHED,
        CANCELLED
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportFulfillType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Fulfill_by_Seller,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Fulfill_by_Newegg
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportFileType
    {
        [XmlEnum("TXT"), EnumMember(Value = "TXT")]
        TXT,
        [XmlEnum("CSV"), EnumMember(Value = "CSV")]
        CSV,
        [XmlEnum("XLS"), EnumMember(Value = "XLS")]
        XLS
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReportRMAType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Replacement,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Refund
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderReportStatus
    {

        [XmlEnum("1"), EnumMember(Value = "1")]
        Unshipped,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Shipped,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Cancelled
    }
    public enum ReportRequestType
    {
        ITEM_DATA,
        INVENTORY_AND_PRICE_DATA,
        ORDER_SHIP_NOTICE_DATA,
        MULTICHANNEL_ORDER_DATA,
        ORDER_LIST_REPORT,
        SETTLEMENT_SUMMARY_REPORT,
        SETTLEMENT_TRASACTION_REPORT,
        SETTLEMENT_TRANSACTION_REPOR,
        SETTLEMENT_TRANSACTION_REPORT,
        DAILY_INVENTORY_REPORT,
        RMA_LIST_REPORT,
        //RMA,
        COURTESYREFUND,
        SBN_SUBMIT_SHIPMENT_DATA,
        ITEM_SUBSCRIPTION,

        VOLUME_DISCOUNT_DATA,
        ITEM_LOOKUP,
        ITEM_COUNTRY_RESTRICTION_DATA,
        ITEM_PROMOTION_DATA,
        INVENTORY_DATA,
        PRICE_DATA,
        INTERNATIONAL_INVENTORY_REPORT,
        INTERNATIONAL_PRICE_REPORT,
        ITEM_PREMIER_MARK_DATA,
        PREMIER_ITEM_REPORT,
        ORDER_NEWEGG_SHIPPINGLABEL,

        CAPROP65_REPORT,
        ITEM_CAPROP65_DATA,

        ITEM_CHINATAXSETTING_DATA,
        ITEM_CHINATAXSETTING_REPORT,
        ITEM_BASIC_INFO_REPORT
    }





}
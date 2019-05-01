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

namespace Newegg.Marketplace.SDK.RMA.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Replacement,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Refund
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMADiffShippedByPartyAction
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        Convert_to_Refund_with_Restocking_Fee,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Convert_to_Refund_without_Restocking_Fee,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Split_into_Two_RMAs
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubmitRMARequestAutoReceiveMark
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        No,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Yes
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAReason
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        CarrierDamage,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Defective,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Incompatible,
        [XmlEnum("4"), EnumMember(Value = "4")]
        NoLongerNeeded,
        [XmlEnum("5"), EnumMember(Value = "5")]
        NotMatchWhatWeShow,
        [XmlEnum("6"), EnumMember(Value = "6")]
        OrderedWrongItem,
        [XmlEnum("7"), EnumMember(Value = "7")]
        SentWrongItem,
        [XmlEnum("8"), EnumMember(Value = "8")]
        Unsatisfied,
        [XmlEnum("9"), EnumMember(Value = "9")]
        OtherReason
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAStatus
    {
        /// <summary>
        /// Default
        /// </summary>
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
    public enum RMAShipMethods
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        Super_Saver_7to14_business_days,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Standard_Shipping_5to7_business_days,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Expedited_Shipping_3to5_business_days,
        [XmlEnum("4"), EnumMember(Value = "4")]
        TwotoDay_Shipping_2_business_days,
        [XmlEnum("5"), EnumMember(Value = "5")]
        OnetoDay_Shipping_Next_day,
        [XmlEnum("6"), EnumMember(Value = "6")]
        International_Economy_Shipping_8to15_business_days,
        [XmlEnum("7"), EnumMember(Value = "7")]
        International_Standard_Shipping_5to7_business_days,
        [XmlEnum("8"), EnumMember(Value = "8")]
        International_Expedited_Shipping_3to5_business_days,
        [XmlEnum("9"), EnumMember(Value = "9")]
        International_TwotoDay_Shipping_2_business_days,
        [XmlEnum("10"), EnumMember(Value = "10")]
        APO_FPO_Military_ONLY,
        [XmlEnum("11"), EnumMember(Value = "11")]
        Newegg_Premier_3_Days,
        [XmlEnum("12"), EnumMember(Value = "12")]
        Newegg_Premier_2_Days,
        [XmlEnum("13"), EnumMember(Value = "13")]
        Newegg_Premier_Next_Day
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RejectRMAReason
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        Remove_Missing_Serial_Number_Graffiti,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Warranty_Expired,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Physical_Damage,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Item_Missing_Parts_Missing,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Wrong_Item_Returned
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RejectRMAShipCarrier
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        UPS,
        [XmlEnum("2"), EnumMember(Value = "2")]
        FedEx,
        [XmlEnum("3"), EnumMember(Value = "3")]
        DHL,
        [XmlEnum("4"), EnumMember(Value = "4")]
        USPS,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Other
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GetRMAInfoKeywordsType
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        RMANumber,
        [XmlEnum("2"), EnumMember(Value = "2")]
        OrderNumber,
        [XmlEnum("3"), EnumMember(Value = "3")]
        CustomerName,
        /// <summary>
        ///  only available for version=307
        /// </summary>
        [XmlEnum("4"), EnumMember(Value = "4")]
        SellerRMANumber
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAProcessedBy
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Seller,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Newegg
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CourtesyRefundKeywordsType
    {
        /// <summary>
        /// Default
        /// </summary>
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        CourtesyRefundID,
        [XmlEnum("2"), EnumMember(Value = "2")]
        OrderNumber,
        [XmlEnum("3"), EnumMember(Value = "3")]
        CustomerName
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CourtesyRefundStatus
    {
        /// <summary>
        /// Default
        /// </summary>
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Open,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Void,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Close
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CourtesyRefundReason
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        NegativeCustomerFeedback,
        [XmlEnum("2"), EnumMember(Value = "2")]
        PricingError,
        [XmlEnum("3"), EnumMember(Value = "3")]
        WrongItemInformation,
        [XmlEnum("4"), EnumMember(Value = "4")]
        ShippingDelay,
        [XmlEnum("5"), EnumMember(Value = "5")]
        PackageNotReceived,
        [XmlEnum("6"), EnumMember(Value = "6")]
        CustomerCourtesy,
        [XmlEnum("-1"), EnumMember(Value = "-1")]
        UnKnow
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CourtesyRefundRequestStatus
    {
        [XmlEnum("ALL"), EnumMember(Value = "ALL")]
        ALL,
        [XmlEnum("SUBMITTED"), EnumMember(Value = "SUBMITTED")]
        SUBMITTED,
        [XmlEnum("IN_PROGRESS"), EnumMember(Value = "IN_PROGRESS")]
        IN_PROGRESS,
        [XmlEnum("FINISHED"), EnumMember(Value = "FINISHED")]
        FINISHED,
        [XmlEnum("CANCELLED"), EnumMember(Value = "CANCELLED")]
        CANCELLED,
        [XmlEnum("FAILED"), EnumMember(Value = "FAILED")]
        FAILED
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum RMAShipBy
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Seller,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Newegg
    }
}

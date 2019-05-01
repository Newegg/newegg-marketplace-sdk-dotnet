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


namespace Newegg.Marketplace.SDK.Item.Model
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedCheckoutMAP
    {
        [XmlEnum("True"), EnumMember(Value = "True")]
        True,
        [XmlEnum("False"), EnumMember(Value = "False")]
        False
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CheckoutMAP
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        False,
        [XmlEnum("1"), EnumMember(Value = "1")]
        True

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FulfillType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Fulfill_by_Seller,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Fulfill_by_Newegg
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FileType
    {
        [XmlEnum("TXT"), EnumMember(Value = "TXT")]
        TXT,
        [XmlEnum("CSV"), EnumMember(Value = "CSV")]
        CSV,
        [XmlEnum("XLS"), EnumMember(Value = "XLS")]
        XLS
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
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
    public enum Condition
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
    public enum ShipKeywordsType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        ShipmentID,
        [XmlEnum("2"), EnumMember(Value = "2")]
        NeweggItemNumber,
        [XmlEnum("3"), EnumMember(Value = "3")]
        SellerPartNumber

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShipStatus
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Preparing,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Shipped,
        [XmlEnum("3"), EnumMember(Value = "3")]
        Received,
        [XmlEnum("4"), EnumMember(Value = "4")]
        Partially_Received,
        [XmlEnum("5"), EnumMember(Value = "5")]
        Manually_closed,
        [XmlEnum("6"), EnumMember(Value = "6")]
        Voided
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FreeShipping
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Default,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Free_Shipping
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemQueryType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        NewEggItemNumber,
        [XmlEnum("1"), EnumMember(Value = "1")]
        SellerPartNumber,
        [XmlEnum("2"), EnumMember(Value = "2")]
        UPCCode
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemCondition
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
    public enum FulfillmentOption
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        ShipBySeller,
        [XmlEnum("1"), EnumMember(Value = "1")]
        ShipByNewegg,
        [XmlEnum("2"), EnumMember(Value = "2")]
        All
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemActive
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        InActive,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Active

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemPriceActive
    {
        [XmlEnum("1"), EnumMember(Value = "1")]
        Activate_item,
        [XmlEnum("0"), EnumMember(Value = "0")]
        Deactivate_item
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Create_arranty,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Update_arranty,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Delete_arranty
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemIsRestricted
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        No,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Yes
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemActionCode
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Create,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Void
    }
}

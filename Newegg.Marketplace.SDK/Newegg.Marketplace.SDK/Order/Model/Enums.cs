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

namespace Newegg.Marketplace.SDK.Order.Model
{
    public enum CancelOrderReason
    {
        OutOfStock = 24,
        CustomerRequestedToCancel = 72,
        PriceError = 73,
        UnableToFulfillOrder = 74
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddOrderStatus
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
        All
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderDownload
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        False,
        [XmlEnum("1"), EnumMember(Value = "1")]
        True
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
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
    public enum OrderVoidSoon
    {
        [XmlEnum("24"), EnumMember(Value = "24")]
        Hours24,
        [XmlEnum("48"), EnumMember(Value = "48")]
        Hours48
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderInfoType
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
    public enum OrderPremier
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        All,
        [XmlEnum("1"), EnumMember(Value = "1")]
        PremierOrderOnly,
        [XmlEnum("2"), EnumMember(Value = "2")]
        NoPremierOrder
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatusType
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
    public enum OrderSalesChannel
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        NeweggOrder,
        [XmlEnum("1"), EnumMember(Value = "1")]
        MultiChannelOrder,
        [XmlEnum("2"), EnumMember(Value = "2")]
        ReplacementOrder
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderFulfillmentOption
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        ShipBySeller,
        [XmlEnum("1"), EnumMember(Value = "1")]
        ShipByNewegg
    }

    public enum OrderAction
    {
        CancelOrder = 1,
        ShipOrder = 2
    }
}

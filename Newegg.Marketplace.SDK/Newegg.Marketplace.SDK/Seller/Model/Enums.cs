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

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerMembership
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        Standard = 0,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Professional = 1,
        [XmlEnum("2"), EnumMember(Value = "2")]
        Enterprise = 2
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerWarehouseType
    {
        /// <summary>
        /// Newegg Warehouse
        /// </summary>
        [XmlEnum("1"), EnumMember(Value = "1")]
        Newegg = 1,

        /// <summary>
        /// Seller Warehouse
        /// </summary>
        [XmlEnum("0"), EnumMember(Value = "0")]
        Seller = 0
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerStatus
    {
        [XmlEnum("Active"), EnumMember(Value = "Active")]
        Active,
        [XmlEnum("Suspended"), EnumMember(Value = "Suspended")]
        Suspended,
        [XmlEnum("InActive"), EnumMember(Value = "InActive")]
        InActive,
        [XmlEnum("Terminated"), EnumMember(Value = "Terminated")]
        Terminated,
        [XmlEnum("Closed"), EnumMember(Value = "Closed")]
        Closed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerSubcategoryAdvancedSearch
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        No = 0,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Yes = 1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerSubcategoryGroupBy
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        No = 0,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Yes = 1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerSubcategoryRequired
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        No = 0,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Yes = 1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SellerSubcategoryStatusEnabled
    {
        [XmlEnum("0"), EnumMember(Value = "0")]
        NotEnabled = 0,
        [XmlEnum("1"), EnumMember(Value = "1")]
        Enabled = 1
    }
}

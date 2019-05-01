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


namespace Newegg.Marketplace.SDK.SBN.Model
{

    public enum RequestStatus
    {
        ALL,
        SUBMITTED,
        IN_PROGRESS,
        FINISHED,
        CANCELLED
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
}

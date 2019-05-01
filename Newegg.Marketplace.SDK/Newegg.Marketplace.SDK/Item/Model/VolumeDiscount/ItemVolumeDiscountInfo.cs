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
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Item.Model
{
    public class ItemVolumeDiscountInfo
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
        public string NeweggItemNumber { get; set; }

        public VolumeDiscountVolumeActivation? VolumeActivation { get; set; }
        public bool ShouldSerializeVolumeActivation()
        {
            return VolumeActivation.HasValue;
        }


        [XmlArrayItem("Tier")]
        [JsonConverter(typeof(JsonMoreLevelSeConverter), "Tier")]
        public List<TierInfo> DiscountSetting { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum VolumeDiscountVolumeActivation
        {
            [XmlEnum("True"), EnumMember(Value = "True")]
            True,
            [XmlEnum("False"), EnumMember(Value = "False")]
            False
        }
    }
}

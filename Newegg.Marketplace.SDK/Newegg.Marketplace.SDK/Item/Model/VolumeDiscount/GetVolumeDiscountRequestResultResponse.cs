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
using System.Xml.Serialization;
using System.Collections.Generic;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetVolumeDiscountRequestResultResponse : ResponseModel<GetVolumeDiscountRequestResultResponseBody>
    {
    }

    public class GetVolumeDiscountRequestResultResponseBody
    {
        public GetItemVolumeDiscountInfo ItemVolumeDiscountInfo { get; set; }
    }

    public class GetItemVolumeDiscountInfo
    {
        public string SellerPartNumber { get; set; }
        public string NeweggItemNumber { get; set; }

        [XmlArrayItem("Tier"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Tier")]        
        public List<VolumeTierInfo> DiscountSetting { get; set; }
    }
    public class VolumeTierInfo
    {
        public int Priority { get; set; }
        public int Quantity { get; set; }

        [XmlElement("SellingPrice"), JsonProperty("SellingPrice")]
        public string _SellingPriceMAP { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? SellingPrice
        {
            get
            {
                if (string.IsNullOrEmpty(_SellingPriceMAP))
                    return null;
                return decimal.Parse(_SellingPriceMAP);
            }
            set { }
        }

        public int EnableFreeShipping { get; set; }
    }
}

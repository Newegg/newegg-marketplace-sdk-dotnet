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

using System;
using System.Xml.Serialization;

using Newtonsoft.Json;
namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class PackageItem
    {
        private Guid? itmId = null;
        /// <summary>
        /// PackageId,如果不设置值,则会创建一个值
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public Guid ItemId
        {
            get
            {
                if (!itmId.HasValue)
                    itmId = Guid.NewGuid();
                return itmId.Value;
            }
            set
            {
                itmId = value;
            }
        }

        [XmlElement("SellerPartNumber", Order = 1)]
        public string SellerPartNumber { get; set; }

        [XmlElement("Quantity", Order = 2)]
        public int Quantity { get; set; }
    }
}
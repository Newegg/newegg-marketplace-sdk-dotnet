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


using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

using Newegg.Marketplace.SDK.Base.Util;
using Newtonsoft.Json;

namespace Newegg.Marketplace.SDK.Order.Model
{
    public class PackageInfo
    {
        public string TrackingNumber { get; set; }
        public string ShipCarrier { get; set; }
        public string ShipService { get; set; }

        [XmlArray]
        [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        public ItemInfo[] ItemList { get; set; }

        public override string ToString()
        {
            return ToElement(true).ToString();
        }

        public virtual XElement ToElement(bool includeHeader)
        {
            var package =
                new XElement("Package",
                             new XElement("TrackingNumber", TrackingNumber.ToStringWithNonSpace()),
                             new XElement("ShipCarrier", ShipCarrier.ToStringWithNonSpace()),
                             new XElement("ShipService", ShipService.ToStringWithNonSpace()),
                             new XElement("ItemList",
                                          from item in ItemList
                                          select item.ToElement(false)));

            return package;
        }
    }
}

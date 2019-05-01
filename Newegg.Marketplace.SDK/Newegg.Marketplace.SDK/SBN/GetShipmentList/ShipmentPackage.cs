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

using Newtonsoft.Json;



namespace Newegg.Marketplace.SDK.SBN.Model
{
    public class ShipmentPackage
    {
        public ShipmentPackage()
        {
           
        }

        public string TrackingNumber { get; set; }

       
        [XmlElement("PackageWeight"), JsonProperty("PackageWeight")]
        public string _PackageWeight { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PackageWeight
        {
            get
            {
                if (string.IsNullOrEmpty(_PackageWeight))
                    return null;
                return decimal.Parse(_PackageWeight);
            }
            set { }
        }

       
        [XmlElement("PackageLength"), JsonProperty("PackageLength")]
        public string _PackageLength { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PackageLength
        {
            get
            {
                if (string.IsNullOrEmpty(_PackageLength))
                    return null;
                return decimal.Parse(_PackageLength);
            }
            set { }
        }

        [XmlElement("PackageHeight"), JsonProperty("PackageHeight")]
        public string _PackageHeight { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PackageHeight
        {
            get
            {
                if (string.IsNullOrEmpty(_PackageHeight))
                    return null;
                return decimal.Parse(_PackageHeight);
            }
            set { }
        }

       
        [XmlElement("PackageWidth"), JsonProperty("PackageWidth")]
        public string _PackageWidth { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PackageWidth
        {
            get
            {
                if (string.IsNullOrEmpty(_PackageWidth))
                    return null;
                return decimal.Parse(_PackageWidth);
            }
            set { }
        }
    }
}

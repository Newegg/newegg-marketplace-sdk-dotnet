
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

using System.Xml.Linq;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Order.Model
{
    public class ItemInfo
    {
        public string SellerPartNumber { get; set; }
        public string NeweggItemNumber { get; set; }
        public int ShippedQty { get; set; }
    

        public override string ToString()
        {
            return ToElement(true).ToString();
        }

        public virtual XElement ToElement(bool includeHeader)
        {
            var item =
               new XElement("Item",
                            //includeHeader
                            //    ? new XElement("Header",
                            //                   new XElement("CompanyCode", CompanyCode.ToStringWithNonSpace()),
                            //                   new XElement("CountryCode", CountryCode.ToStringWithNonSpace()),
                            //                   new XElement("Language", LanguageCode.ToStringWithNonSpace()),
                            //                   new XElement("SellerID", SellerID.ToStringWithNonSpace()),
                            //                   new XElement("SONumber", SONumber.ToStringWithNonSpace()))
                            //    : null,
                            //new XElement("TransactionNumber", TransactionNumber.ToStringWithNonSpace()),
                            //new XElement("PackageNumber", PackageNumber.ToStringWithNonSpace()),
                            new XElement("SellerPartNumber", SellerPartNumber.ToStringWithNonSpace()),
                            new XElement("NeweggItemNumber", NeweggItemNumber.ToStringWithNonSpace()),
                            //new XElement("ManufacturerPartNumber", ManufacturerPartNumber.ToStringWithNonSpace()),
                            new XElement("ShippedQty", ShippedQty.ToStringWithNonSpace())
                            //new XElement("ItemDescription", ItemDescription.ToStringWithNonSpace()),
                            //new XElement("UPCCode", UPCCode.ToStringWithNonSpace()),
                            //new XElement("ExtendDescription", ExtendDescription.ToStringWithNonSpace()),
                            //new XElement("ItemDescription", ItemDescription.ToStringWithNonSpace())
                   );

            return item;
        }
    }
}

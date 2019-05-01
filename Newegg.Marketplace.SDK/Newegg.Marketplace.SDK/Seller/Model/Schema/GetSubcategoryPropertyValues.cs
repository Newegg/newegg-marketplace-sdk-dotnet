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
using System.Xml.Serialization;

using Newegg.Marketplace.SDK.Model;

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetSubcategoryPropertyValuesRequest : RequestModel<GetSubcategoryPropertyValuesRequestBody>
    {
        public GetSubcategoryPropertyValuesRequest()
        {
            OperationType = "GetSellerPropertyValueRequest";
        }
        public GetSubcategoryPropertyValuesRequest(string propertyName, int? subcategoryID = null)
        {
            OperationType = "GetSellerPropertyValueRequest";
            RequestBody = new GetSubcategoryPropertyValuesRequestBody()
            {
                SubcategoryID = subcategoryID,
                PropertyName = propertyName
            };
        }
    }
    public class GetSubcategoryPropertyValuesRequestBody
    {
        public int? SubcategoryID { get; set; }
        public bool ShouldSerializeSubcategoryID()
        {
            return SubcategoryID.HasValue;
        }

        public string PropertyName { get; set; }
    }

    [XmlRoot("NeweggAPIResponse")]
    public class GetSubcategoryPropertyValuesResponse : ResponseModel<GetSubcategoryPropertyValuesResponseBody>
    {

    }
    public class GetSubcategoryPropertyValuesResponseBody
    {
        public List<PropertyInfo> PropertyInfoList { get; set; }

        public class PropertyInfo
        {
            public int SubcategoryID { get; set; }
            public string SubcategoryName { get; set; }
            public string PropertyName { get; set; }
            public SellerSubcategoryAdvancedSearch IsAdvancedSearch { get; set; }
            public SellerSubcategoryGroupBy IsGroupBy { get; set; }
            public SellerSubcategoryRequired IsRequired { get; set; }
            [XmlArrayItem("PropertyValue")]
            public List<string> PropertyValueList { get; set; }
        }
    }
}

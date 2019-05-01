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

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.Item.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class ManufacturerLookupForInternationalCountryRequest : RequestModel<ManufacturerLookupForInternationalCountryRequestBody>
    {
        public ManufacturerLookupForInternationalCountryRequest()
        {
            OperationType = "GetManufacturerRequest";
        }
    }

    public class ManufacturerLookupForInternationalCountryRequestBody
    {
        private int pageSize = 100;

        public int PageIndex { get; set; }
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value >= 100)
                    pageSize = 100;
                else pageSize = value;
            }
        }

        public string RestrictedCountryCode { get; set; }

        public CountryRequestCriteria RequestCriteria { get; set; }

        public ManufacturerLookupForInternationalCountryRequestBody()
        {
            PageIndex = 1;
            PageSize = 100;
        }
        
    }

    public class CountryRequestCriteria
    {
      
        public string ManufacturerName { get; set; }

        private string createDateFrom = "";
        private string createDateTo = "";

        public string CreatedDateFrom
        {
            get
            {
                return string.IsNullOrEmpty(createDateFrom) ? createDateFrom : CommonManager.DealDateFrom(createDateFrom);
            }
            set
            {
                createDateFrom = value;
            }
        }

        public string CreatedDateTo
        {
            get
            {
                return string.IsNullOrEmpty(createDateTo) ? createDateTo : CommonManager.DealDateTo(createDateTo);
            }
            set
            {
                createDateTo = value;
            }
        }
    }
}

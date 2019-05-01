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

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Order.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetAdditionalOrderInformationResponse : ResponseModel<GetAddOrderInfoRespBody>
    {
        public string Memo { set; get; }
    }

    public class GetAddOrderInfoRespBody
    {
        public CommondPageInfo PageInfo { set; get; }
        [XmlArrayItem("AddOrderInfo")]
        public List<AddOrderInfo> AddOrderInfoList { set; get; }

        public class AddOrderInfo
        {
            public string OrderNumber { get; set; }
            public string CustomerNumber { get; set; }
            public string RecipientIDType { get; set; }
            public string RecipientIDNumber { get; set; }
            public NISPShippingAddress NISPOriginalInfo { get; set; }
            public OriginalShippingAddess OriginalInputInfo { get; set; }
            public string AddInfo1 { get; set; }
            public string AddInfo2 { get; set; }
            public string AddInfo3 { get; set; }
            public string TaxDutyTypeChina { get; set; }
            public string ImportTypeChina { get; set; }
            public string IDCopyFront { get; set; }
            public string IDCopyBack { get; set; }
        }

        public class NISPShippingAddress
        {
            public string NISPOriFirstName { get; set; }
            public string NISPOriLastName { get; set; }
            public string NISPOriCompanyName { get; set; }
            public string NISPOriAddress1 { get; set; }
            public string NISPOriAddress2 { get; set; }
            public string NISPOriCity { get; set; }
            public string NISPOriState { get; set; }
            public string NISPOriZipCode { get; set; }
            public string NISPOriCountryCode { get; set; }
            public string NISPOriPhoneNumber { get; set; }
        }

        public class OriginalShippingAddess
        {
            public string OriginalFirstName { set; get; }
            public string OriginalLastName { set; get; }
            public string OriginalCompanyName { set; get; }
            public string OriginalAddress1 { set; get; }
            public string OriginalAddress2 { set; get; }
            public string OriginalCity { set; get; }
            public string OriginalState { set; get; }
            public string OriginalZipCode { set; get; }
            public string OriginalCountryCode { set; get; }
            public string OriginalPhoneNumber { set; get; }
        }
    }
}

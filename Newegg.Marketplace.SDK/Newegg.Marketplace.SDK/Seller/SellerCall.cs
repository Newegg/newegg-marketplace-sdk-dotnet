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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog.Config;

using Newegg.Marketplace.SDK.Base;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Seller.Model;


namespace Newegg.Marketplace.SDK.Seller
{
    public class SellerCall : BaseCall
    {
        public SellerCall(BaseAPIClient apiClient) : base(apiClient)
        {

        }

        public async Task<SellerStatusCheckResponse> SellerStatusCheck(string version = null, ConnectSetting connectSetting = null)
        {
            var request = CreateRequest();
            request.URI = "sellermgmt/seller/accountstatus";
            if (!string.IsNullOrEmpty(version))
                request.QueryParams.Add("version", version);

            var response = await client.GetAsync(request, connectSetting);
            var result = await ProcessResponse<SellerStatusCheckResponse>(response);
            return result;
        }

        public async Task<GetIndustryListResponse> GetIndustryList(ConnectSetting connectSetting = null)
        {
            var request = CreateRequest();
            request.URI = "sellermgmt/seller/industry";

            var response = await client.GetAsync(request, connectSetting);
            var result = await ProcessResponse<GetIndustryListResponse>(response);
            return result;
        }

        public async Task<GetSubcategoryStatusResponse> GetSubcategoryStatus(GetSubcategoryStatusRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetSubcategoryStatusRequest>(reqModel);
            request.URI = "sellermgmt/seller/subcategory";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetSubcategoryStatusResponse>(response);
            return result;
        }

        public async Task<GetSubcategoryStatusForInternationalCountryResponse> GetSubcategoryStatusForInternationalCountry(GetSubcategoryStatusForInternationalCountryRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetSubcategoryStatusForInternationalCountryRequest>(reqModel);
            request.URI = "sellermgmt/seller/subcategory/v2";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetSubcategoryStatusForInternationalCountryResponse>(response);
            return result;
        }

        public async Task<bool> DownloadFeedSchema(string DownloadPath, DownloadFeedSchemaRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<DownloadFeedSchemaRequest>(reqModel);
            request.URI = "sellermgmt/seller/feedschema";

            var response = await client.PutAsync(request, connectSetting);
            byte[] content = await response.RawResponse.Content.ReadAsByteArrayAsync();
            System.IO.File.WriteAllBytes(DownloadPath, content);

            return true;
        }

        public async Task<GetSubcategoryPropertiesResponse> GetSubcategoryProperties(GetSubcategoryPropertiesRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetSubcategoryPropertiesRequest>(reqModel);
            request.URI = "sellermgmt/seller/subcategoryproperty";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetSubcategoryPropertiesResponse>(response);
            return result;
        }

        public async Task<GetSubcategoryPropertyValuesResponse> GetSubcategoryPropertyValues(GetSubcategoryPropertyValuesRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetSubcategoryPropertyValuesRequest>(reqModel);
            request.URI = "sellermgmt/seller/propertyvalue";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetSubcategoryPropertyValuesResponse>(response);
            return result;
        }
    }
}

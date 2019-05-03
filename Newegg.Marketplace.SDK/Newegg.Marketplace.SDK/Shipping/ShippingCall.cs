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

using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base;


namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class ShippingCall : BaseCall
    {
        public ShippingCall(BaseAPIClient apiClient) : base(apiClient)
        {
        }

        public async Task<VoidShippingResponse> VoidShippingRequest(VoidShippingRequest reqModel)
        {
            var request = CreateRequest<VoidShippingRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/voidshippingrequest";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<VoidShippingResponse>(response);
            return result;
        }

        public async Task<GetPackageListResponse> GetPackageList(GetPackageListRequest reqModel)
        {
            var request = CreateRequest<GetPackageListRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/packagelist";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetPackageListResponse>(response);
            return result;
        }

        public async Task<GetShippinLabelResponse> GetShippingLabel(GetShippingLabelRequest reqModel)
        {
            var request = CreateRequest<GetShippingLabelRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippinglabels";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetShippinLabelResponse>(response);
            return result;
        }

        public async Task<confirmShipResponse> ConfirmShippingRequest(confirmShipRequest reqModel)
        {
            var request = CreateRequest<confirmShipRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/confirmshippingrequest";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<confirmShipResponse>(response);
            return result;
        }


        public async Task<GetShippingDetailResponse> GetShippingRequestDetail(GetShippingDetailRequest reqModel)
        {
            var request = CreateRequest<GetShippingDetailRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippingdetail";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetShippingDetailResponse>(response);
            return result;
        }

        public async Task<SubmitShippingResponse> SubmitShippingRequest(SubmitShippingRequest reqModel)
        {
            var request = CreateRequest<SubmitShippingRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippingrequest";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SubmitShippingResponse>(response);
            return result;
        }



    }
}

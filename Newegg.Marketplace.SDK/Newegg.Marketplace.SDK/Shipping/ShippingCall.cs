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
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Shipping.CreateShippingLabel;
using Newegg.Marketplace.SDK.Shipping.EstimateShippingLabel;
using Newegg.Marketplace.SDK.Shipping.ReprintShippingLabel;

namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class ShippingCall : BaseCall
    {
        public ShippingCall(BaseAPIClient apiClient) : base(apiClient)
        {
        }

        [Obsolete("not support")]
        public async Task<VoidShippingResponse> VoidShippingRequest(VoidShippingRequest reqModel)
        {
            var request = CreateRequest<VoidShippingRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/voidshippingrequest";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<VoidShippingResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<GetPackageListResponse> GetPackageList(GetPackageListRequest reqModel)
        {
            var request = CreateRequest<GetPackageListRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/packagelist";

            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetPackageListResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<GetShippinLabelResponse> GetShippingLabel(GetShippingLabelRequest reqModel)
        {
            var request = CreateRequest<GetShippingLabelRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippinglabels";

            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetShippinLabelResponse>(response);
            return result;
        }

        public async Task<confirmShipResponse> ConfirmShippingRequest(confirmShipRequest reqModel)
        {
            var request = CreateRequest<confirmShipRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/confirmshippingrequest";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<confirmShipResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<GetShippingDetailResponse> GetShippingRequestDetail(GetShippingDetailRequest reqModel)
        {
            var request = CreateRequest<GetShippingDetailRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippingdetail";

            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetShippingDetailResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<SubmitShippingResponse> SubmitShippingRequest(SubmitShippingRequest reqModel)
        {
            var request = CreateRequest<SubmitShippingRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/shippingrequest";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<SubmitShippingResponse>(response);
            return result;
        }

        public async Task<CreateShippingLabelResponse> CreateShippingRequest(CreateShippingLabelRequest reqModel)
        {
            var request = CreateRequest<CreateShippingLabelRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/CreateShippingLabel";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<CreateShippingLabelResponse>(response);
            return result;
        }

        public async Task<EstimateShippingLabelResponse> EstimateShippingRequest(EstimateShippingLabelRequest reqModel)
        {
            var request = CreateRequest<EstimateShippingLabelRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/EstimateShippingLabel";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<EstimateShippingLabelResponse>(response);
            return result;
        }

        public async Task<ReprintShippingLabelResponse> ReprintShippingRequest(ReprintShippingLabelRequest reqModel)
        {
            var request = CreateRequest<ReprintShippingLabelRequest>(reqModel);
            request.URI = "shippingservice/shippinglabel/ReprintShippingLabel";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<ReprintShippingLabelResponse>(response);
            return result;
        }

    }
}

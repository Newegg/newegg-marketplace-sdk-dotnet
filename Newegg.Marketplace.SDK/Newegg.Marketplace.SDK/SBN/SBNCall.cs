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

using NLog.Config;

namespace Newegg.Marketplace.SDK.SBN.Model
{
    public class SBNCall : BaseCall
    {
        public SBNCall(BaseAPIClient apiClient) : base(apiClient)
        {

        }
        public async Task<GetInboundShipmentPlanResponse> GetInboundShipmentPlanSuggestion(GetInboundShipmentPlanRequest reqModel)
            {
                var request = CreateRequest<GetInboundShipmentPlanRequest>(reqModel);
                request.URI = "sbnmgmt/inboundshipment/plansuggestion";

                var response = await client.PutAsync(request);
                var result = await ProcessResponse<GetInboundShipmentPlanResponse>(response);
                return result;
            }


        public async Task<SubmitInboundShipmentResponse> SubmitCreateInboundShipmentRequest(SubmitInboundShipmentRequest reqModel)
        {
            var request = CreateRequest<SubmitInboundShipmentRequest>(reqModel);
            request.URI = "sbnmgmt/inboundshipment/shipmentrequest";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SubmitInboundShipmentResponse>(response);
            return result;
        }

        public async Task<SubmitVoidInboundShipmentResponse> SubmitVoidInboundShipmentRequest(SubmitVoidInboundShipmentRequest reqModel)
        {
            var request = CreateRequest<SubmitVoidInboundShipmentRequest>(reqModel);
            request.URI = "sbnmgmt/inboundshipment/shipmentrequest";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SubmitVoidInboundShipmentResponse>(response);
            return result;
        }
        
        public async Task<GetShipmentStatusResponse> GetInboundShipmentStatusRequest(GetShipmentStatusRequest reqModel)
        {
            var request = CreateRequest<GetShipmentStatusRequest>(reqModel);
            request.URI = "sbnmgmt/inboundshipment/shipmentstatus";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetShipmentStatusResponse>(response);
            return result;
        }

     
         public async Task<GetInboundShipmentResultResponse> GetInboundShipmentRequestResult(string Required, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest();
            request.URI = string.Format("sbnmgmt/inboundshipment/shipmentresult/{0}", Required);
            var response = await client.GetAsync(request, connectSetting);
            var result = await ProcessResponse<GetInboundShipmentResultResponse>(response);
            return result;
            
        }

        public async Task<GetShipmentListResponse> GetInboundShipmentList(GetShipmentListRequest reqModel)
        {
            var request = CreateRequest<GetShipmentListRequest>(reqModel);
            request.URI = "sbnmgmt/inboundshipment/shipmentlist";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetShipmentListResponse>(response);
            return result;
        }


        public async Task<GetWarehouseListResponse> GetWarehouseList(GetWarehouseListRequest reqModel)
        {
            var request = CreateRequest<GetWarehouseListRequest>(reqModel);
            request.URI = "sbnmgmt/inboundshipment/warehouse";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetWarehouseListResponse>(response);
            return result;
        }



    }

}

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

using NLog.Config;

using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Order.Model;

namespace Newegg.Marketplace.SDK.Order
{
    public class OrderCall : BaseCall
    {
        public OrderCall(BaseAPIClient apiClient) : base(apiClient)
        {

        }

        public async Task<GetOrderStatusResponse> GetOrderStatus(string OrderNumber, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest();
            request.URI = string.Format("ordermgmt/orderstatus/orders/{0}", OrderNumber);
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.GetAsync(request, connectSetting);
            var result = await ProcessResponse<GetOrderStatusResponse>(response);
            return result;
        }

        public async Task<CancelOrderResponse> CancelOrder(string OrderNumber, int? Version, CancelOrderRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<CancelOrderRequest>(reqModel);
            request.URI = string.Format("ordermgmt/orderstatus/orders/{0}", OrderNumber);
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<CancelOrderResponse>(response);
            return result;
        }

        public async Task<ShipOrderResponse> ShipOrder(string OrderNumber, int? Version, ShipOrderRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ShipOrderRequest>(reqModel);
            request.URI = string.Format("ordermgmt/orderstatus/orders/{0}", OrderNumber);
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<ShipOrderResponse>(response);
            return result;
        }


        public async Task<OrderConfirmationResponse> OrderConfirmation(OrderConfirmationRequest reqModel, ConnectSetting connectSetting = null)
        {
            var request = CreateRequest<OrderConfirmationRequest>(reqModel);
            request.URI = "ordermgmt/orderstatus/orders/confirmation";

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<OrderConfirmationResponse>(response);
            return result;
        }

        public async Task<RemoveItemResponse> RemoveItem(string OrderNumber, RemoveItemRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<RemoveItemRequest>(reqModel);
            request.URI = string.Format("ordermgmt/killitem/orders/{0}", OrderNumber);

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<RemoveItemResponse>(response);
            return result;
        }

        public async Task<GetOrderInformationResponse> GetOrderInformation(int? Version, GetOrderInformationRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetOrderInformationRequest>(reqModel);
            request.URI = "ordermgmt/order/orderinfo";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetOrderInformationResponse>(response);
            return result;
        }

        public async Task<GetSBNOrderCancellationRequestResultResponse> GetSBNOrderCancellationRequestResult(string OrderNumber, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest();
            request.URI = string.Format("ordermgmt/sbnorder/cancellationresult/{0}", OrderNumber);

            var response = await client.GetAsync(request, connectSetting);
            var result = await ProcessResponse<GetSBNOrderCancellationRequestResultResponse>(response);
            return result;
        }

        public async Task<GetAdditionalOrderInformationResponse> GetAdditionalOrderInformation(GetAdditionalOrderInformationRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetAdditionalOrderInformationRequest>(reqModel);
            request.URI = "ordermgmt/order/addorderinfo";

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<GetAdditionalOrderInformationResponse>(response);
            return result;
        }
    }
}

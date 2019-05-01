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
using Newegg.Marketplace.SDK.RMA.Model;

namespace Newegg.Marketplace.SDK.RMA
{
    public class RMACall : BaseCall
    {
        public RMACall(BaseAPIClient apiClient) : base(apiClient)
        {
        }

        public async Task<SubmitRMAResponse> SubmitRMA(SubmitRMARequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<SubmitRMARequest>(reqModel);
            request.URI = "servicemgmt/rma/newrma";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<SubmitRMAResponse>(response);
            return result;
        }

        public async Task<EditRMAResponse> EditRMA(EditRMARequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<EditRMARequest>(reqModel);
            request.URI = "servicemgmt/rma/updaterma";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<EditRMAResponse>(response);
            return result;
        }

        public async Task<RejectRMAResponse> RejectRMA(RejectRMARequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<RejectRMARequest>(reqModel);
            request.URI = "servicemgmt/rma/updaterma";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<RejectRMAResponse>(response);
            return result;
        }

        public async Task<VoidRMAResponse> VoidRMA(VoidRMARequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<VoidRMARequest>(reqModel);
            request.URI = "servicemgmt/rma/updaterma";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<VoidRMAResponse>(response);
            return result;
        }

        public async Task<ReceiveRMAResponse> ReceiveRMA(ReceiveRMARequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ReceiveRMARequest>(reqModel);
            request.URI = "servicemgmt/rma/updaterma";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<ReceiveRMAResponse>(response);
            return result;
        }

        public async Task<GetRMAInformationResponse> GetRMAInformation(GetRMAInformationRequest reqModel, int? Version = null, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetRMAInformationRequest>(reqModel);
            request.URI = "servicemgmt/rma/rmainfo";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetRMAInformationResponse>(response);
            return result;
        }

        public async Task<IssueCourtesyRefundResponse> IssueCourtesyRefund(IssueCourtesyRefundRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<IssueCourtesyRefundRequest>(reqModel);
            request.URI = "servicemgmt/courtesyrefund/new";

            var response = await client.PostAsync(request, connectSetting);
            var result = await ProcessResponse<IssueCourtesyRefundResponse>(response);
            return result;
        }

        public async Task<GetCourtesyRefundRequestStatusResponse> GetCourtesyRefundRequestStatus(GetCourtesyRefundRequestStatusRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetCourtesyRefundRequestStatusRequest>(reqModel);
            request.URI = "servicemgmt/courtesyrefund/requeststatus";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetCourtesyRefundRequestStatusResponse>(response);
            return result;
        }

        public async Task<GetCourtesyRefundInformationResponse> GetCourtesyRefundInformation(GetCourtesyRefundInformationRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetCourtesyRefundInformationRequest>(reqModel);
            request.URI = "servicemgmt/courtesyrefund/info";

            var response = await client.PutAsync(request, connectSetting);
            var result = await ProcessResponse<GetCourtesyRefundInformationResponse>(response);
            return result;
        }
    }
}

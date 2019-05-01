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


namespace Newegg.Marketplace.SDK.Report.Model
{
    public class ReportCall : BaseCall
    {
        public ReportCall(BaseAPIClient apiClient) : base(apiClient)
        {
        }
        public async Task<GetReportStatusResponse> GetReportStatus(GetReportStatusRequest reqModel)
        {
            var request = CreateRequest<GetReportStatusRequest>(reqModel);
            request.URI = "reportmgmt/report/status";

            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetReportStatusResponse>(response);
            return result;
        }

        //Submit Reports Management:
        public async Task<SubmitOrderListReportResponse> SubmitOrderListReport(SubmitOrderListReportRequest reqModel)
        {
            var request = CreateRequest<SubmitOrderListReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";          
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SubmitOrderListReportResponse>(response);
            return result;
        }

        public async Task<SettlementSummaryReportResponse> SubmitSettlementSummaryReport(SettlementSummaryReportRequest reqModel)
        {
            var request = CreateRequest<SettlementSummaryReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";            
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SettlementSummaryReportResponse>(response);
            return result;
        }


        public async Task<SettlementTransactionResponse> SubmitSettlementTransactionReport(SettlementTransactionRequest reqModel)
        {
            var request = CreateRequest<SettlementTransactionRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SettlementTransactionResponse>(response);
            return result;
        }


        public async Task<SubmitRMAListReportResponse> SubmitRMAListReport(SubmitRMAListReportRequest reqModel)
        {
            var request = CreateRequest<SubmitRMAListReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";            
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<SubmitRMAListReportResponse>(response);
            return result;
        }


        public async Task<ItemLookupResponse> SubmitItemLookupReport(ItemLookupRequest reqModel)
        {
            var request = CreateRequest<ItemLookupRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";            
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<ItemLookupResponse>(response);
            return result;
        }

        //only USA
        public async Task<DailyInventoryReportResponse> SubmitDailyInventoryReport(DailyInventoryReportRequest reqModel, int? Version = null)
        {
            var request = CreateRequest<DailyInventoryReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<DailyInventoryReportResponse>(response);
            return result;
        }

        public async Task<DailyInventoryReportB2BCANResponse> SubmitDailyInventoryReportB2BCAN(DailyInventoryReportB2BCANRequest reqModel, int? Version = null)
        {
            var request = CreateRequest<DailyInventoryReportB2BCANRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<DailyInventoryReportB2BCANResponse>(response);
            return result;
        }
        public async Task<DailyPriceReportResponse> SubmitDailyPriceReport(DailyPriceReportRequest reqModel, int? Version = null)
        {
            var request = CreateRequest<DailyPriceReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<DailyPriceReportResponse>(response);
            return result;
        }

        //only USA
        public async Task<PremierItemReportResponse> SubmitNeweggPremierItemReport(PremierItemReportRequest reqModel)
        {
            var request = CreateRequest<PremierItemReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<PremierItemReportResponse>(response);
            return result;
        }

        public async Task<CAProp65ReportResponse> SubmitCaliforniasProposition65WarningReport(CAProp65ReportRequest reqModel)
        {
            var request = CreateRequest<CAProp65ReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<CAProp65ReportResponse>(response);
            return result;
        }

        //only USA
        public async Task<ItemChinaTaxSettingReportResponse> SubmitTaxSettingReportforItemsEnabledforChina(ItemChinaTaxSettingReportRequest reqModel)
        {
            var request = CreateRequest<ItemChinaTaxSettingReportRequest>(reqModel);
            request.URI = "reportmgmt/report/submitrequest";            
            var response = await client.PostAsync(request);
            var result = await ProcessResponse<ItemChinaTaxSettingReportResponse>(response);
            return result;
        }

        //GetReportResult
        public async Task<OrderListReportResponse> GetOrderListReport(OrderListReportRequest reqModel, int? Version = null)
        {
            var request = CreateRequest<OrderListReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());//305-309
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<OrderListReportResponse>(response);
            return result;
        }

        public async Task<GetSettlementSummaryInfoResponse> GetSettlementSummaryReport(GetSettlementSummaryReportRequest reqModel)
        {
            var request = CreateRequest<GetSettlementSummaryReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";            
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetSettlementSummaryInfoResponse>(response);
            return result;
        }

        public async Task<GetSettlementTransactionReportResponse> GetSettlementTransactionReport(GetSettlementTransactionReportRequest reqModel)
        {
            var request = CreateRequest<GetSettlementTransactionReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetSettlementTransactionReportResponse>(response);
            return result;
        }

        public async Task<GetRMAListReportResponse> GetRMAListReport(GetRMAListReportRequest reqModel, int? Version = null)
        {
            var request = CreateRequest<GetRMAListReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());//305-309
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetRMAListReportResponse>(response);
            return result;
        }

        public async Task<GetItemLookupReportResponse> GetItemLookupReport(GetItemLookupReportRequest reqModel)
        {
            var request = CreateRequest<GetItemLookupReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";            
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetItemLookupReportResponse>(response);
            return result;
        }

        public async Task<GetDailyInventoryReportResponse> GetDailyInventoryReport(GetDailyInventoryReportRequest reqModel)
        {
            var request = CreateRequest<GetDailyInventoryReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetDailyInventoryReportResponse>(response);
            return result;
        }

        public async Task<GetDailyPriceReportResponse> GetDailyPriceReport(GetDailyPriceReportRequest reqModel)
        {
            var request = CreateRequest<GetDailyPriceReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetDailyPriceReportResponse>(response);
            return result;
        }

        public async Task<GetDailyInventoryReportB2bCanResponse> GetDailyInventoryReportB2bCan(GetDailyInventoryReportB2bCanRequest reqModel)
        {
            var request = CreateRequest<GetDailyInventoryReportB2bCanRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetDailyInventoryReportB2bCanResponse>(response);
            return result;
        }

        public async Task<GetNeweggPremierItemReportResponse> GetNeweggPremierItemReport(GetNeweggPremierItemReportRequest reqModel)
        {
            var request = CreateRequest<GetNeweggPremierItemReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetNeweggPremierItemReportResponse>(response);
            return result;
        }

        public async Task<CAProp65WarningReportResponse> GetCaliforniasProposition65WarningReport(CAProp65WarningReportRequest reqModel)
        {
            var request = CreateRequest<CAProp65WarningReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<CAProp65WarningReportResponse>(response);
            return result;
        }

        public async Task<GetTaxSettingReportResponse> GetTaxSettingReportforItemsEnabledforChina(GetTaxSettingReportRequest reqModel)
        {
            var request = CreateRequest<GetTaxSettingReportRequest>(reqModel);
            request.URI = "reportmgmt/report/result";
            var response = await client.PutAsync(request);
            var result = await ProcessResponse<GetTaxSettingReportResponse>(response);
            return result;
        }
    }
}

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
using Newegg.Marketplace.SDK.DataFeed.Model;
using System;

namespace Newegg.Marketplace.SDK.DataFeed
{
    public class DatafeedCall : BaseCall
    {
        public DatafeedCall(BaseAPIClient apiClient) : base(apiClient)
        {

        }

        public async Task<GetFeedStatusResponse> GetFeedStatus(GetFeedStatusRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<GetFeedStatusRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/status";

            var response = await client.PutAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<GetFeedStatusResponse>(response);
            return result;
        }

        public async Task<ItemCreationOrUpdateFeedResponse> SubmitFeed_ItemCreationOrUpdateFeed(ItemCreationOrUpdateFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemCreationOrUpdateFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemCreationOrUpdateFeedResponse>(response);
            return result;
        }

        public async Task<ExistingItemCreationFeedResponse> SubmitFeed_ExistingItemCreationFeed(ExistingItemCreationFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ExistingItemCreationFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ExistingItemCreationFeedResponse>(response);
            return result;
        }

        public async Task<ItemBasicInformationFeedResponse> SubmitFeed_ItemBasicInformationFeed(ItemBasicInformationFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemBasicInformationFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemBasicInformationFeedResponse>(response);
            return result;
        }

        public async Task<InventoryUpdateFeedResponse> SubmitFeed_InventoryUpdateFeed(InventoryUpdateFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<InventoryUpdateFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.INVENTORY_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<InventoryUpdateFeedResponse>(response);
            return result;
        }

        public async Task<PriceUpdateFeedResponse> SubmitFeed_PriceUpdateFeed(PriceUpdateFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<PriceUpdateFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.PRICE_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<PriceUpdateFeedResponse>(response);
            return result;
        }

        public async Task<InventoryAndPriceFeedResponse> SubmitFeed_InventoryAndPriceFeed(InventoryAndPriceFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<InventoryAndPriceFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.INVENTORY_AND_PRICE_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<InventoryAndPriceFeedResponse>(response);
            return result;
        }

        public async Task<OrderShipNoticeFeedResponse> SubmitFeed_OrderShipNoticeFeed(OrderShipNoticeFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<OrderShipNoticeFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ORDER_SHIP_NOTICE_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<OrderShipNoticeFeedResponse>(response);
            return result;
        }

        public async Task<MultiChannelOrderFeedResponse> SubmitFeed_MultiChannelOrderFeed(MultiChannelOrderFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<MultiChannelOrderFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.MULTICHANNEL_ORDER_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<MultiChannelOrderFeedResponse>(response);
            return result;
        }


        [Obsolete("not support")]
        public async Task<ItemSubscriptionFeedResponse> SubmitFeed_ItemSubscriptionFeed(ItemSubscriptionFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemSubscriptionFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_SUBSCRIPTION.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemSubscriptionFeedResponse>(response);
            return result;
        }

        public async Task<VolumeDiscountFeedResponse> SubmitFeed_VolumeDiscountFeed(VolumeDiscountFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<VolumeDiscountFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.VOLUME_DISCOUNT_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<VolumeDiscountFeedResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<ItemPromotionFeedResponse> SubmitFeed_ItemPromotionFeed(ItemPromotionFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemPromotionFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_PROMOTION_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemPromotionFeedResponse>(response);
            return result;
        }

        [Obsolete("not support")]
        public async Task<ItemPremierMarkFeedResponse> SubmitFeed_ItemPremierMarkFeed(ItemPremierMarkFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemPremierMarkFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_PREMIER_MARK_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemPremierMarkFeedResponse>(response);
            return result;
        }


        public async Task<ItemCAProp65FeedResponse> SubmitFeed_ItemCAProp65Feed(ItemCAProp65FeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemCAProp65FeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_CAPROP65_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemCAProp65FeedResponse>(response);
            return result;
        }

        [Obsolete("not support")]

        public async Task<ItemChinaTaxSettingFeedResponse> SubmitFeed_ItemChinaTaxSettingFeed(ItemChinaTaxSettingFeedRequest reqModel, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest<ItemChinaTaxSettingFeedRequest>(reqModel);
            request.URI = "datafeedmgmt/feeds/submitfeed";
            request.QueryParams.Add("requesttype", RequestType.ITEM_CHINATAXSETTING_DATA.ToString());

            var response = await client.PostAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<ItemChinaTaxSettingFeedResponse>(response);
            return result;
        }

        public async Task<GetFeedResultResponse> GetFeedResult(string requestID, ConnectSetting connectSetting = null, LoggingConfiguration logSetting = null)
        {
            var request = CreateRequest(APIFormat.XML);
            request.URI = string.Format("datafeedmgmt/feeds/result/{0}", requestID);

            var response = await client.GetAsync(request, connectSetting).ConfigureAwait(false);
            var result = await ProcessResponse<GetFeedResultResponse>(response);
            return result;
        }
    }
}

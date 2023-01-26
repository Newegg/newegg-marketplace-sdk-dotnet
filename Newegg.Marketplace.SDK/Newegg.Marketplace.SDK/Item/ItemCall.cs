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
using Newegg.Marketplace.SDK.Item.Model;

namespace Newegg.Marketplace.SDK.Item
{
    public class ItemCall : BaseCall
    {
        public ItemCall(BaseAPIClient apiClient) : base(apiClient)
        {

        }

        //public async Task<GetVolumeDiscountResponse> GetVolumeDiscount(GetVolumeDiscountRequest reqModel)
        //{
        //    var request = CreateRequest<GetVolumeDiscountRequest>(reqModel);
        //    request.URI = "contentmgmt/Item/VolumeDiscount";
        //    var response = await client.PutAsync(request).ConfigureAwait(false);
        //    var result = await ProcessResponse<GetVolumeDiscountResponse>(response);
        //    return result;
        //}

        public async Task<SubmitVolumeDiscountResponse> SubmitVolumeDiscount(SubmitVolumeDiscountRequest reqModel)
        {
            var request = CreateRequest<SubmitVolumeDiscountRequest>(reqModel);
            request.URI = "contentmgmt/Item/VolumeDiscount";
            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<SubmitVolumeDiscountResponse>(response);
            return result;
        }

        public async Task<SubmitManufacturerResponse> SubmitManufacturerRequest(SubmitManufacturerRequest reqModel)
        {
            var request = CreateRequest<SubmitManufacturerRequest>(reqModel);
            request.URI = "contentmgmt/manufacturer/creationrequest";
            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<SubmitManufacturerResponse>(response);
            return result;
        }


        public async Task<ManufacturerLookupResponse> ManufacturerLookup(ManufacturerLookupRequest reqModel)
        {
            var request = CreateRequest<ManufacturerLookupRequest>(reqModel);
            request.URI = "contentmgmt/manufacturer/manufacturerinfo";
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<ManufacturerLookupResponse>(response);
            return result;
        }

        public async Task<ManufacturerLookupForInternationalCountryResponse> ManufacturerLookupForInternationalCountry(ManufacturerLookupForInternationalCountryRequest reqModel)
        {
            var request = CreateRequest<ManufacturerLookupForInternationalCountryRequest>(reqModel);
            request.URI = "contentmgmt/manufacturer/manufacturerinfo/V2";
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<ManufacturerLookupForInternationalCountryResponse>(response);
            return result;
        }


        public async Task<GetManufacturerRequestStatusResponse> GetManufacturerRequestStatus(GetManufacturerRequestStatusRequest reqModel)
        {
            var request = CreateRequest<GetManufacturerRequestStatusRequest>(reqModel);
            request.URI = "contentmgmt/manufacturer/creationrequeststatus";
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetManufacturerRequestStatusResponse>(response);
            return result;
        }


        public async Task<GetVolumeDiscountRequestResultResponse> GetVolumeDiscountRequestResult(GetVolumeDiscountRequestResultRequest reqModel)
        {
            var request = CreateRequest<GetVolumeDiscountRequestResultRequest>(reqModel);
            request.URI = "contentmgmt/item/volumediscount";
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetVolumeDiscountRequestResultResponse>(response);
            return result;
        }



        //USA 
        public async Task<GetItemInternationalInventoryResponse> GetItemInternationalInventory(GetItemInternationalInventoryRequest reqModel)
        {
            var request = CreateRequest<GetItemInternationalInventoryRequest>(reqModel);           
            request.URI = "contentmgmt/item/international/inventory";      
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetItemInternationalInventoryResponse>(response);
            
            return result;
        }
       
        //B2B,CAN
        public async Task<GetItemInventoryResponse> GetItemInventory(GetItemInventoryRequest reqModel,int? Version = null)
        {
            var request = CreateRequest<GetItemInventoryRequest>(reqModel);
            request.URI = "contentmgmt/item/inventory";
            if (Version != null)
                request.QueryParams.Add("version", Version.ToString());//304
            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetItemInventoryResponse>(response);
            return result;
        }

        //USA 
        public async Task<GetInternationalItemPriceResponse> GetInternationalItemPrice(GetInternationalItemPriceRequest reqModel)
        {

            var request = CreateRequest<GetInternationalItemPriceRequest>(reqModel);
            request.URI = "contentmgmt/item/international/price";

            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetInternationalItemPriceResponse>(response);
            return result;
        }

        //B2B,CAN
        public async Task<GetItemPriceResponse> GetItemPrice(GetItemPriceRequest reqModel)
        {
            var request = CreateRequest<GetItemPriceRequest>(reqModel);
            request.URI = "contentmgmt/item/price";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<GetItemPriceResponse>(response);
            return result;
        }

       



        public async Task<UpdateInventoryResponse> UpdateItemInventory(UpdateInventoryRequest reqModel)
        {

            var request = CreateRequest<UpdateInventoryRequest>(reqModel);
            request.URI = "contentmgmt/item/international/inventory";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<UpdateInventoryResponse>(response);
            return result;
        }




        public async Task<UpdateItemPriceResponse> UpdateItemPrice(UpdateItemPriceRequest reqModel)
        {

            var request = CreateRequest<UpdateItemPriceRequest>(reqModel);
            request.URI = "contentmgmt/item/international/price";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<UpdateItemPriceResponse>(response);
            return result;
        }







        public async Task<UpdateInventoryandPriceResponse> UpdateInventoryandPrice(UpdateInventoryandPriceRequest reqModel)
        {

            var request = CreateRequest<UpdateInventoryandPriceRequest>(reqModel);
            request.URI = "contentmgmt/item/inventoryandprice";
            var response = await client.PutAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<UpdateInventoryandPriceResponse>(response);
            return result;
        }
       



        public async Task<ItemWarrantyResponse> SubmitItemWarrantyRequest(ItemWarrantyRequest reqModel)
        {
            var request = CreateRequest<ItemWarrantyRequest>(reqModel);
            request.URI = "contentmgmt/item/warranty";

            var response = await client.PostAsync(request).ConfigureAwait(false);
            var result = await ProcessResponse<ItemWarrantyResponse>(response);
            return result;
        }

        /// <summary>
        /// USA get inventory list
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public async Task<GetItemsInventoryResponse> GetItemInternationalInventoryList(GetItemsInventoryRequest reqModel)
        {
            var request = CreateRequest<GetItemsInventoryRequest>(reqModel);
            request.URI = "contentmgmt/item/international/inventorylist";
            var response = await client.PostAsync(request);
            return await ProcessResponse<GetItemsInventoryResponse>(response);
        }
        public async Task<GetUsbOrCanInventorysResponse> GetItemInventoryList(GetUsbOrCanItemInventoryRequest reqModel)
        {
            var request = CreateRequest<GetUsbOrCanItemInventoryRequest>(reqModel);
            request.URI = "contentmgmt/item/inventorylist";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<GetUsbOrCanInventorysResponse>(response);
            return result;
        }

        /// <summary>
        /// Batch track the price-related information of specified items for destination countries, including the United States.
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public async Task<GetItemPriceListResponse> GetInternationalItemPriceList(GetInternationalItemPriceListRequest reqModel)
        {

            var request = CreateRequest<GetInternationalItemPriceListRequest>(reqModel);
            request.URI = "contentmgmt/item/international/pricelist";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<GetItemPriceListResponse>(response);
            return result;
        }
        /// <summary>
        /// Batch track the price-related information of items in the default warehouse.
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public async Task<GetItemPriceListResponse> GetItemPriceList(GetCanOrUsbItemPriceRequest reqModel)
        {
            var request = CreateRequest<GetCanOrUsbItemPriceRequest>(reqModel);
            request.URI = "contentmgmt/item/pricelist";

            var response = await client.PostAsync(request);
            var result = await ProcessResponse<GetItemPriceListResponse>(response);
            return result;
        }

    }
}
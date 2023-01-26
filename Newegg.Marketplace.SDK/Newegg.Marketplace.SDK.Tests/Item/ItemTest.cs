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
using System.Threading.Tasks;

using Xunit;

using Newegg.Marketplace.SDK.Item;
using Newegg.Marketplace.SDK.Item.Model;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Tests.Item
{
    public class ItemTest : TestBase
    {
        private readonly ItemCall api, fadeAPI_USA_XML, api_json, B2BJSON, CANXML, CANJSON,
        B2Bapi, fadeAPI_B2B_XML, fadeAPI_CAN_XML, fadeAPI_USA_Json, fadeAPI_B2B_Json, fadeAPI_CAN_Json;

        public object TestContext { get; private set; }

        public ItemTest()
        {
            api = new ItemCall(USAClientXML);
            api_json = new ItemCall(USAClientJSON);
            B2Bapi = new ItemCall(B2BClientXML);
            B2BJSON = new ItemCall(B2BClientJSON);
            CANXML = new ItemCall(CANClientXML);
            CANJSON = new ItemCall(CANClientJSON);
            fadeAPI_USA_XML = new ItemCall(fakeUSAClientXML);
            fadeAPI_B2B_XML = new ItemCall(fakeB2BClientXML);
            fadeAPI_CAN_XML = new ItemCall(fakeCANClientXML);
            fadeAPI_USA_Json = new ItemCall(fakeUSAClientJSON);
            fadeAPI_B2B_Json = new ItemCall(fakeB2BClientJSON);
            fadeAPI_CAN_Json = new ItemCall(fakeCANClientJSON);

        }
        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]//XML USA
        public async Task SubmitVolumeDiscount_XML_USA()
        {

            var request = new SubmitVolumeDiscountRequest()
            {

                RequestBody = new SubmitVolumeDiscountRequestBody()
                {
                    ItemVolumeDiscountInfo = new ItemVolumeDiscountInfo()
                    {
                        NeweggItemNumber = "9SIA0062TT3677",
                        VolumeActivation = ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                        DiscountSetting = new List<TierInfo>()
                     {
                    new TierInfo()
                    {
                        Priority = 1,
                        SellingPrice = 0.98M,
                        Quantity = 10,
                        EnableFreeShipping = 0
                    },new TierInfo()
                    {
                        Priority = 2,
                        SellingPrice = 0.90M,
                        Quantity = 100,
                        EnableFreeShipping = 0
                    }
                   }
                    }
                }
            };



            CheckRequestString<SubmitVolumeDiscountRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitVolumeDiscount(request);

            Assert.IsType<SubmitVolumeDiscountResponse>(body);

        }
        [Fact]
        public async Task SubmitVolumeDiscount_XML_B2B()
        {

            var request = new SubmitVolumeDiscountRequest()
            {

                RequestBody = new SubmitVolumeDiscountRequestBody()
                {
                    ItemVolumeDiscountInfo = new ItemVolumeDiscountInfo()
                    {
                        NeweggItemNumber = "9SIA0062TT3677",
                        VolumeActivation = ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                        DiscountSetting = new List<TierInfo>()
                     {
                    new TierInfo()
                    {
                        Priority = 1,
                        SellingPrice = 0.98M,
                        Quantity = 10,
                        EnableFreeShipping = 0
                    },new TierInfo()
                    {
                        Priority = 2,
                        SellingPrice = 0.90M,
                        Quantity = 100,
                        EnableFreeShipping = 0
                    }
                   }
                    }
                }
            };



            CheckRequestString<SubmitVolumeDiscountRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitVolumeDiscount(request);

            Assert.IsType<SubmitVolumeDiscountResponse>(body);

        }
        [Fact]
        public async Task SubmitVolumeDiscount_XML_CAN()
        {

            var request = new SubmitVolumeDiscountRequest()
            {

                RequestBody = new SubmitVolumeDiscountRequestBody()
                {
                    ItemVolumeDiscountInfo = new ItemVolumeDiscountInfo()
                    {
                        NeweggItemNumber = "9SIA0062TT3677",
                        VolumeActivation = ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                        DiscountSetting = new List<TierInfo>()
                     {
                    new TierInfo()
                    {
                        Priority = 1,
                        SellingPrice = 0.98M,
                        Quantity = 10,
                        EnableFreeShipping = 0
                    },new TierInfo()
                    {
                        Priority = 2,
                        SellingPrice = 0.90M,
                        Quantity = 100,
                        EnableFreeShipping = 0
                    }
                   }
                    }
                }
            };



            CheckRequestString<SubmitVolumeDiscountRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitVolumeDiscount(request);

            Assert.IsType<SubmitVolumeDiscountResponse>(body);

        }


        [Fact]//XML USA
        public async Task SubmitManufacturerRequest_XML_USA()
        {
            var request = new SubmitManufacturerRequest()
            {

                RequestBody = new SubmitManufacturerRequestBody()
                {
                    ManufacturerRequest = new CManufacturerRequest()
                    {
                        Name = "test2013 SDK USAtest-1080219-16",
                        URL = "test2013.com",
                        SupportEmail = "SDK@newegg.com",
                        SupportPhone = "86-1868869056",
                        SupportURL = "http://www.newegg.com"
                    }

                }
            };

            CheckRequestString<SubmitManufacturerRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitManufacturerRequest(request);

            Assert.IsType<SubmitManufacturerResponse>(body);
            Assert.Equal("A006", body.SellerID);


        }
        [Fact]//XML B2B
        public async Task SubmitManufacturerRequest_XML_B2B()
        {
            var request = new SubmitManufacturerRequest()
            {

                RequestBody = new SubmitManufacturerRequestBody()
                {
                    ManufacturerRequest = new CManufacturerRequest()
                    {
                        Name = "test2013 SDK USAtest-1080219-16",
                        URL = "test2013.com",
                        SupportEmail = "SDK@newegg.com",
                        SupportPhone = "86-1868869056",
                        SupportURL = "http://www.newegg.com"
                    }

                }
            };

            CheckRequestString<SubmitManufacturerRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitManufacturerRequest(request);

            Assert.IsType<SubmitManufacturerResponse>(body);


        }
        [Fact]//XML CAN
        public async Task SubmitManufacturerRequest_XML_CAN()
        {
            var request = new SubmitManufacturerRequest()
            {

                RequestBody = new SubmitManufacturerRequestBody()
                {
                    ManufacturerRequest = new CManufacturerRequest()
                    {
                        Name = "test2013 SDK USAtest-1080219-16",
                        URL = "test2013.com",
                        SupportEmail = "SDK@newegg.com",
                        SupportPhone = "86-1868869056",
                        SupportURL = "http://www.newegg.com"
                    }

                }
            };

            CheckRequestString<SubmitManufacturerRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitManufacturerRequest(request);

            Assert.IsType<SubmitManufacturerResponse>(body);


        }


        [Fact]//xml USA
        public async Task ManufacturerLookup_XML_USA()
        {
            var request = new ManufacturerLookupRequest()
            {

                RequestBody = new ManufacturerLookupRequestBody()
                {
                    PageIndex = 1,
                    PageSize = 10,

                    RequestCriteria = new CRequestCriteria()
                    {
                        ManufacturerName = "test2013 5"
                        ,
                        CreatedDateFrom = "",
                        CreatedDateTo = "",

                    }

                }
            };

            CheckRequestString<ManufacturerLookupRequest>(request);
            var body = await fadeAPI_USA_XML.ManufacturerLookup(request);


            Assert.IsType<ManufacturerLookupResponse>(body);


        }
        [Fact]//xml B2B
        public async Task ManufacturerLookup_XML_B2B()
        {
            var request = new ManufacturerLookupRequest()
            {

                RequestBody = new ManufacturerLookupRequestBody()
                {
                    PageIndex = 1,
                    PageSize = 10,
                    RequestCriteria = new CRequestCriteria()
                    {
                        ManufacturerName = "test2013 2"
                    }
                }
            };

            CheckRequestString<ManufacturerLookupRequest>(request);
            var body = await fadeAPI_B2B_XML.ManufacturerLookup(request);
            Assert.IsType<ManufacturerLookupResponse>(body);
        }
        [Fact]//xml CAN
        public async Task ManufacturerLookup_XML_CAN()
        {
            var request = new ManufacturerLookupRequest()
            {

                RequestBody = new ManufacturerLookupRequestBody()
                {
                    PageIndex = 1,
                    PageSize = 10,
                    RequestCriteria = new CRequestCriteria()
                    {
                        ManufacturerName = "test2013 2"
                    }
                }
            };

            CheckRequestString<ManufacturerLookupRequest>(request);
            var body = await fadeAPI_CAN_XML.ManufacturerLookup(request);
            Assert.IsType<ManufacturerLookupResponse>(body);
        }



        [Fact]//xml only USA
        public async Task ManufacturerLookupForInternationalCountry_XML_USA()
        {
            var request = new ManufacturerLookupForInternationalCountryRequest()
            {

                RequestBody = new ManufacturerLookupForInternationalCountryRequestBody()
                {
                    PageIndex = 1,
                    PageSize = 10,
                    RestrictedCountryCode = "USA",
                    RequestCriteria = new CountryRequestCriteria()
                    {
                        ManufacturerName = "test2013 2",
                        CreatedDateFrom = "",
                        CreatedDateTo = "",

                    }

                }
            };

            CheckRequestString<ManufacturerLookupForInternationalCountryRequest>(request);
            var body = await fadeAPI_USA_XML.ManufacturerLookupForInternationalCountry(request);

            Assert.IsType<ManufacturerLookupForInternationalCountryResponse>(body);
        }


        [Fact]//XML USA
        public async Task GetManufacturerRequestStatus_XML_USA()
        {
            var request = new GetManufacturerRequestStatusRequest()
            {

                RequestBody = new GetManufacturerRequestStatusRequestBody()
                {
                    ManufacturerList = new List<String>()
                    {
                    "test2013 6",
                    "test2013 SDK USAtest-1"
                    }
                }
            };


            CheckRequestString<GetManufacturerRequestStatusRequest>(request);
            var body = await fadeAPI_USA_XML.GetManufacturerRequestStatus(request);

            Assert.IsType<GetManufacturerRequestStatusResponse>(body);
        }
        [Fact]//XML  B2B
        public async Task GetManufacturerRequestStatus_XML_B2B()
        {
            var request = new GetManufacturerRequestStatusRequest()
            {

                RequestBody = new GetManufacturerRequestStatusRequestBody()
                {
                    ManufacturerList = new List<String>()
                    {
                    "test2013 6",
                    "test2013 SDK USAtest-1"
                    }
                }
            };


            CheckRequestString<GetManufacturerRequestStatusRequest>(request);
            var body = await fadeAPI_B2B_XML.GetManufacturerRequestStatus(request);

            Assert.IsType<GetManufacturerRequestStatusResponse>(body);
        }
        [Fact]//XML CAN
        public async Task GetManufacturerRequestStatus_XML_CAN()
        {
            var request = new GetManufacturerRequestStatusRequest()
            {

                RequestBody = new GetManufacturerRequestStatusRequestBody()
                {
                    ManufacturerList = new List<String>()
                    {
                    "test2013 6",
                    "test2013 SDK USAtest-1"
                    }
                }
            };


            CheckRequestString<GetManufacturerRequestStatusRequest>(request);
            var body = await fadeAPI_CAN_XML.GetManufacturerRequestStatus(request);

            Assert.IsType<GetManufacturerRequestStatusResponse>(body);
        }
        

        [Fact]//USA  XML 
        public async Task GetVolumeDiscountRequestResult_XML_USA()
        {
            var request = new GetVolumeDiscountRequestResultRequest()
            {

                RequestBody = new GetVolumeDiscountRequestResultRequetsBody()
                {
                    NeweggItemNumber = "9SIA0063R11047"
                }
            };

            CheckRequestString<GetVolumeDiscountRequestResultRequest>(request);
            var body = await fadeAPI_USA_XML.GetVolumeDiscountRequestResult(request);

            Assert.IsType<GetVolumeDiscountRequestResultResponse>(body);
        }
        [Fact]//B2B  XML 
        public async Task GetVolumeDiscountRequestResult_XML_B2B()
        {
            var request = new GetVolumeDiscountRequestResultRequest()
            {

                RequestBody = new GetVolumeDiscountRequestResultRequetsBody()
                {
                    NeweggItemNumber = "9SIA3TV5Y19568"//A3TV
                }
            };

            CheckRequestString<GetVolumeDiscountRequestResultRequest>(request);
            var body =  await fadeAPI_B2B_XML.GetVolumeDiscountRequestResult(request);

            Assert.IsType<GetVolumeDiscountRequestResultResponse>(body);
        }
        [Fact]//CAN XML 
        public async Task GetVolumeDiscountRequestResult_XML_CAN()
        {
            var request = new GetVolumeDiscountRequestResultRequest()
            {

                RequestBody = new GetVolumeDiscountRequestResultRequetsBody()
                {
                    NeweggItemNumber = "9SIA3TV5Y19568"//A3TV
                }
            };

            CheckRequestString<GetVolumeDiscountRequestResultRequest>(request);
            var body = await fadeAPI_CAN_XML.GetVolumeDiscountRequestResult(request);

            Assert.IsType<GetVolumeDiscountRequestResultResponse>(body);
        }




        [Fact]//USA XML 
        public async Task GetItemInternationalInventory_XML_USA_Nothave_WarehouseList()
        {
            GetItemInternationalInventoryRequest InventoryRequest = new GetItemInternationalInventoryRequest()
            {
                // Condition= ItemCondition.New,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"

            };

            CheckRequestString<GetItemInternationalInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_USA_XML.GetItemInternationalInventory(InventoryRequest);
            Assert.IsType<GetItemInternationalInventoryResponse>(body);



        }

        [Fact]//USA XML
        public async Task GetItemInternationalInventory_XML_USA_have_WarehouseList()
        {
            GetItemInternationalInventoryRequest InventoryRequest = new GetItemInternationalInventoryRequest()
            {
                Condition = ItemCondition.New,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333",

                WarehouseList = new List<string>()
                {"USA"}
            };
            CheckRequestString<GetItemInternationalInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_USA_XML.GetItemInternationalInventory(InventoryRequest);
            Assert.IsType<GetItemInternationalInventoryResponse>(body);

        }

        [Fact]//B2B  XML 
        public async Task GetItemInventory304_XML_USA()
        {
            GetItemInventoryRequest InventoryRequest = new GetItemInventoryRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA44S3KG2890"
            };

            CheckRequestString<GetItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_USA_XML.GetItemInventory(InventoryRequest, 304);//have  WarehouseCode
            Assert.IsType<GetItemInventoryResponse>(body);


        }
        [Fact]//B2B  XML 
        public async Task GetItemInventory304_XML_B2B()
        {
            GetItemInventoryRequest InventoryRequest = new GetItemInventoryRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA44S3KG2890"
            };

            CheckRequestString<GetItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_B2B_XML.GetItemInventory(InventoryRequest, 304);//have  WarehouseCode
            Assert.IsType<GetItemInventoryResponse>(body);

        }

        [Fact]//B2B  XML 
        public async Task GetItemInventory304_XML_CAN()
        {
            GetItemInventoryRequest InventoryRequest = new GetItemInventoryRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA44S3KG2890"//B2B A44S
            };

            CheckRequestString<GetItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_CAN_XML.GetItemInventory(InventoryRequest, 304);//have  WarehouseCode
            Assert.IsType<GetItemInventoryResponse>(body);


        }

        [Fact]//USA  XML 
        public async Task GetInternationalItemPrice_XML_USA()
        {

            GetInternationalItemPriceRequest PriceRequest = new GetInternationalItemPriceRequest()
            {
                 Condition = ItemCondition.Refurbished,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"

            };

            CheckRequestString<GetInternationalItemPriceRequest>(PriceRequest);
            var body = await fadeAPI_USA_XML.GetInternationalItemPrice(PriceRequest);

            Assert.IsType<GetInternationalItemPriceResponse>(body);

        }


        [Fact]//USA XML 
        public async Task GetItemPriceB2BCAN_XML_USA()
        {

            GetItemPriceRequest PriceRequest = new GetItemPriceRequest()
            {
                // Condition = ItemCondition.Refurbished,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"
                // , CountryList = new List<string>(){"USA" }

            };

            CheckRequestString<GetItemPriceRequest>(PriceRequest);
            var body = await fadeAPI_USA_XML.GetItemPrice(PriceRequest);
            Assert.IsType<GetItemPriceResponse>(body);

        }
        [Fact]//B2B  XML 
        public async Task GetItemPriceB2BCAN_XML_B2B()
        {

            GetItemPriceRequest PriceRequest = new GetItemPriceRequest()
            {
                // Condition = ItemCondition.Refurbished,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"
                // , CountryList = new List<string>(){"USA" }

            };

            CheckRequestString<GetItemPriceRequest>(PriceRequest);
            var body = await fadeAPI_B2B_XML.GetItemPrice(PriceRequest);
            Assert.IsType<GetItemPriceResponse>(body);

        }
        [Fact]//CAN  XML 
        public async Task GetItemPriceB2BCAN_XML_CAN()
        {

            GetItemPriceRequest PriceRequest = new GetItemPriceRequest()
            {
                // Condition = ItemCondition.Refurbished,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"
                // , CountryList = new List<string>(){"USA" }

            };

            CheckRequestString<GetItemPriceRequest>(PriceRequest);
            var body = await fadeAPI_CAN_XML.GetItemPrice(PriceRequest);
            Assert.IsType<GetItemPriceResponse>(body);

        }



        [Fact]//XML USA  
        public async Task UpdateItemInventory_XML_USA()
        {


            UpdateInventoryRequest UpdateItemInventoryRequest = new UpdateInventoryRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333",
                InventoryList = new List<UpdateInventoryRequest.UpdateInventory>()
                 { new UpdateInventoryRequest.UpdateInventory(){
                      AvailableQuantity=100,
                       WarehouseLocation="USA"

                 } }

            };

            CheckRequestString<UpdateInventoryRequest>(UpdateItemInventoryRequest);
            var body = await fadeAPI_USA_XML.UpdateItemInventory(UpdateItemInventoryRequest);
            Assert.IsType<UpdateInventoryResponse>(body);
        }
       

        [Fact]//XML USA 
        public async Task UpdateItemPrice_XML_USA()
        {


            UpdateItemPriceRequest UpdateItemPricerequest = new UpdateItemPriceRequest()
            {
                Condition = ItemCondition.New,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333",
                PriceList = new List<UpdateItemPriceRequest.UpdateItemPrice>()
                 {
                     new UpdateItemPriceRequest.UpdateItemPrice(){

                       CountryCode = "AUS",
                       Currency = "USD",
                        Active =ItemPriceActive.Deactivate_item,
                       MSRP=3500M,
                        MAP=0M,
                       CheckoutMAP=0,
                        SellingPrice=1149.98M,
                       EnableFreeShipping=FreeShipping.Default,
                       LimitQuantity=1
                     }

                 }

            };

            CheckRequestString<UpdateItemPriceRequest>(UpdateItemPricerequest);
            var body = await fadeAPI_USA_XML.UpdateItemPrice(UpdateItemPricerequest);
            Assert.IsType<UpdateItemPriceResponse>(body);
        }


        [Fact]//XML CAN 
        public async Task UpdateInventoryandPriceB2BCAN_XML_CAN()

        {

            UpdateInventoryandPriceRequest UpdateItemInventoryRequest = new UpdateInventoryandPriceRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA3TV5977227",
                Inventory = 100,
                MSRP = 250,
                MAP = 230,
                CheckoutMAP = CheckoutMAP.False,
                SellingPrice = 200,
                EnableFreeShipping = FreeShipping.Free_Shipping,
                Active = ItemActive.InActive,
                //  FulfillmentOption= FulfillmentOption.ShipByNewegg,
                Condition = ItemCondition.Refurbished




            };
            CheckRequestString<UpdateInventoryandPriceRequest>(UpdateItemInventoryRequest);
            // var body = await CANXML.UpdateInventoryandPrice(UpdateItemInventoryRequest);
            var body = await fadeAPI_CAN_XML.UpdateInventoryandPrice(UpdateItemInventoryRequest);
            Assert.IsType<UpdateInventoryandPriceResponse>(body);


        }
        [Fact]//XML B2B 
        public async Task UpdateInventoryandPriceB2BCAN_XML_B2B()

        {

            UpdateInventoryandPriceRequest UpdateItemInventoryRequest = new UpdateInventoryandPriceRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA44S8HT5827",
                Inventory = 100,
                MSRP = 250,
                MAP = 230,
                CheckoutMAP = CheckoutMAP.False,
                SellingPrice = 200,
                EnableFreeShipping = FreeShipping.Free_Shipping,
                Active = ItemActive.InActive,
                //  FulfillmentOption= FulfillmentOption.ShipByNewegg,
                Condition = ItemCondition.New




            };

            CheckRequestString<UpdateInventoryandPriceRequest>(UpdateItemInventoryRequest);
            //  var body = await B2Bapi.UpdateInventoryandPrice(UpdateItemInventoryRequest); 
            var body = await fadeAPI_B2B_XML.UpdateInventoryandPrice(UpdateItemInventoryRequest);
            Assert.IsType<UpdateInventoryandPriceResponse>(body);


        }


        [Fact]//XML USA
        public async Task SubmitItemWarrantyRequest_USA_XML()
        {
            var request = new ItemWarrantyRequest()
            {
                ActionType = ActionType.Create_arranty,

                RequestBody = new ItemWarrantyRequestBody()
                {

                    ItemWarrantyList = new List<ItemWarranty>()
                    {
                         new ItemWarranty(){
                             ItemManufacturerWarrantyID=0,
                             SellerPartNumber="NE.Dell.M6800.16.1TB+1TB.W10",
                             PartsDay=10,
                             LaborDay=10,
                             ServiceProvider="Test",
                             ProviderSupportEmail="test@newegg.com",
                             ProviderSupportURL="http://www.sohnen.com/CustomerSupport.aspx",
                             ProviderCustomerServicePhone="562-946-3531",
                             CountryCode="USA",
                             ApplyToAllCountryCode=false

                         }


                    }
                }



            };
            CheckRequestString<ItemWarrantyRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitItemWarrantyRequest(request);
            Assert.IsType<ItemWarrantyResponse>(body);
        }
        [Fact]//XML B2B
        public async Task SubmitItemWarrantyRequest_B2B_XML()
        {
            var request = new ItemWarrantyRequest()
            {
                ActionType = ActionType.Create_arranty,

                RequestBody = new ItemWarrantyRequestBody()
                {

                    ItemWarrantyList = new List<ItemWarranty>()
                    {
                         new ItemWarranty(){
                             ItemManufacturerWarrantyID=0,
                             SellerPartNumber="NE.Dell.M6800.16.1TB+1TB.W10",
                             PartsDay=10,
                             LaborDay=10,
                             ServiceProvider="Test",
                             ProviderSupportEmail="test@newegg.com",
                             ProviderSupportURL="http://www.sohnen.com/CustomerSupport.aspx",
                             ProviderCustomerServicePhone="562-946-3531",
                             CountryCode="USA",
                             ApplyToAllCountryCode=false

                         }


                    }
                }



            };
            CheckRequestString<ItemWarrantyRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitItemWarrantyRequest(request);
            Assert.IsType<ItemWarrantyResponse>(body);
        }
        [Fact]//XML  CAN 
        public async Task SubmitItemWarrantyRequest_CAN_XML()
        {
            var request = new ItemWarrantyRequest()
            {
                ActionType = ActionType.Create_arranty,

                RequestBody = new ItemWarrantyRequestBody()
                {

                    ItemWarrantyList = new List<ItemWarranty>()
                    {
                         new ItemWarranty(){
                             ItemManufacturerWarrantyID=0,
                             SellerPartNumber="NE.Dell.M6800.16.1TB+1TB.W10",
                             PartsDay=10,
                             LaborDay=10,
                             ServiceProvider="Test",
                             ProviderSupportEmail="test@newegg.com",
                             ProviderSupportURL="http://www.sohnen.com/CustomerSupport.aspx",
                             ProviderCustomerServicePhone="562-946-3531",
                             CountryCode="USA",
                             ApplyToAllCountryCode=false

                         }


                    }
                }



            };
            CheckRequestString<ItemWarrantyRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitItemWarrantyRequest(request);
            Assert.IsType<ItemWarrantyResponse>(body);
        }

        /// <summary>
        ///  Get Inventory List Xml USA
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetItemInternationalInventoryList_Json_USA()
        {
            GetItemsInventoryRequest InventoryRequest = new GetItemsInventoryRequest()
            {
                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }

            };
            CheckRequestString<GetItemsInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_USA_Json.GetItemInternationalInventoryList(InventoryRequest);
            Assert.IsType<GetItemsInventoryResponse>(body);

        }


        /// <summary>
        ///  Get Inventory List JSON USB
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetItemInventoryList_Json_USB()
        {
            GetUsbOrCanItemInventoryRequest InventoryRequest = new GetUsbOrCanItemInventoryRequest()
            {
                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }

            };
            CheckRequestString<GetUsbOrCanItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_B2B_Json.GetItemInventoryList(InventoryRequest);
            Assert.IsType<GetUsbOrCanInventorysResponse>(body);

        }


        /// <summary>
        ///  Get Inventory List Xml CAN
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetItemInventoryList_XML_CAN()
        {
            GetUsbOrCanItemInventoryRequest InventoryRequest = new GetUsbOrCanItemInventoryRequest()
            {
                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }

            };
            CheckRequestString<GetUsbOrCanItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_CAN_XML.GetItemInventoryList(InventoryRequest);
            Assert.IsType<GetUsbOrCanInventorysResponse>(body);

        }


        /// <summary>
        ///  Get Inventory List Xml CAN
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetItemInventoryList_JSON_CAN()
        {
            GetUsbOrCanItemInventoryRequest InventoryRequest = new GetUsbOrCanItemInventoryRequest()
            {
                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }

            };
            CheckRequestString<GetUsbOrCanItemInventoryRequest>(InventoryRequest);
            var body = await fadeAPI_CAN_Json.GetItemInventoryList(InventoryRequest);
            Assert.IsType<GetUsbOrCanInventorysResponse>(body);

        }

        /// <summary>
        ///  Get Price List USA
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetInternationalItemPriceList_XML_USA()
        {

            GetInternationalItemPriceListRequest PriceRequest = new GetInternationalItemPriceListRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }

            };

            CheckRequestString<GetInternationalItemPriceListRequest>(PriceRequest);
            var body = await fadeAPI_USA_XML.GetInternationalItemPriceList(PriceRequest);

            Assert.IsType<GetItemPriceListResponse>(body);

        }



        /// <summary>
        ///  Get Price List USb
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetItemPriceList_XML_USB()
        {

            GetCanOrUsbItemPriceRequest PriceRequest = new GetCanOrUsbItemPriceRequest()
            {

                Type = ItemQueryType.NewEggItemNumber,
                Values = new List<string>() { "9SIA0068KA0333" }
            };

            CheckRequestString<GetCanOrUsbItemPriceRequest>(PriceRequest);
            var body = await fadeAPI_B2B_XML.GetItemPriceList(PriceRequest);

            Assert.IsType<GetItemPriceListResponse>(body);

        }


    }
}

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
using System.Collections.Generic;

using Newegg.Marketplace.SDK.Seller;
using Newegg.Marketplace.SDK.Seller.Model;
using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base;

using Xunit;

namespace Newegg.Marketplace.SDK.Tests.Seller
{
    public class SellerTest : TestBase
    {
        private readonly SellerCall api, api_json;
        private readonly SellerCall fakeApi;


        public SellerTest()
        {
            api = new SellerCall(USAClientXML);
            api_json = new SellerCall(USAClientJSON);
            fakeApi = new SellerCall(fakeUSAClientXML);
        }
        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public async Task GetSellerStatusFadeTest()
        {
            var sellerStatus = await fakeApi.SellerStatusCheck();
            var body = sellerStatus.GetResponseBody();
            Assert.IsType<SellerStatusCheckResponseBody>(body);
            Assert.Equal("Test_SandBox_MKTPLS", body.SellerName);
            Assert.True(sellerStatus.IsSuccess);
            Assert.Equal("Active", body.Status.ToString());
        }

        [Fact]
        public void ModelJsonDeserializationTest()
        {
            string value =
                @"
        {
          ""IsSuccess"": true,
          ""OperationType"": ""GetSellerAccountStatusResponse"",
          ""SellerID"": ""A006"",
          ""ResponseBody"": {
                        ""Membership"": 0,
            ""FufillmentCenterList"": [
              {
                ""WarehouseLocation"": ""USA"",
                ""WarehouseType"": 0,
                ""ShippingDestinationList"": [
                  ""USA"",
                  ""AUS"",
                  ""HKG"",
                  ""IND"",
                  ""IDN"",
                  ""PHL"",
                  ""KOR"",
                  ""CHL"",
                  ""MAC"",
                  ""CHN"",
                  ""GBR"",
                  ""SGP""
                ]
            }
            ],
            ""SellerName"": ""Test_SandBox_MKTPLS"",
            ""Status"": ""Active""
          }
        }";
            var serializer = SerializerFactory.GetSerializer(APIFormat.JSON);
            var sellerStatus = serializer.Deserialize<ResponseModel<SellerStatusCheckResponseBody>>(value);
            var body = sellerStatus.GetResponseBody();
            Assert.IsType<SellerStatusCheckResponseBody>(body);
            Assert.Equal("Test_SandBox_MKTPLS", body.SellerName);

        }


        [Fact]
        public async Task CanGetSellerStatusTest()
        {
            var sellerStatus = await fakeApi.SellerStatusCheck(RequestVersion.NeweggShippingLabel);
            var body = sellerStatus.GetResponseBody();
            Assert.IsType<SellerStatusCheckResponseBody>(body);
            Assert.Equal("Test_SandBox_MKTPLS", body.SellerName);
            Assert.True(sellerStatus.IsSuccess);
            Assert.Equal("Active", body.Status.ToString());
        }


        [Fact]
        public async Task CanGetSellerStatusTes_Json()
        {
            var sellerStatus = await fakeApi.SellerStatusCheck(RequestVersion.NeweggShippingLabel);
            var body = sellerStatus.GetResponseBody();
            Assert.IsType<SellerStatusCheckResponseBody>(body);
            Assert.Equal("Test_SandBox_MKTPLS", body.SellerName);
            Assert.True(sellerStatus.IsSuccess);
            Assert.Equal("Active", body.Status.ToString());
        }

        [Fact]
        public async Task ConnectionOptionTest()
        {
            var sellerStatus = await fakeApi.SellerStatusCheck(null, new ConnectSetting()
            {
                AttemptsTimes = 20,
                RetryIntervalMs = 2000,
                RequestTimeoutMs = 10000
            }
            );
            var body = sellerStatus.GetResponseBody();
            Assert.IsType<SellerStatusCheckResponseBody>(body);
            Assert.Equal("Test_SandBox_MKTPLS", body.SellerName);
            Assert.True(sellerStatus.IsSuccess);
            //Assert.Equal("Active", body.Status.ToString());
        }

        [Fact]
        public async Task GetIndustryList()
        {
            var response = await fakeApi.GetIndustryList();
            Assert.IsType<GetIndustryListResponse>(response);
            Assert.True(response.ResponseBody.IndustryList.Count > 0);
        }

        [Fact]
        public async Task GetSubcategoryStatus()
        {
            var req = new GetSubcategoryStatusRequest(new List<string>() { "CH" });
            CheckRequestString<GetSubcategoryStatusRequest>(req);
            var response = await fakeApi.GetSubcategoryStatus(req);
            Assert.IsType<GetSubcategoryStatusResponse>(response);
            Assert.True(response.ResponseBody.SubcategoryList.Count > 0);
        }
        [Fact]
        public async Task GetSubcategoryStatus_Json()
        {
            var req = new GetSubcategoryStatusRequest(new List<string>() { "CH" });
            CheckRequestString<GetSubcategoryStatusRequest>(req);
            var response = await fakeApi.GetSubcategoryStatus(req);
            Assert.IsType<GetSubcategoryStatusResponse>(response);
            Assert.True(response.ResponseBody.SubcategoryList.Count > 0);
        }

        [Fact]
        public async Task GetSubcategoryStatusForInternationalCountry()
        {
            var req = new GetSubcategoryStatusForInternationalCountryRequest("USA", new List<string>() { "CH" });
            CheckRequestString<GetSubcategoryStatusForInternationalCountryRequest>(req);
            var response = await fakeApi.GetSubcategoryStatusForInternationalCountry(req);
            Assert.IsType<GetSubcategoryStatusForInternationalCountryResponse>(response);
            Assert.Equal("USA", response.ResponseBody.CountryCode);
            Assert.True(response.ResponseBody.SubcategoryList.Count > 0);
        }
        [Fact]
        public async Task GetSubcategoryStatusForInternationalCountry_Json()
        {
            var req = new GetSubcategoryStatusForInternationalCountryRequest("USA", new List<string>() { "CH" });
            CheckRequestString<GetSubcategoryStatusForInternationalCountryRequest>(req);
            var response = await fakeApi.GetSubcategoryStatusForInternationalCountry(req);
            Assert.IsType<GetSubcategoryStatusForInternationalCountryResponse>(response);
            Assert.Equal("USA", response.ResponseBody.CountryCode);
            Assert.True(response.ResponseBody.SubcategoryList.Count > 0);
        }



        [Fact]
        public async Task GetSubcategoryProperties()
        {
            var req = new GetSubcategoryPropertiesRequest(1045);
            CheckRequestString<GetSubcategoryPropertiesRequest>(req);
            var response = await fakeApi.GetSubcategoryProperties(req);
            Assert.IsType<GetSubcategoryPropertiesResponse>(response);
            Assert.True(response.ResponseBody.SubcategoryPropertyList.Count > 0);
        }
        [Fact]
        public async Task GetSubcategoryProperties_Json()
        {
            var req = new GetSubcategoryPropertiesRequest(1045);
            CheckRequestString<GetSubcategoryPropertiesRequest>(req);
            var response = await fakeApi.GetSubcategoryProperties(req);
            Assert.IsType<GetSubcategoryPropertiesResponse>(response);
            Assert.True(response.ResponseBody.SubcategoryPropertyList.Count > 0);
        }

        [Fact]
        public async Task GetSubcategoryPropertyValues()
        {
            var req = new GetSubcategoryPropertyValuesRequest("Costume_Gender", 1045);
            CheckRequestString<GetSubcategoryPropertyValuesRequest>(req);
            var response = await fakeApi.GetSubcategoryPropertyValues(req);
            Assert.IsType<GetSubcategoryPropertyValuesResponse>(response);
            Assert.True(response.ResponseBody.PropertyInfoList.Count > 0);
        }
        [Fact]
        public async Task GetSubcategoryPropertyValues_Json()
        {
            var req = new GetSubcategoryPropertyValuesRequest("Costume_Gender", 1045);
            CheckRequestString<GetSubcategoryPropertyValuesRequest>(req);
            var response = await fakeApi.GetSubcategoryPropertyValues(req);
            Assert.IsType<GetSubcategoryPropertyValuesResponse>(response);
            Assert.True(response.ResponseBody.PropertyInfoList.Count > 0);
        }


        [Fact]
        public async Task GetGetSubcategoryStatusV1_Json()
        {
            GetWebSiteSubcategoryRequest request = new GetWebSiteSubcategoryRequest()
            {
                RequestBody = new  GetWebSiteSubcategoryRequestBody()
                {
                    CountryCode = "USA",
                    GetItemSubcategory = new  GetWebSiteSubcategory { Enabled = SellerSubcategoryStatusEnabled.Enabled }
                }
            };
            CheckRequestString<GetWebSiteSubcategoryRequest>(request);
            var response = await fakeApi.GetSubcategoryStatusV1(request);
            Assert.IsType<GetWebSiteSubcategoryResponse>(response);

        }

        [Fact]
        public async Task GetGetWarehouseList_Json()
        {
            var response = await fakeApi.GetWarehouseList();
            Assert.IsType<GetWarehouseResponse>(response);
        }

    }
}

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
using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

using Newegg.Marketplace.SDK.Shipping.Model;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Tests.Shipping.Model
{
    public class ShippingTest : TestBase
    {

        private readonly ShippingCall B2Bapi, fadeAPI_B2B_XML, fadeAPI_CAN_XML;
        private readonly ShippingCall fadeAPI_USA_XML;
        private readonly ShippingCall fadeAPI_USA_json;
        public object TestContext { get; private set; }

        public ShippingTest()
        {
          

            B2Bapi = new ShippingCall(B2BClientXML);
            fadeAPI_USA_XML = new ShippingCall(fakeUSAClientXML);
            fadeAPI_USA_json = new ShippingCall(fakeUSAClientJSON);
            fadeAPI_B2B_XML = new ShippingCall(fakeB2BClientXML);
            fadeAPI_CAN_XML = new ShippingCall(fakeCANClientXML);
        }
        void CheckRequestString<T>(T req)
        {
            SDK.Base.Util.XmlSerializer xmlSerializer = new SDK.Base.Util.XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }
        [Fact]//11.5 xml USA
        public async Task GetPackageList_XML_USA()
        {
            var request = new GetPackageListRequest()
            {

                RequestBody = new GetPackageListRequestBody()
                {
                    RequestID = "282Q5AUAMQKIE"
                }

            };
            CheckRequestString<GetPackageListRequest>(request);
            var body = await fadeAPI_USA_XML.GetPackageList(request);

            Assert.IsType<GetPackageListResponse>(body);


        }
        [Fact]//11.5 xml B2B
        public async Task GetPackageList_XML_B2B()
        {
            var request = new GetPackageListRequest()
            {

                RequestBody = new GetPackageListRequestBody()
                {
                    RequestID = "282Q5AUAMQKIE"
                }

            };
            CheckRequestString<GetPackageListRequest>(request);
            var body = await fadeAPI_B2B_XML.GetPackageList(request);

            Assert.IsType<GetPackageListResponse>(body);


        }

        [Fact]//11.6 xml USA
        public async Task GetShippingLabel_XML_USA()
        {
            var request = new GetShippingLabelRequest()
            {

                RequestBody = new GetShippingLabelRequestBody()
                {
                    RequestID = "282Q5AUAMQKIE"
                }

            };
            CheckRequestString<GetShippingLabelRequest>(request);
            var body = await fadeAPI_USA_XML.GetShippingLabel(request);

            Assert.IsType<GetShippinLabelResponse>(body);

        }
        [Fact]//11.6  xml B2B 
        public async Task GetShippingLabel_XML_B2B()
        {
            var request = new GetShippingLabelRequest()
            {

                RequestBody = new GetShippingLabelRequestBody()
                {
                    RequestID = "282Q5AUAMQKIE"
                }

            };
            CheckRequestString<GetShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_XML.GetShippingLabel(request);

            Assert.IsType<GetShippinLabelResponse>(body);

        }


        [Fact]//11.4 xml USA
        public async Task VoidShippingRequest_XML_USA()
        {
            var request = new VoidShippingRequest()
            {

                RequestBody = new VoidShippingRequestBody()
                {
                    RequestIDList = new List<string>
                    { "245BWZ383S93Y" }
                }

            };

            var VoidShippingRequest = await fadeAPI_USA_XML.VoidShippingRequest(request);
            var body = VoidShippingRequest.GetResponseBody();
            Assert.IsType<VoidShippingResponseBody>(body);
        }
        [Fact]//11.4 xml B2B
        public async Task VoidShippingRequest_XML_B2B()
        {
            var request = new VoidShippingRequest()
            {

                RequestBody = new VoidShippingRequestBody()
                {
                    RequestIDList = new List<string>
                    { "245BWZ383S93Y" }
                }

            };

            var VoidShippingRequest = await fadeAPI_B2B_XML.VoidShippingRequest(request);
            var body = VoidShippingRequest.GetResponseBody();
            Assert.IsType<VoidShippingResponseBody>(body);
        }

        [Fact]//11.3  XML USA
        public async Task ConfirmShippingRequest_XML_USA()
        {
            var request = new ComfirmShipRequest()
            {

                RequestBody = new ComfirmShipRequestBody()
                {
                    RequestIDList = new List<string>
                    { "27BBNUFEFG8HI"}
                }

            };


            CheckRequestString<ComfirmShipRequest>(request);
            var body = await fadeAPI_USA_XML.ConfirmShippingRequest(request);
            Assert.IsType<ComfirmShipResponse>(body);
        }
        [Fact]//11.3  XML B2B
        public async Task ConfirmShippingRequest_XML_B2B()
        {
            var request = new ComfirmShipRequest()
            {

                RequestBody = new ComfirmShipRequestBody()
                {
                    RequestIDList = new List<string>
                    { "27BBNUFEFG8HI"}
                }

            };


            CheckRequestString<ComfirmShipRequest>(request);
            var body = await fadeAPI_B2B_XML.ConfirmShippingRequest(request);
            Assert.IsType<ComfirmShipResponse>(body);
        }

        [Fact]//11.2 xml USA
        public async Task GetShippingRequestDetaill_XML_USA()
        {
            var request = new GetShippingDetailRequest()
            {

                RequestBody = new GetShippingDetailRequestBody()
                {
                    // RequestID = "282Q5AUAMQKIE"
                    RequestID = "245BWZ383S93Y"
                }

            };
            CheckRequestString<GetShippingDetailRequest>(request);
            var body = await fadeAPI_USA_XML.GetShippingRequestDetail(request);
            Assert.IsType<GetShippingDetailResponse>(body);

        }
        [Fact]//11.2 xml B2B
        public async Task GetShippingRequestDetail_XML_B2B()
        {
            var request = new GetShippingDetailRequest()
            {

                RequestBody = new GetShippingDetailRequestBody()
                {
                    // RequestID = "282Q5AUAMQKIE"
                    RequestID = "245BWZ383S93Y"
                }

            };
            CheckRequestString<GetShippingDetailRequest>(request);
            var body = await fadeAPI_B2B_XML.GetShippingRequestDetail(request);
            Assert.IsType<GetShippingDetailResponse>(body);

        }


        [Fact]//11.1  USA_XML
        public async Task SubmitShippingRequest_USA_XML()
        {
            var request = new SubmitShippingRequest()
            {
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 127265380,
                        ShippingCarrierCode = 200,
                        ShippingServiceCode = 201,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "kelly",
                        ShipFromLastName = "Ianus",
                        ShipFromPhoneNumber = "626-347-5618",
                        ShipFromAddress1 = "17708 Rowland St",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "United States",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=28.6M,
                                    PackageLength=12M,
                                    PackageWidth=12M,
                                    PackageHeight=12M,
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="test_A2EU1901261456<12465>",
                                                    Quantity=1
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<SubmitShippingRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitShippingRequest(request);
            Assert.IsType<SubmitShippingResponse>(body);
        }

        [Fact]//11.1  B2B_XML
        public async Task SubmitShippingRequest_B2B_XML()
        {
            var request = new SubmitShippingRequest()
            {
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 127265380,
                        ShippingCarrierCode = 200,
                        ShippingServiceCode = 201,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "kelly",
                        ShipFromLastName = "Ianus",
                        ShipFromPhoneNumber = "626-347-5618",
                        ShipFromAddress1 = "17708 Rowland St",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "United States",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=28.6M,
                                    PackageLength=12M,
                                    PackageWidth=12M,
                                    PackageHeight=12M,
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="test_A2EU1901261456<12465>",
                                                    Quantity=1
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<SubmitShippingRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitShippingRequest(request);
            Assert.IsType<SubmitShippingResponse>(body);
        }

    }

}

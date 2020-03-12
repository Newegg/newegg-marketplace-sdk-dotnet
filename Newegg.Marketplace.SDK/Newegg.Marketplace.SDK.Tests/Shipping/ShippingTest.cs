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
using Newegg.Marketplace.SDK.Shipping.CreateShippingLabel;
using Newegg.Marketplace.SDK.Shipping.EstimateShippingLabel;
using Newegg.Marketplace.SDK.Shipping.ReprintShippingLabel;

namespace Newegg.Marketplace.SDK.Tests.Shipping.Model
{
    public class ShippingTest : TestBase
    {

        private readonly ShippingCall USAapi, B2Bapi,CANapi, USAapi_Json, B2Bapi_Json, CANapi_Json,fadeAPI_B2B_XML, fadeAPI_CAN_XML;
        private readonly ShippingCall fadeAPI_USA_XML;
        private readonly ShippingCall fadeAPI_USA_Json, fadeAPI_B2B_Json, fadeAPI_CAN_Json;
        public object TestContext { get; private set; }

        public ShippingTest()
        {
            USAapi = new ShippingCall(USAClientXML);
            B2Bapi = new ShippingCall(B2BClientXML);
            CANapi = new ShippingCall(CANClientXML);
            USAapi_Json = new ShippingCall(USAClientJSON);
            B2Bapi_Json = new ShippingCall(B2BClientJSON);
            CANapi_Json = new ShippingCall(CANClientJSON);
            fadeAPI_USA_XML = new ShippingCall(fakeUSAClientXML);
            fadeAPI_USA_Json = new ShippingCall(fakeUSAClientJSON);
            fadeAPI_B2B_XML = new ShippingCall(fakeB2BClientXML);
            fadeAPI_B2B_Json = new ShippingCall(fakeB2BClientJSON);
            fadeAPI_CAN_XML = new ShippingCall(fakeCANClientXML);
            fadeAPI_CAN_Json = new ShippingCall(fakeCANClientJSON);
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
            var request = new confirmShipRequest()
            {

                RequestBody = new confirmShipRequestBody()
                {
                    RequestIDList = new List<string>
                    { "27BBNUFEFG8HI"}
                }

            };


            CheckRequestString<confirmShipRequest>(request);
            var body = await fadeAPI_USA_XML.ConfirmShippingRequest(request);
            Assert.IsType<confirmShipResponse>(body);
        }
        [Fact]//11.3  XML B2B
        public async Task ConfirmShippingRequest_XML_B2B()
        {
            var request = new confirmShipRequest()
            {

                RequestBody = new confirmShipRequestBody()
                {
                    RequestIDList = new List<string>
                    { "27BBNUFEFG8HI"}
                }

            };


            CheckRequestString<confirmShipRequest>(request);
            var body = await fadeAPI_B2B_XML.ConfirmShippingRequest(request);
            Assert.IsType<confirmShipResponse>(body);
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

        [Fact]//11.1  USA_XML
        public async Task CreateShippingRequest_USA_XML()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = USA_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316095,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 103,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "3612 Linda Vista Rd.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "Glendale",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91206",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=28.6M,
                                    PackageLength=12M,
                                    PackageWidth=12M,
                                    PackageHeight=12M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="bank02",
                                                    Quantity=4
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_USA_XML.CreateShippingRequest(request);
            //var body = await USAapi.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  USA_XML
        public async Task EstimateShippingRequest_USA_XML()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = USA_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230315475,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 101,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "3612 Linda Vista Rd.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "Glendale",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91206",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="Test_SP1080923090607335",
                                                    Quantity=4
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_USA_XML.EstimateShippingRequest(request);
            //var body = await USAapi.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }

        [Fact]//11.1  USA_XML
        public async Task ReprintShippingRequest_USA_XML()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = USA_Config_XML.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 230315475                        
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_USA_XML.ReprintShippingRequest(request);
            //var body = await USAapi.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }

        [Fact]//11.1  B2B_XML
        public async Task CreateShippingRequest_B2B_XML()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = B2B_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 1250271860,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 102,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "17708 Rowland St.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "City Of Industry",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=27.6M,
                                    PackageLength=16.22M,
                                    PackageWidth=15.22M,
                                    PackageHeight=14.22M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="v01r2018072502",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_XML.CreateShippingRequest(request);
            //var body = await B2Bapi.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  B2B_XML
        public async Task EstimateShippingRequest_B2B_XML()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = B2B_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 1250271860,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 102,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "17708 Rowland St.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "City Of Industry",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=27.6M,
                                    PackageLength=16.22M,
                                    PackageWidth=15.22M,
                                    PackageHeight=14.22M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="v01r2018072502",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_XML.EstimateShippingRequest(request);
            //var body = await B2Bapi.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }

        [Fact]//11.1  B2B_XML
        public async Task ReprintShippingRequest_B2B_XML()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = B2B_Config_XML.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 1250271860
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_XML.ReprintShippingRequest(request);
            //var body = await B2Bapi.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_XML
        public async Task CreateShippingRequest_CAN_XML()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = CAN_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316695,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 112,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "201 The Heights Dr",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "NORTH YORK",
                        ShipFromStateCode = "ON",
                        ShipFromZipCode = "M3C 1Y3",
                        ShipFromCountryCode = "CAN",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="BHHC201805080001",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_XML.CreateShippingRequest(request);
            //var body = await CANapi.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_XML
        public async Task EstimateShippingRequest_CAN_XML()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = CAN_Config_XML.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316695,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 112,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "201 The Heights Dr",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "NORTH YORK",
                        ShipFromStateCode = "ON",
                        ShipFromZipCode = "M3C 1Y3",
                        ShipFromCountryCode = "CAN",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="BHHC201805080001",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_XML.EstimateShippingRequest(request);
            //var body = await CANapi.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_XML
        public async Task ReprintShippingRequest_CAN_XML()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = CAN_Config_XML.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 230316695
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_XML.ReprintShippingRequest(request);
            //var body = await CANapi.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }
        [Fact]//  USA_Json
        public async Task CreateShippingRequest_USA_Json()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = USA_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316095,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 103,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "3612 Linda Vista Rd.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "Glendale",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91206",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=28.6M,
                                    PackageLength=12M,
                                    PackageWidth=12M,
                                    PackageHeight=12M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="bank02",
                                                    Quantity=4
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_USA_Json.CreateShippingRequest(request);
            //var body = await USAapi_Json.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  USA_Json
        public async Task EstimateShippingRequest_USA_Json()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = USA_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230315475,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 101,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "3612 Linda Vista Rd.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "Glendale",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91206",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="Test_SP1080923090607335",
                                                    Quantity=4
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_USA_Json.EstimateShippingRequest(request);
            //var body = await USAapi_Json.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }
        [Fact] // USA_Json
        public async Task ReprintShippingRequest_USA_Json()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = USA_Config_JSON.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 230315475
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_USA_Json.ReprintShippingRequest(request);
            //var body = await USAapi_Json.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }

        [Fact]// B2B_Json
        public async Task CreateShippingRequest_B2B_Json()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = B2B_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 1250271860,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 102,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "17708 Rowland St.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "City Of Industry",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=27.6M,
                                    PackageLength=16.22M,
                                    PackageWidth=15.22M,
                                    PackageHeight=14.22M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="v01r2018072502",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_Json.CreateShippingRequest(request);
            //var body = await B2Bapi_Json.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  B2B_Json
        public async Task EstimateShippingRequest_B2B_Json()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = B2B_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 1250271860,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 102,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "17708 Rowland St.",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "City Of Industry",
                        ShipFromStateCode = "CA",
                        ShipFromZipCode = "91748",
                        ShipFromCountryCode = "USA",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=27.6M,
                                    PackageLength=16.22M,
                                    PackageWidth=15.22M,
                                    PackageHeight=14.22M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="v01r2018072502",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_Json.EstimateShippingRequest(request);
            //var body = await B2Bapi_Json.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }

        [Fact]//11.1  B2B_Json
        public async Task ReprintShippingRequest_B2B_Json()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = B2B_Config_JSON.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 1250271860
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_B2B_Json.ReprintShippingRequest(request);
            //var body = await B2Bapi_Json.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_Json
        public async Task CreateShippingRequest_CAN_Json()
        {
            var request = new CreateShippingLabelRequest()
            {
                SellerID = CAN_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316695,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 112,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "201 The Heights Dr",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "NORTH YORK",
                        ShipFromStateCode = "ON",
                        ShipFromZipCode = "M3C 1Y3",
                        ShipFromCountryCode = "CAN",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="BHHC201805080001",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<CreateShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_Json.CreateShippingRequest(request);
            //var body = await CANapi_Json.CreateShippingRequest(request);
            Assert.IsType<CreateShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_Json
        public async Task EstimateShippingRequest_CAN_Json()
        {
            var request = new EstimateShippingLabelRequest()
            {
                SellerID = CAN_Config_JSON.SellerID,
                RequestBody = new SubmitShippingRequestBody()
                {
                    Shipment = new SubmitShipment()
                    {
                        OrderNumber = 230316695,
                        ShippingCarrierCode = 100,
                        ShippingServiceCode = 112,
                        ShippingLabelServiceCode = 0,
                        ShipFromFirstName = "Richard",
                        ShipFromLastName = "Chen",
                        ShipFromPhoneNumber = "626-271-1420EXT123",
                        ShipFromAddress1 = "201 The Heights Dr",
                        ShipFromAddress2 = "",
                        ShipFromCityName = "NORTH YORK",
                        ShipFromStateCode = "ON",
                        ShipFromZipCode = "M3C 1Y3",
                        ShipFromCountryCode = "CAN",
                        PackageList = new List<SubmitPackage>() {
                                new SubmitPackage(){
                                    PackageWeight=5M,
                                    PackageLength=5.00M,
                                    PackageWidth=4.00M,
                                    PackageHeight=3.00M,
                                    SignatureOptions="Regular",
                                    ItemList=new List<SumbitPackageItemlist>(){
                                        new SumbitPackageItemlist(){
                                                    SellerPartNumber="BHHC201805080001",
                                                    Quantity=2
                                        }
                                    }
                                }
                         }
                    }
                }
            };

            CheckRequestString<EstimateShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_Json.EstimateShippingRequest(request);
            //var body = await CANapi_Json.EstimateShippingRequest(request);
            Assert.IsType<EstimateShippingLabelResponse>(body);
        }

        [Fact]//11.1  CAN_Json
        public async Task ReprintShippingRequest_CAN_Json()
        {
            var request = new ReprintShippingLabelRequest()
            {
                SellerID = CAN_Config_JSON.SellerID,
                RequestBody = new ReprintShippingRequestBody()
                {
                    Shipment = new ReprintShipment()
                    {
                        OrderNumber = 230316695
                    }
                }
            };

            CheckRequestString<ReprintShippingLabelRequest>(request);
            var body = await fadeAPI_CAN_Json.ReprintShippingRequest(request);
            //var body = await CANapi_Json.ReprintShippingRequest(request);
            Assert.IsType<ReprintShippingLabelResponse>(body);
        }
    }

}

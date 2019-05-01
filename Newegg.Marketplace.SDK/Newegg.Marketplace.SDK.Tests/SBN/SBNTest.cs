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

using Newegg.Marketplace.SDK.SBN.Model;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Tests.SBN
{
    public class SBNTest : TestBase
    {
        private readonly SBNCall api,api_json, B2Bapi, fadeAPI_B2B_XML, fadeAPI_CAN_XML;
        private readonly SBNCall fadeAPI_USA_XML;
        private readonly SBNCall fadeAPI_USA_json;

        public object TestContext { get; private set; }

        public SBNTest()
        {
            api = new SBNCall(USAClientXML);
            api_json = new SBNCall(USAClientJSON);
         
            B2Bapi = new SBNCall(B2BClientXML);
            fadeAPI_USA_XML = new SBNCall(fakeUSAClientXML);
            fadeAPI_USA_json = new SBNCall(fakeUSAClientJSON);
            fadeAPI_B2B_XML = new SBNCall(fakeB2BClientXML);
            fadeAPI_CAN_XML = new SBNCall(fakeCANClientXML);
        }
        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }
        [Fact]//16.1 XML USA
        public async Task GetInboundShipmentPlanSuggestion_XML_USA()
        {
            var request = new GetInboundShipmentPlanRequest()
            {

                RequestBody = new GetInboundShipmentPlanRequestBody()
                {
                    PlanSuggestion = new PlanSuggestion()
                    {

                        ItemList = new List<PlanItem>()
                       {
                        new PlanItem(){
                        SellerPartNumber = "423440",
                          PlannedQuantity = 20,
                        QuantityPerCarton = 10

                        },
                        new PlanItem(){
                        SellerPartNumber = "380026",
                          PlannedQuantity = 30,
                        QuantityPerCarton = 10

                        }
                       }
                    }
                }



            };
            CheckRequestString<GetInboundShipmentPlanRequest>(request);
            var body = await fadeAPI_USA_XML.GetInboundShipmentPlanSuggestion(request);

            Assert.IsType<GetInboundShipmentPlanResponse>(body);



        }
        [Fact]//16.1 XML  B2B
        public async Task GetInboundShipmentPlanSuggestion_XML_B2B()
        {
            var request = new GetInboundShipmentPlanRequest()
            {

                RequestBody = new GetInboundShipmentPlanRequestBody()
                {
                    PlanSuggestion = new PlanSuggestion()
                    {

                        ItemList = new List<PlanItem>()
                       {
                        new PlanItem(){
                        SellerPartNumber = "423440",
                          PlannedQuantity = 20,
                        QuantityPerCarton = 10

                        },
                        new PlanItem(){
                        SellerPartNumber = "380026",
                          PlannedQuantity = 30,
                        QuantityPerCarton = 10

                        }
                       }
                    }
                }



            };
            CheckRequestString<GetInboundShipmentPlanRequest>(request);
            var body = await fadeAPI_B2B_XML.GetInboundShipmentPlanSuggestion(request);

            Assert.IsType<GetInboundShipmentPlanResponse>(body);



        }


        [Fact]//16.2 XML USA 
        public async Task SubmitCreateInboundShipmentRequest_XML_USA()
        {
            var request = new SubmitInboundShipmentRequest()
            {

                RequestBody = new SubmitInboundShipmentRequestBody()
                {
                    Shipment = new SubmitInboundShipment()
                    {
                        ActionCode = 1,
                        ShipFromPhoneNumber = "123456789",
                        ShipToWarehouseCode = "08",
                        ShippingMethodCode = 1,
                        ShippingCarrierCode = 99,
                        PackageList = new List<SubmitShipmentPackage>
                       {
                           new SubmitShipmentPackage()
                           {
                              TrackingNumber="SBNAPI-123456789",
                              PackageWeight=10.00M,
                              PackageLength=8.00M,
                              PackageHeight=7.00M,
                              PackageWidth=7.00M
                           }

                        },

                        ItemList = new List<SubmitInboundShipmentItem>()
                        {
                            new SubmitInboundShipmentItem()
                            {
                                 SellerPartNumber="SS0120130516683100755",
                                 Quantity=4,
                                 NumberofPackage=2,
                                 ORM_D=1,
                                 MSDSURL="http://tesipaddress/MSDS/testMSDS.pdf"


                            }

                        }

                    }
                }
            };
            CheckRequestString<SubmitInboundShipmentRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitCreateInboundShipmentRequest(request);

            Assert.IsType<SubmitInboundShipmentResponse>(body);




        }


        [Fact]//16.2 Json USA 
        public async Task SubmitCreateInboundShipmentRequest__Json_USA()
        {
            var request = new SubmitInboundShipmentRequest()
            {

                RequestBody = new SubmitInboundShipmentRequestBody()
                {
                    Shipment = new SubmitInboundShipment()
                    {
                        ActionCode = 1,
                        ShipFromPhoneNumber = "123456789",
                        ShipToWarehouseCode = "08",
                        ShippingMethodCode = 1,
                        ShippingCarrierCode = 99,
                        OtherCarrierName = "newegg",
                        PackageList = new List<SubmitShipmentPackage>
                       {
                           new SubmitShipmentPackage()
                           {
                              TrackingNumber="SBNAPI-123456789",
                              PackageWeight=10.00M,
                              PackageLength=8.00M,
                              PackageHeight=7.00M,
                              PackageWidth=7.00M
                           }

                        },

                        ItemList = new List<SubmitInboundShipmentItem>()
                        {
                            new SubmitInboundShipmentItem()
                            {
                                 SellerPartNumber="SS0120130516683100755",
                                 Quantity=4,
                                 NumberofPackage=2,
                                 ORM_D=1,
                                 MSDSURL="http://tesipaddress/MSDS/testMSDS.pdf"


                            }

                        }

                    }
                }
            };

            CheckRequestString<SubmitInboundShipmentRequest>(request);
            var body = await fadeAPI_USA_json.SubmitCreateInboundShipmentRequest(request);
            Assert.IsType<SubmitInboundShipmentResponse>(body);


        }



        [Fact]//16.2 XML USA
        public async Task SubmitVoidInboundShipmentRequest_XML_USA()
        {
            var request = new SubmitVoidInboundShipmentRequest()
            {

                RequestBody = new SubmitVoidInboundShipmentRequestBody()
                {
                    Shipment = new SubmitVoidInboundShipment()
                    {
                        ActionCode = 2,
                        ShipmentID = "2771551"
                    }
                }
            };




            CheckRequestString<SubmitVoidInboundShipmentRequest>(request);
            var body = await fadeAPI_USA_json.SubmitVoidInboundShipmentRequest(request);
            Assert.IsType<SubmitVoidInboundShipmentResponse>(body);
        }





        [Fact]//16.3 XML  USA
        public async Task GetInboundShipmentStatusRequest_XML_USA()
        {
            var request = new GetShipmentStatusRequest()
            {

                RequestBody = new GetShipmentStatusRequestBody()
                {
                    GetRequestStatus = new GetShipmentStatusRequestSBN()
                    {
                        RequestIDList = new List<string>()
                        {"24UQBFFT2NE9A"},
                        ActionCode = 1,
                        MaxCount = 100,
                        // RequestStatus = RequestStatus.ALL,
                        RequestStatus = "ALL",
                        RequestDateFrom = "",
                        RequestDateTo = ""
                    }
                }
            };
            CheckRequestString<GetShipmentStatusRequest>(request);
            var body = await fadeAPI_USA_XML.GetInboundShipmentStatusRequest(request);

            Assert.IsType<GetShipmentStatusResponse>(body);

        }
        [Fact]//16.3 XML  B2B
        public async Task GetInboundShipmentStatusRequest_XML_B2B()
        {
            var request = new GetShipmentStatusRequest()
            {

                RequestBody = new GetShipmentStatusRequestBody()
                {
                    GetRequestStatus = new GetShipmentStatusRequestSBN()
                    {
                        RequestIDList = new List<string>()
                        {"24UQBFFT2NE9A"},
                        ActionCode = 1,
                        MaxCount = 100,
                        // RequestStatus = RequestStatus.ALL,
                        RequestStatus = "ALL",
                        RequestDateFrom = "",
                        RequestDateTo = ""
                    }
                }
            };
            CheckRequestString<GetShipmentStatusRequest>(request);
            var body = await fadeAPI_B2B_XML.GetInboundShipmentStatusRequest(request);

            Assert.IsType<GetShipmentStatusResponse>(body);




        }


        [Fact]//16.4  XML USA
        public async Task GetInboundShipmentRequest_Result_USA()
        {

            var GetInboundShipmentRequestResult = await fadeAPI_USA_XML.GetInboundShipmentRequestResult("23J3XQBO93AM4");
            var body = GetInboundShipmentRequestResult;
            Assert.IsType<GetInboundShipmentResultResponse>(body);
        }
        [Fact]//16.4  XML B2B
        public async Task GetInboundShipmentRequest_Result_B2B()
        {

            var GetInboundShipmentRequestResult = await fadeAPI_B2B_XML.GetInboundShipmentRequestResult("23J3XQBO93AM4");
            var body = GetInboundShipmentRequestResult;
            Assert.IsType<GetInboundShipmentResultResponse>(body);
        }



        [Fact]//16.5 XML USA
        public async Task GetInboundShipmentList_XML_USA()
        {
            var request = new GetShipmentListRequest()
            {

                RequestBody = new GetShipmentListRequestBody()
                {
                    KeywordsType = ShipKeywordsType.ShipmentID,
                    KeywordsValue = "21UYNT6Z2217K",
                    Status = ShipStatus.All,
                    LastUpdateDateFrom = "01/01/2018",
                    LastUpdateDateTo = "04/30/2019",
                    PageInfo = new SBNPageInfo()
                    {
                        PageIndex = 1,
                        PageSize = 10
                    }
                }
            };


            CheckRequestString<GetShipmentListRequest>(request);
            var body = await fadeAPI_USA_XML.GetInboundShipmentList(request);
            Assert.IsType<GetShipmentListResponse>(body);


        }
        [Fact]//16.5 XML B2B
        public async Task GetInboundShipmentList_XML_B2B()
        {
            var request = new GetShipmentListRequest()
            {

                RequestBody = new GetShipmentListRequestBody()
                {
                    KeywordsType = ShipKeywordsType.ShipmentID,
                    KeywordsValue = "21UYNT6Z2217K",
                    Status = ShipStatus.All,
                    LastUpdateDateFrom = "01/01/2018",
                    LastUpdateDateTo = "04/30/2019",
                    PageInfo = new SBNPageInfo()
                    {
                        PageIndex = 1,
                        PageSize = 10
                    }
                }
            };


            CheckRequestString<GetShipmentListRequest>(request);
            var body = await fadeAPI_B2B_XML.GetInboundShipmentList(request);
            Assert.IsType<GetShipmentListResponse>(body);


        }




        [Fact]//16.6 xml USA
        public async Task GetWarehouseList_XML_USA()
        {
            var request = new GetWarehouseListRequest()
            {
                RequestBody = new GetWarehouseListRequestBody()
                {
                    WarehouseCode = "06"
                }
            };
            CheckRequestString<GetWarehouseListRequest>(request);
            var body = await fadeAPI_USA_XML.GetWarehouseList(request);
            Assert.IsType<GetWarehouseListResponse>(body);




        }
        [Fact]//16.6 xml B2B
        public async Task GetWarehouseList_XML_B2B()
        {
            var request = new GetWarehouseListRequest()
            {
                RequestBody = new GetWarehouseListRequestBody()
                {
                    WarehouseCode = "06"
                }
            };
            CheckRequestString<GetWarehouseListRequest>(request);
            var body = await fadeAPI_B2B_XML.GetWarehouseList(request);
            Assert.IsType<GetWarehouseListResponse>(body);




        }
        [Fact]//16.6 json USA
        public async Task GetWarehouseList_Json_USA()
        {
            var request = new GetWarehouseListRequest()
            {
                RequestBody = new GetWarehouseListRequestBody()
                {
                    WarehouseCode = "06"
                }
            };
            CheckRequestString<GetWarehouseListRequest>(request);

            var body = await fadeAPI_USA_json.GetWarehouseList(request);

            Assert.IsType<GetWarehouseListResponse>(body);


        }
    }
}

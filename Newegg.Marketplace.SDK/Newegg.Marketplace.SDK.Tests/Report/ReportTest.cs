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
using Xunit;

using System.Collections.Generic;
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Report.Model;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Tests.Report
{
    public class ReportTest : TestBase
    {
        private readonly ReportCall api, api_json, fadeAPI_USA_XML, B2Bapi_json, CANapi,
        B2Bapi, fadeAPI_B2B_XML, fadeAPI_CAN_XML;


        public object TestContext { get; private set; }

        public ReportTest()
        {
            api = new ReportCall(USAClientXML);
            api_json = new ReportCall(USAClientJSON);
            B2Bapi = new ReportCall(B2BClientXML);
            B2Bapi_json = new ReportCall(B2BClientJSON);
            CANapi = new ReportCall(CANClientXML);
            fadeAPI_USA_XML = new ReportCall(fakeUSAClientXML);
            fadeAPI_B2B_XML = new ReportCall(fakeB2BClientXML);
            fadeAPI_CAN_XML = new ReportCall(fakeCANClientXML);
        }
        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]//14.2 xml USA
        public async Task GetReportStatus_XML_USA()
        {
            var request = new GetReportStatusRequest()
            {

                RequestBody = new GetReportStatusRequestBody()
                {
                    GetRequestStatus = new GetShipmentStatusRequestCriteria()
                    {
                        RequestIDList = new List<string>()
                       {"ZF84RMEHYO1C"},
                        MaxCount = 20
                    }
                }
            };

            CheckRequestString<GetReportStatusRequest>(request);
            var body = await fadeAPI_USA_XML.GetReportStatus(request);

            Assert.IsType<GetReportStatusResponse>(body);


        }
        [Fact]//14.2 xml B2B
        public async Task GetReportStatus_XML_B2B()
        {
            var request = new GetReportStatusRequest()
            {

                RequestBody = new GetReportStatusRequestBody()
                {
                    GetRequestStatus = new GetShipmentStatusRequestCriteria()
                    {
                        RequestIDList = new List<string>()
                       {"ZF84RMEHYO1C"},
                        MaxCount = 20
                    }
                }
            };

            CheckRequestString<GetReportStatusRequest>(request);
            var body = await fadeAPI_B2B_XML.GetReportStatus(request);

            Assert.IsType<GetReportStatusResponse>(body);


        }
        [Fact]//14.2 xml CAN
        public async Task GetReportStatus_XML_CAN()
        {
            var request = new GetReportStatusRequest()
            {

                RequestBody = new GetReportStatusRequestBody()
                {
                    GetRequestStatus = new GetShipmentStatusRequestCriteria()
                    {
                        RequestIDList = new List<string>()
                       {"ZF84RMEHYO1C"},
                        MaxCount = 20
                    }
                }
            };

            CheckRequestString<GetReportStatusRequest>(request);
            var body = await fadeAPI_CAN_XML.GetReportStatus(request);

            Assert.IsType<GetReportStatusResponse>(body);


        }



        [Fact]//14.1-1: XML USA
        public async Task SubmitOrderListReport_XML_USA()
        {
            var request = new SubmitOrderListReportRequest()
            {

                RequestBody = new SubmitOrderListReportRequestBody()
                {
                    OrderReportCriteria = new RequestOrderReportCriteria()
                    {
                        RequestType = ReportRequestType.ORDER_LIST_REPORT.ToString(),
                        // VoidSoon=24,
                        KeywordsType = 0,
                        Status = ReportStatus.Shipped,
                        Type = ReportInfoType.All,
                        OrderDateFrom = "2018-01-01",
                        OrderDateTo = "2019-06-14",
                        OrderDownloaded = "false"
                        // CountryCode="USA",
                        // PremierOrder="1",

                    }
                }
            };
            CheckRequestString<SubmitOrderListReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitOrderListReport(request);

            Assert.IsType<SubmitOrderListReportResponse>(body);

        }
        [Fact]//14.1-1: XML B2B
        public async Task SubmitOrderListReport_XML_B2B()
        {
            var request = new SubmitOrderListReportRequest()
            {

                RequestBody = new SubmitOrderListReportRequestBody()
                {
                    OrderReportCriteria = new RequestOrderReportCriteria()
                    {
                        RequestType = ReportRequestType.ORDER_LIST_REPORT.ToString(),
                        // VoidSoon=24,
                        KeywordsType = 0,
                        Status = ReportStatus.Shipped,
                        Type = ReportInfoType.All,
                        OrderDateFrom = "2018-01-01",
                        OrderDateTo = "2019-06-14",
                        OrderDownloaded = "false"
                        // CountryCode="USA",
                        // PremierOrder="1",

                    }
                }
            };
            CheckRequestString<SubmitOrderListReportRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitOrderListReport(request);

            Assert.IsType<SubmitOrderListReportResponse>(body);

        }
        [Fact]//14.1-1: XML CAN
        public async Task SubmitOrderListReport_XML_CAN()
        {
            var request = new SubmitOrderListReportRequest()
            {

                RequestBody = new SubmitOrderListReportRequestBody()
                {
                    OrderReportCriteria = new RequestOrderReportCriteria()
                    {
                        RequestType = ReportRequestType.ORDER_LIST_REPORT.ToString(),
                        // VoidSoon=24,
                        KeywordsType = 0,
                        Status = ReportStatus.Shipped,
                        Type = ReportInfoType.All,
                        OrderDateFrom = "2018-01-01",
                        OrderDateTo = "2019-06-14",
                        OrderDownloaded = "false"
                        // CountryCode="USA",
                        // PremierOrder="1",

                    }
                }
            };
            CheckRequestString<SubmitOrderListReportRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitOrderListReport(request);

            Assert.IsType<SubmitOrderListReportResponse>(body);

        }





        [Fact]//14.1-2: XML USA
        public async Task SubmitSettlementSummaryReport_XML_USA()
        {
            var request = new SettlementSummaryReportRequest()
            {

                RequestBody = new SettlementSummaryReportRequestBody()
                {
                    SettlementSummaryReportCriteria = new SettlementSummaryReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_SUMMARY_REPORT.ToString(),
                        DateFrom = "2017-01-23",
                        DateTo = "2019-12-31"

                    }
                }
            };

            CheckRequestString<SettlementSummaryReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitSettlementSummaryReport(request);

            Assert.IsType<SettlementSummaryReportResponse>(body);


        }

        [Fact]//14.1-2: XML B2B
        public async Task SubmitSettlementSummaryReport_XML_B2B()
        {
            var request = new SettlementSummaryReportRequest()
            {

                RequestBody = new SettlementSummaryReportRequestBody()
                {
                    SettlementSummaryReportCriteria = new SettlementSummaryReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_SUMMARY_REPORT.ToString(),
                        DateFrom = "2017-01-23",
                        DateTo = "2019-12-31"

                    }
                }
            };

            CheckRequestString<SettlementSummaryReportRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitSettlementSummaryReport(request);

            Assert.IsType<SettlementSummaryReportResponse>(body);


        }

        [Fact]//14.1-2: XML CAN
        public async Task SubmitSettlementSummaryReport_XML_CAN()
        {
            var request = new SettlementSummaryReportRequest()
            {

                RequestBody = new SettlementSummaryReportRequestBody()
                {
                    SettlementSummaryReportCriteria = new SettlementSummaryReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_SUMMARY_REPORT.ToString(),
                        DateFrom = "2017-01-23",
                        DateTo = "2019-12-31"

                    }
                }
            };

            CheckRequestString<SettlementSummaryReportRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitSettlementSummaryReport(request);

            Assert.IsType<SettlementSummaryReportResponse>(body);


        }




        [Fact]//14.1-3: XML USA
        public async Task SubmitSettlementTransactionReport_XML_USA()
        {
            var request = new SettlementTransactionRequest()
            {

                RequestBody = new SettlementTransactionRequestBody()
                {
                    SettlementTransactionReportCriteria = new SettlementTransactionReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_TRANSACTION_REPORT.ToString(),
                        TransactionType = ReportTransactionType.All,
                        SettlementDateFrom = "2017-01-01",
                        SettlementDateTo = "2019-12-31",
                        SettlementDate = "03/11/2019"
                    }
                }
            };

            CheckRequestString<SettlementTransactionRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitSettlementTransactionReport(request);
            Assert.IsType<SettlementTransactionResponse>(body);


        }
        [Fact]//14.1-3: XML B2B
        public async Task SubmitSettlementTransactionReport_XML_B2B()
        {
            var request = new SettlementTransactionRequest()
            {

                RequestBody = new SettlementTransactionRequestBody()
                {
                    SettlementTransactionReportCriteria = new SettlementTransactionReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_TRANSACTION_REPORT.ToString(),
                        TransactionType = ReportTransactionType.All,
                        SettlementDateFrom = "2017-01-01",
                        SettlementDateTo = "2019-12-31",
                        SettlementDate = "03/11/2019"
                    }
                }
            };

            CheckRequestString<SettlementTransactionRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitSettlementTransactionReport(request);
            Assert.IsType<SettlementTransactionResponse>(body);


        }
        [Fact]//14.1-3: XML CAN
        public async Task SubmitSettlementTransactionReport_XML_CAN()
        {
            var request = new SettlementTransactionRequest()
            {

                RequestBody = new SettlementTransactionRequestBody()
                {
                    SettlementTransactionReportCriteria = new SettlementTransactionReportCriteria()
                    {
                        RequestType = ReportRequestType.SETTLEMENT_TRANSACTION_REPORT.ToString(),
                        TransactionType = ReportTransactionType.All,
                        SettlementDateFrom = "2017-01-01",
                        SettlementDateTo = "2019-12-31",
                        SettlementDate = "03/11/2019"
                    }
                }
            };

            CheckRequestString<SettlementTransactionRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitSettlementTransactionReport(request);
            Assert.IsType<SettlementTransactionResponse>(body);


        }

        [Fact]//14.1-4: XML USA
        public async Task SubmitRMAListReport_XML_USA()
        {
            var request = new SubmitRMAListReportRequest()
            {

                RequestBody = new SubmitRMAListReportRequestBody()
                {
                    RMAListReportCriteria = new RMAListReportCriteria()
                    {
                        RequestType = ReportRequestType.RMA_LIST_REPORT.ToString(),
                        KeywordsType = ReportKeywordsType.OrderNumber,
                        KeywordsValue = "20169816",
                        Status = RMAReportStatus.All,
                        RMADateFrom = "2015-01-11",
                        RMADateTo = "2019-12-30",
                        RMAType = ReportRMAType.All,
                        ProcessedBy = ReportProcessedBy.All
                    }
                }
            };


            CheckRequestString<SubmitRMAListReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitRMAListReport(request);

            Assert.IsType<SubmitRMAListReportResponse>(body);


        }
        [Fact]//14.1-4: XML B2B
        public async Task SubmitRMAListReport_XML_B2B()
        {
            var request = new SubmitRMAListReportRequest()
            {

                RequestBody = new SubmitRMAListReportRequestBody()
                {
                    RMAListReportCriteria = new RMAListReportCriteria()
                    {
                        RequestType = ReportRequestType.RMA_LIST_REPORT.ToString(),
                        KeywordsType = ReportKeywordsType.OrderNumber,
                        KeywordsValue = "20169816",
                        Status = RMAReportStatus.All,
                        RMADateFrom = "2015-01-11",
                        RMADateTo = "2019-12-30",
                        RMAType = ReportRMAType.All,
                        ProcessedBy = ReportProcessedBy.All
                    }
                }
            };


            CheckRequestString<SubmitRMAListReportRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitRMAListReport(request);

            Assert.IsType<SubmitRMAListReportResponse>(body);


        }
        [Fact]//14.1-4: XML CAN
        public async Task SubmitRMAListReport_XML_CAN()
        {
            var request = new SubmitRMAListReportRequest()
            {

                RequestBody = new SubmitRMAListReportRequestBody()
                {
                    RMAListReportCriteria = new RMAListReportCriteria()
                    {
                        RequestType = ReportRequestType.RMA_LIST_REPORT.ToString(),
                        KeywordsType = ReportKeywordsType.OrderNumber,
                        KeywordsValue = "20169816",
                        Status = RMAReportStatus.All,
                        RMADateFrom = "2015-01-11",
                        RMADateTo = "2019-12-30",
                        RMAType = ReportRMAType.All,
                        ProcessedBy = ReportProcessedBy.All
                    }
                }
            };


            CheckRequestString<SubmitRMAListReportRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitRMAListReport(request);

            Assert.IsType<SubmitRMAListReportResponse>(body);


        }




        [Fact]//14.1-5:XML USA
        public async Task SubmitItemLookupReport_XML_USA()
        {
            var request = new ItemLookupRequest()
            {

                RequestBody = new ItemLookupRequestBody()
                {
                    RequestCriteria = new List<ItemLookupRequestCriteria>
                    {
                        new ItemLookupRequestCriteria()
                        {
                             // Condition=ReportCondition.New,
                               UPC="886111563425",
                               ManufacturerName="652241-B21",
                               ManufacturerPartNumber="HP",
                                PacksOrSets=1
                        }
                    }
                }
            };


            CheckRequestString<ItemLookupRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitItemLookupReport(request);

            Assert.IsType<ItemLookupResponse>(body);


        }
        [Fact]//14.1-5:XML B2B
        public async Task SubmitItemLookupReport_XML_B2B()
        {
            var request = new ItemLookupRequest()
            {

                RequestBody = new ItemLookupRequestBody()
                {
                    RequestCriteria = new List<ItemLookupRequestCriteria>
                    {
                        new ItemLookupRequestCriteria()
                        {
                             // Condition=ReportCondition.New,
                               UPC="886111563425",
                               ManufacturerName="652241-B21",
                               ManufacturerPartNumber="HP",
                                PacksOrSets=1
                        }
                    }
                }
            };


            CheckRequestString<ItemLookupRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitItemLookupReport(request);

            Assert.IsType<ItemLookupResponse>(body);


        }
        [Fact]//14.1-5:XML 
        public async Task SubmitItemLookupReport_XML_CAＮ()
        {
            var request = new ItemLookupRequest()
            {

                RequestBody = new ItemLookupRequestBody()
                {
                    RequestCriteria = new List<ItemLookupRequestCriteria>
                    {
                        new ItemLookupRequestCriteria()
                        {
                             // Condition=ReportCondition.New,
                               UPC="886111563425",
                               ManufacturerName="652241-B21",
                               ManufacturerPartNumber="HP",
                                PacksOrSets=1
                        }
                    }
                }
            };


            CheckRequestString<ItemLookupRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitItemLookupReport(request);

            Assert.IsType<ItemLookupResponse>(body);


        }



        [Fact]//14-1-6:XML USA
        public async Task SubmitDailyInventoryReport_XML_USA()
        {
            var request = new DailyInventoryReportRequest()
            {

                RequestBody = new DailyInventoryReportRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.INTERNATIONAL_INVENTORY_REPORT.ToString(),
                        WarehouseList = new List<string>()
                           {"USA" }

                    }
                }
            };



            CheckRequestString<DailyInventoryReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitDailyInventoryReport(request, 310);

            Assert.IsType<DailyInventoryReportResponse>(body);


        }
        [Fact]//14-1-6:XML B2B
        public async Task SubmitDailyInventoryReport_XML_B2B()
        {
            var request = new DailyInventoryReportRequest()
            {

                RequestBody = new DailyInventoryReportRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.INTERNATIONAL_INVENTORY_REPORT.ToString(),
                        WarehouseList = new List<string>()
                           {"USA" }

                    }
                }
            };



            CheckRequestString<DailyInventoryReportRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitDailyInventoryReport(request, 310);

            Assert.IsType<DailyInventoryReportResponse>(body);


        }
        [Fact]//14-1-6:XML CAN
        public async Task SubmitDailyInventoryReport_XML_CAN()
        {
            var request = new DailyInventoryReportRequest()
            {

                RequestBody = new DailyInventoryReportRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.INTERNATIONAL_INVENTORY_REPORT.ToString(),
                        WarehouseList = new List<string>()
                           {"USA" }

                    }
                }
            };



            CheckRequestString<DailyInventoryReportRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitDailyInventoryReport(request, 310);

            Assert.IsType<DailyInventoryReportResponse>(body);


        }







        [Fact]//14-1-6:xml USA
        public async Task SubmitDailyInventoryReportB2BCAN_XML_USA()
        {
            var request = new DailyInventoryReportB2BCANRequest()
            {

                RequestBody = new DailyInventoryReportB2BCANRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryB2BCANCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.DAILY_INVENTORY_REPORT.ToString()

                    }
                }
            };

            CheckRequestString<DailyInventoryReportB2BCANRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitDailyInventoryReportB2BCAN(request, 310);

            Assert.IsType<DailyInventoryReportB2BCANResponse>(body);


        }
        [Fact]//14-1-6:xml B2B
        public async Task SubmitDailyInventoryReportB2BCAN_XML_B2B()
        {
            var request = new DailyInventoryReportB2BCANRequest()
            {

                RequestBody = new DailyInventoryReportB2BCANRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryB2BCANCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.DAILY_INVENTORY_REPORT.ToString()

                    }
                }
            };

            CheckRequestString<DailyInventoryReportB2BCANRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitDailyInventoryReportB2BCAN(request, 310);

            Assert.IsType<DailyInventoryReportB2BCANResponse>(body);


        }
        [Fact]//14-1-6:xml CAN
        public async Task SubmitDailyInventoryReportB2BCAN_XML_CAN()
        {
            var request = new DailyInventoryReportB2BCANRequest()
            {

                RequestBody = new DailyInventoryReportB2BCANRequestBody()
                {
                    DailyInventoryReportCriteria = new IntlInventoryB2BCANCriteria()
                    {
                        FulfillType = ReportFulfillType.All,
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.DAILY_INVENTORY_REPORT.ToString()

                    }
                }
            };

            CheckRequestString<DailyInventoryReportB2BCANRequest>(request);
            var body = await fadeAPI_CAN_XML.SubmitDailyInventoryReportB2BCAN(request, 310);

            Assert.IsType<DailyInventoryReportB2BCANResponse>(body);


        }



        [Fact]//14-1-7:XML USA
        public async Task SubmitDailyPriceReport_XML_USA()
        {
            var request = new DailyPriceReportRequest()
            {

                RequestBody = new DailyPriceReportRequestBody()
                {
                    DailyPriceReportCriteria = new IntlPriceCriteria()
                    {

                        FileType = ReportFileType.CSV,
                        RequestType = ReportRequestType.INTERNATIONAL_PRICE_REPORT.ToString(),
                        CountryList = new List<string>()
                           {"USA" ,"AUS"}

                    }
                }
            };

            CheckRequestString<DailyPriceReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitDailyPriceReport(request, 310);

            Assert.IsType<DailyPriceReportResponse>(body);


        }



        [Fact]//14-1-8:XML USA
        public async Task SubmitNeweggPremierItemReport_XML_USA()
        {
            var request = new PremierItemReportRequest()
            {

                RequestBody = new PremierItemReportRequestBody()
                {
                    PremierItemReportCriteria = new PremierItemCriteria()
                    {
                        PremierMark = 0,
                        SubcategoryID = 20,
                        FileType = ReportFileType.CSV,
                        RequestType = ReportRequestType.PREMIER_ITEM_REPORT.ToString()


                    }
                }
            };


            CheckRequestString<PremierItemReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitNeweggPremierItemReport(request);

            Assert.IsType<PremierItemReportResponse>(body);


        }



        [Fact]//14-1-9:XML USA
        public async Task SubmitCaliforniasProposition65WarningReport_XML_USA()
        {
            var request = new CAProp65ReportRequest()
            {

                RequestBody = new CAProp65ReportRequestBody()
                {
                    ItemCAProp65ReportCriteria = new CAProp65ReportCriteria()
                    {

                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.CAPROP65_REPORT.ToString(),


                    }
                }
            };

            CheckRequestString<CAProp65ReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitCaliforniasProposition65WarningReport(request);

            Assert.IsType<CAProp65ReportResponse>(body);


        }
        [Fact]//14-1-9:XML B2B
        public async Task SubmitCaliforniasProposition65WarningReport_XML_B2B()
        {
            var request = new CAProp65ReportRequest()
            {

                RequestBody = new CAProp65ReportRequestBody()
                {
                    ItemCAProp65ReportCriteria = new CAProp65ReportCriteria()
                    {

                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.CAPROP65_REPORT.ToString(),


                    }
                }
            };

            CheckRequestString<CAProp65ReportRequest>(request);
            var body = await fadeAPI_B2B_XML.SubmitCaliforniasProposition65WarningReport(request);

            Assert.IsType<CAProp65ReportResponse>(body);


        }






        [Fact]//14.1-10:XML USA
        public async Task SubmitTaxSettingReportforItemsEnabledforChina_XML_USA()
        {
            var request = new ItemChinaTaxSettingReportRequest()
            {

                RequestBody = new ItemChinaTaxSettingReportRequestBody()
                {
                    ItemChinaTaxSettingReportCriteria = new ItemChinaTaxSettingReport()
                    {

                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.ITEM_CHINATAXSETTING_REPORT.ToString(),


                    }
                }
            };

            CheckRequestString<ItemChinaTaxSettingReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitTaxSettingReportforItemsEnabledforChina(request);

            Assert.IsType<ItemChinaTaxSettingReportResponse>(body);
        }

        //

        [Fact]//14.1-10:XML USA
        public async Task SubmitItemBasicInformationReport_XML_USA()
        {
            var request = new SubmittemBasicInformationReportRequest()
            {

                RequestBody = new IttemBasicInformationReportBody()
                {
                    ItemBasicInfoReportCriteria = new IttemBasicInformationReportCriteria
                    {
                        FileType = ReportFileType.XLS,
                        RequestType = ReportRequestType.ITEM_BASIC_INFO_REPORT.ToString(),
                    }
                }
            };

            CheckRequestString<SubmittemBasicInformationReportRequest>(request);
            var body = await fadeAPI_USA_XML.SubmitItemBasicInformationReport(request);

            Assert.IsType<SubmitItemBasicInformationReportResponse>(body);
        }

        [Fact] //14.3-01: xml USA
        public async Task GetOrderListReport_XML_USA()
        {
            var request = new OrderListReportRequest()
            {

                RequestBody = new OrderListReportRequestBody()
                {
                    RequestID = "23NPUG2D8V21U",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 2,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<OrderListReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetOrderListReport(request, 309);

            Assert.IsType<OrderListReportResponse>(body);

        }
        [Fact] //14.3-01: xml B2B
        public async Task GetOrderListReport_XML_B2B()
        {
            var request = new OrderListReportRequest()
            {

                RequestBody = new OrderListReportRequestBody()
                {
                    RequestID = "23NPUG2D8V21U",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 2,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<OrderListReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetOrderListReport(request, 309);

            Assert.IsType<OrderListReportResponse>(body);

        }
        [Fact] //14.3-01: xml CAN
        public async Task GetOrderListReport_XML_CAN()
        {
            var request = new OrderListReportRequest()
            {

                RequestBody = new OrderListReportRequestBody()
                {
                    RequestID = "23NPUG2D8V21U",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 2,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<OrderListReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetOrderListReport(request, 309);

            Assert.IsType<OrderListReportResponse>(body);

        }





        [Fact]// XML USA
        public async Task GetSettlementSummaryReport_XML_USA()
        {
            var request = new GetSettlementSummaryReportRequest()
            {

                RequestBody = new GetSettlementSummaryReportRequestBody()
                {
                    RequestID = "24SQB8YLHGLSL",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementSummaryReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetSettlementSummaryReport(request);

            Assert.IsType<GetSettlementSummaryInfoResponse>(body);


        }
        [Fact]// XML B2B
        public async Task GetSettlementSummaryReport_XML_B2B()
        {
            var request = new GetSettlementSummaryReportRequest()
            {

                RequestBody = new GetSettlementSummaryReportRequestBody()
                {
                    RequestID = "24SQB8YLHGLSL",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementSummaryReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetSettlementSummaryReport(request);

            Assert.IsType<GetSettlementSummaryInfoResponse>(body);


        }
        [Fact]// XML CAN
        public async Task GetSettlementSummaryReport_XML_CAN()
        {
            var request = new GetSettlementSummaryReportRequest()
            {

                RequestBody = new GetSettlementSummaryReportRequestBody()
                {
                    RequestID = "24SQB8YLHGLSL",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementSummaryReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetSettlementSummaryReport(request);

            Assert.IsType<GetSettlementSummaryInfoResponse>(body);


        }




        [Fact]// XML USA
        public async Task GetSettlementTransactionReport_XML_USA()
        {
            var request = new GetSettlementTransactionReportRequest()
            {

                RequestBody = new GetSettlementTransactionReportRequestBody()
                {
                    RequestID = "25EN5T559Z6JF",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementTransactionReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetSettlementTransactionReport(request);

            Assert.IsType<GetSettlementTransactionReportResponse>(body);


        }
        [Fact]// XML B2B
        public async Task GetSettlementTransactionReport_XML_B2B()
        {
            var request = new GetSettlementTransactionReportRequest()
            {

                RequestBody = new GetSettlementTransactionReportRequestBody()
                {
                    RequestID = "25EN5T559Z6JF",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementTransactionReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetSettlementTransactionReport(request);

            Assert.IsType<GetSettlementTransactionReportResponse>(body);


        }
        [Fact]// XML CAN
        public async Task GetSettlementTransactionReport_XML_CAN()
        {
            var request = new GetSettlementTransactionReportRequest()
            {

                RequestBody = new GetSettlementTransactionReportRequestBody()
                {
                    RequestID = "25EN5T559Z6JF",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetSettlementTransactionReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetSettlementTransactionReport(request);

            Assert.IsType<GetSettlementTransactionReportResponse>(body);


        }




        [Fact]// xml USA
        public async Task GetRMAListReport_XML_USA()
        {
            var request = new GetRMAListReportRequest()
            {

                RequestBody = new GetRMAListReportRequestBody()
                {
                    RequestID = "27UMQ2D8D3CZY",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetRMAListReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetRMAListReport(request, 309);

            Assert.IsType<GetRMAListReportResponse>(body);


        }
        [Fact]// xml B2B
        public async Task GetRMAListReport_XML_B2B()
        {
            var request = new GetRMAListReportRequest()
            {

                RequestBody = new GetRMAListReportRequestBody()
                {
                    RequestID = "27UMQ2D8D3CZY",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetRMAListReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetRMAListReport(request, 309);

            Assert.IsType<GetRMAListReportResponse>(body);


        }
        [Fact]// xml CAN
        public async Task GetRMAListReport_XML_CAN()
        {
            var request = new GetRMAListReportRequest()
            {

                RequestBody = new GetRMAListReportRequestBody()
                {
                    RequestID = "27UMQ2D8D3CZY",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetRMAListReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetRMAListReport(request, 309);

            Assert.IsType<GetRMAListReportResponse>(body);


        }




        [Fact]// XML USA
        public async Task GetItemLookupReport_XML_USA()
        {
            var request = new GetItemLookupReportRequest()
            {

                RequestBody = new GetItemLookupReportRequestBody()
                {
                    RequestID = "23A628IKC7YWW",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetItemLookupReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetItemLookupReport(request);

            Assert.IsType<GetItemLookupReportResponse>(body);


        }
        [Fact]// XML B2B
        public async Task GetItemLookupReport_XML_B2B()
        {
            var request = new GetItemLookupReportRequest()
            {

                RequestBody = new GetItemLookupReportRequestBody()
                {
                    RequestID = "23A628IKC7YWW",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetItemLookupReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetItemLookupReport(request);

            Assert.IsType<GetItemLookupReportResponse>(body);


        }
        [Fact]// XML CAN
        public async Task GetItemLookupReport_XML_CAN()
        {
            var request = new GetItemLookupReportRequest()
            {

                RequestBody = new GetItemLookupReportRequestBody()
                {
                    RequestID = "23A628IKC7YWW",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetItemLookupReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetItemLookupReport(request);

            Assert.IsType<GetItemLookupReportResponse>(body);


        }






        [Fact]// XML USA
        public async Task GetDailyInventoryReport_XML_USA()
        {
            var request = new GetDailyInventoryReportRequest()
            {

                RequestBody = new GetDailyInventoryReportRequestBody()
                {
                    RequestID = "24WIDB87KEHHQ",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetDailyInventoryReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetDailyInventoryReport(request);
            Assert.IsType<GetDailyInventoryReportResponse>(body);


        }

        [Fact]// XML B2B
        public async Task GetDailyInventoryReport_XML_B2B()
        {
            var request = new GetDailyInventoryReportRequest()
            {

                RequestBody = new GetDailyInventoryReportRequestBody()
                {
                    RequestID = "24WIDB87KEHHQ",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetDailyInventoryReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetDailyInventoryReport(request);
            Assert.IsType<GetDailyInventoryReportResponse>(body);


        }

        [Fact]// XML CAN
        public async Task GetDailyInventoryReport_XML_CAN()
        {
            var request = new GetDailyInventoryReportRequest()
            {

                RequestBody = new GetDailyInventoryReportRequestBody()
                {
                    RequestID = "24WIDB87KEHHQ",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetDailyInventoryReportRequest>(request);
            var body = await fadeAPI_CAN_XML.GetDailyInventoryReport(request);
            Assert.IsType<GetDailyInventoryReportResponse>(body);


        }



        [Fact]// XML USA
        public async Task GetDailyPriceReport_XML_USA()
        {
            var request = new GetDailyPriceReportRequest()
            {

                RequestBody = new GetDailyPriceReportRequestBody()
                {
                    RequestID = "26XZV07ERGI8B",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetDailyPriceReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetDailyPriceReport(request);

            Assert.IsType<GetDailyPriceReportResponse>(body);


        }






        [Fact]// XML  B2B
        public async Task GetDailyInventoryReportB2bCan_XML_B2B()
        {
            var request = new GetDailyInventoryReportB2bCanRequest()
            {

                RequestBody = new GetDailyInventoryReportB2bCanRequestBody()
                {
                    RequestID = "27FY2VRBYUKZQ",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetDailyInventoryReportB2bCanRequest>(request);
            var body = await fadeAPI_B2B_XML.GetDailyInventoryReportB2bCan(request);

            Assert.IsType<GetDailyInventoryReportB2bCanResponse>(body);


        }
        [Fact]// XML  CAN
        public async Task GetDailyInventoryReportB2bCan_XML_CAN()
        {
            var request = new GetDailyInventoryReportB2bCanRequest()
            {

                RequestBody = new GetDailyInventoryReportB2bCanRequestBody()
                {
                    RequestID = "27FY2VRBYUKZQ",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetDailyInventoryReportB2bCanRequest>(request);
            var body = await fadeAPI_CAN_XML.GetDailyInventoryReportB2bCan(request);

            Assert.IsType<GetDailyInventoryReportB2bCanResponse>(body);


        }





        [Fact]// XML USA
        public async Task GetNeweggPremierItemReport_XML_USA()
        {
            var request = new GetNeweggPremierItemReportRequest()
            {

                RequestBody = new GetNeweggPremierItemReportRequestBody()
                {
                    RequestID = "210CQTAFHO2N6",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<GetNeweggPremierItemReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetNeweggPremierItemReport(request);

            Assert.IsType<GetNeweggPremierItemReportResponse>(body);


        }



        [Fact]//XML USA
        public async Task GetCaliforniasProposition65WarningReport_XML_USA()
        {
            var request = new CAProp65WarningReportRequest()
            {

                RequestBody = new CAProp65WarningReportRequestBody()
                {
                    RequestID = "26HECBSHO1LBT",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<CAProp65WarningReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetCaliforniasProposition65WarningReport(request);

            Assert.IsType<CAProp65WarningReportResponse>(body);


        }
        [Fact]//XML  B2B
        public async Task GetCaliforniasProposition65WarningReport_XML_B2B()
        {
            var request = new CAProp65WarningReportRequest()
            {

                RequestBody = new CAProp65WarningReportRequestBody()
                {
                    RequestID = "26HECBSHO1LBT",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };

            CheckRequestString<CAProp65WarningReportRequest>(request);
            var body = await fadeAPI_B2B_XML.GetCaliforniasProposition65WarningReport(request);

            Assert.IsType<CAProp65WarningReportResponse>(body);


        }




        [Fact]// XML USA
        public async Task GetTaxSettingReportforItemsEnabledforChina_XML_USA()
        {
            var request = new GetTaxSettingReportRequest()
            {

                RequestBody = new GetTaxSettingReportRequestBody()
                {
                    RequestID = "219O8NZS6DQV0",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<GetTaxSettingReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetTaxSettingReportforItemsEnabledforChina(request);

            Assert.IsType<GetTaxSettingReportResponse>(body);
        }

        [Fact]// XML USA
        public async Task GetItemBasicInformationReport_XML_USA()
        {
            var request = new ItemBasicInformationReportRequest()
            {

                RequestBody = new ItemBasicInformationReportRequestBody()
                {
                    RequestID = "219O8NZS6DQV0",
                    PageInfo = new PageInfo()
                    {
                        PageIndex = 1,

                        PageSize = 10

                    }
                }
            };


            CheckRequestString<ItemBasicInformationReportRequest>(request);
            var body = await fadeAPI_USA_XML.GetItemBasicInformationReport(request);

            Assert.IsType<ItemBasicInformationReportResponse>(body);
        }

    }
}

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

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.RMA;
using Newegg.Marketplace.SDK.RMA.Model;

using Xunit;

namespace Newegg.Marketplace.SDK.Tests.RMA
{
    //public class RMATest : TestBase
    //{
    //    private readonly RMACall api, api_A2EU, api_can;
    //    private readonly RMACall fakeapi;
    //    private readonly RMACall api_json;
    //    private readonly RMACall fakeapi_json;

    //    public RMATest()
    //    {
    //        api = new RMACall(USAClientXML);
    //        fakeapi = new RMACall(fakeUSAClientXML);
    //        api_json = new RMACall(USAClientJSON);
    //        fakeapi_json = new RMACall(fakeUSAClientJSON);
    //        api_can = new RMACall(CANClientXML);
    //    }

    //    void CheckRequestString<T>(T req)
    //    {
    //        XmlSerializer xmlSerializer = new XmlSerializer();
    //        JsonSerializer jsonSerializer = new JsonSerializer(true);
    //        string xmls = xmlSerializer.Serialize<T>(req);
    //        string jsons = jsonSerializer.Serialize<T>(req);
    //    }

    //    [Fact]
    //    public async Task SubmitRMA()
    //    {
    //        var rmainfo = new SubmitRMARequest()
    //        {
    //            RequestBody = new SubmitRMARequestBody()
    //            {
    //                IssueRMA = new SubmitRMARequestBody.SubmitRMAInfo()
    //                {
    //                    RMAType = RMAType.Refund,
    //                    SourceSONumber = 123456789,
    //                    SellerRMANumber = "E12345678",
    //                    AutoReceiveMark = SubmitRMARequestAutoReceiveMark.Yes,
    //                    RMANote = "test RMA",
    //                    RMATransactionList = new List<SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo>()
    //                    {
    //                        new SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo()
    //                        {
    //                            SellerPartNumber = "test00000",
    //                            ReturnQuantity = 10,
    //                            ReturnUnitPrice = 1,
    //                            RefundShippingPrice = 1,
    //                            RMAReason = RMAReason.CarrierDamage
    //                        }
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<SubmitRMARequest>(rmainfo);
    //        var result = await fakeapi.SubmitRMA(rmainfo);
    //        Assert.IsType<SubmitRMAResponse>(result);
    //    }

    //    [Fact]
    //    public async Task SubmitRMA_JSON()
    //    {
    //        var rmainfo = new SubmitRMARequest()
    //        {
    //            RequestBody = new SubmitRMARequestBody()
    //            {
    //                IssueRMA = new SubmitRMARequestBody.SubmitRMAInfo()
    //                {
    //                    RMAType = RMAType.Refund,
    //                    SourceSONumber = 123456789,
    //                    SellerRMANumber = "E12345678",
    //                    AutoReceiveMark = SubmitRMARequestAutoReceiveMark.Yes,
    //                    RMANote = "test RMA",
    //                    RMATransactionList = new List<SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo>()
    //                    {
    //                        new SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo()
    //                        {
    //                            SellerPartNumber = "test00000",
    //                            ReturnQuantity = 10,
    //                            ReturnUnitPrice = 1,
    //                            RefundShippingPrice = 1,
    //                            RMAReason = RMAReason.CarrierDamage
    //                        }
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<SubmitRMARequest>(rmainfo);
    //        var result = await fakeapi_json.SubmitRMA(rmainfo);
    //        Assert.IsType<SubmitRMAResponse>(result);
    //    }

    //    [Fact]
    //    public async Task EditRMA()
    //    {
    //        var rmainfo = new EditRMARequest()
    //        {
    //            RequestBody = new EditRMARequestBody()
    //            {
    //                EditRMAInfo = new EditRMARequestBody.EditRMARequestInfo()
    //                {
    //                    RMANumber = "3454645",
    //                    RMAType = RMAType.Refund,
    //                    SellerRMANumber = "E12131313",
    //                    RMANote = "testtest",
    //                    RMATransactionList = new List<EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo>()
    //                    {
    //                        new EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo()
    //                        {
    //                            SellerPartNumber = "ADASD13131",
    //                            ReturnQuantity = 1,
    //                            RMAReason = RMAReason.Defective
    //                        }
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<EditRMARequest>(rmainfo);
    //        var result = await fakeapi.EditRMA(rmainfo);
    //        Assert.IsType<EditRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }
    //    [Fact]
    //    public async Task EditRMA_Json()
    //    {
    //        var rmainfo = new EditRMARequest()
    //        {
    //            RequestBody = new EditRMARequestBody()
    //            {
    //                EditRMAInfo = new EditRMARequestBody.EditRMARequestInfo()
    //                {
    //                    RMANumber = "3454645",
    //                    RMAType = RMAType.Refund,
    //                    SellerRMANumber = "E12131313",
    //                    RMANote = "testtest",
    //                    RMATransactionList = new List<EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo>()
    //                    {
    //                        new EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo()
    //                        {
    //                            SellerPartNumber = "ADASD13131",
    //                            ReturnQuantity = 1,
    //                            RMAReason = RMAReason.Defective
    //                        }
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<EditRMARequest>(rmainfo);
    //        var result = await fakeapi_json.EditRMA(rmainfo);
    //        Assert.IsType<EditRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task RejectRMA()
    //    {
    //        var rmainfo = new RejectRMARequest()
    //        {
    //            RequestBody = new RejectRMARequestBody()
    //            {
    //                RejectRMAInfo = new RejectRMARequestBody.RejectRMARequestInfo()
    //                {
    //                    RMANumber = 131313,
    //                    RejectReason = RejectRMAReason.Physical_Damage,
    //                    ShipCarrier = RejectRMAShipCarrier.FedEx,
    //                    ShipService = "Fly",
    //                    TrackingNumberList = new List<string>()
    //                    {
    //                        "asdasda13131"
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<RejectRMARequest>(rmainfo);
    //        var result = await fakeapi.RejectRMA(rmainfo);
    //        Assert.IsType<RejectRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task RejectRMA_Json()
    //    {
    //        var rmainfo = new RejectRMARequest()
    //        {
    //            RequestBody = new RejectRMARequestBody()
    //            {
    //                RejectRMAInfo = new RejectRMARequestBody.RejectRMARequestInfo()
    //                {
    //                    RMANumber = 131313,
    //                    RejectReason = RejectRMAReason.Physical_Damage,
    //                    ShipCarrier = RejectRMAShipCarrier.FedEx,
    //                    ShipService = "Fly",
    //                    TrackingNumberList = new List<string>()
    //                    {
    //                        "asdasda13131"
    //                    }
    //                }
    //            }
    //        };
    //        CheckRequestString<RejectRMARequest>(rmainfo);
    //        var result = await fakeapi_json.RejectRMA(rmainfo);
    //        Assert.IsType<RejectRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task VoidRMA()
    //    {
    //        var rmainfo = new VoidRMARequest()
    //        {
    //            RequestBody = new VoidRMARequestBody()
    //            {
    //                VoidRMAInfo = new VoidRMARequestBody.VoidRMARequestInfo()
    //                {
    //                    RMANumber = "134632131",
    //                    VoidReason = "I like, I void"
    //                }
    //            }
    //        };
    //        CheckRequestString<VoidRMARequest>(rmainfo);
    //        var result = await fakeapi.VoidRMA(rmainfo);
    //        Assert.IsType<VoidRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task VoidRMA_Json()
    //    {
    //        var rmainfo = new VoidRMARequest()
    //        {
    //            RequestBody = new VoidRMARequestBody()
    //            {
    //                VoidRMAInfo = new VoidRMARequestBody.VoidRMARequestInfo()
    //                {
    //                    RMANumber = "134632131",
    //                    VoidReason = "I like, I void"
    //                }
    //            }
    //        };
    //        CheckRequestString<VoidRMARequest>(rmainfo);
    //        var result = await fakeapi_json.VoidRMA(rmainfo);
    //        Assert.IsType<VoidRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task ReceiveRMA()
    //    {
    //        var rmainfo = new ReceiveRMARequest()
    //        {
    //            RequestBody = new ReceiveRMARequestBody()
    //            {
    //                ReceiveRMAInfo = new ReceiveRMARequestBody.ReceiveRMARequestInfo()
    //                {
    //                    RMANumber = "134632131"
    //                }
    //            }
    //        };
    //        CheckRequestString<ReceiveRMARequest>(rmainfo);
    //        var result = await fakeapi.ReceiveRMA(rmainfo);
    //        Assert.IsType<ReceiveRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task ReceiveRMA_Json()
    //    {
    //        var rmainfo = new ReceiveRMARequest()
    //        {
    //            RequestBody = new ReceiveRMARequestBody()
    //            {
    //                ReceiveRMAInfo = new ReceiveRMARequestBody.ReceiveRMARequestInfo()
    //                {
    //                    RMANumber = "134632131"
    //                }
    //            }
    //        };
    //        CheckRequestString<ReceiveRMARequest>(rmainfo);
    //        var result = await fakeapi_json.ReceiveRMA(rmainfo);
    //        Assert.IsType<ReceiveRMAResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task GetRMAInformation()
    //    {
    //        var rmainfo = new GetRMAInformationRequest()
    //        {
    //            RequestBody = new GetRMAInformationRequestBody()
    //            {
    //                KeywordsType = GetRMAInfoKeywordsType.RMANumber,
    //                KeywordsValue = "20588750"
    //            }
    //        };
    //        CheckRequestString<GetRMAInformationRequest>(rmainfo);
    //        var result = await api.GetRMAInformation(rmainfo);
    //        Assert.IsType<GetRMAInformationResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfoList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task GetRMAInformation_CAN()
    //    {
    //        var rmainfo = new GetRMAInformationRequest()
    //        {
    //            RequestBody = new GetRMAInformationRequestBody()
    //            {
    //                KeywordsType = GetRMAInfoKeywordsType.RMANumber,
    //                KeywordsValue = "21821249",
    //                Status = RMAStatus.All,
    //                RMADateFrom = "2018-01-11",
    //                RMADateTo = "2019-12-30",
    //                RMAType = RMAType.Refund,
    //                ProcessedBy = RMAProcessedBy.All
    //            }
    //        };
    //        CheckRequestString<GetRMAInformationRequest>(rmainfo);
    //        var result = await api_can.GetRMAInformation(rmainfo);
    //        Assert.IsType<GetRMAInformationResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfoList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task GetRMAInformation_Json()
    //    {
    //        var rmainfo = new GetRMAInformationRequest()
    //        {
    //            RequestBody = new GetRMAInformationRequestBody()
    //            {
    //                KeywordsType = GetRMAInfoKeywordsType.RMANumber,
    //                KeywordsValue = "21821229",
    //                Status = RMAStatus.All,
    //                RMADateFrom = "2018-01-11",
    //                RMADateTo = "2019-12-30",
    //                RMAType = RMAType.All,
    //                ProcessedBy = RMAProcessedBy.All
    //            }
    //        };
    //        CheckRequestString<GetRMAInformationRequest>(rmainfo);
    //        var result = await api_A2EU.GetRMAInformation(rmainfo);
    //        Assert.IsType<GetRMAInformationResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.RMAInfoList.Count > 0);
    //    }

    //    [Fact]
    //    public async Task IssueCourtesyRefund()
    //    {
    //        var rmainfo = new IssueCourtesyRefundRequest()
    //        {
    //            RequestBody = new IssueCourtesyRefundRequestBody()
    //            {
    //                IssueCourtesyRefund = new IssueCourtesyRefundRequestBody.IssueCourtesyRefundRequestInfo()
    //                {
    //                    SourceSONumber = "299395404",
    //                    RefundReason = CourtesyRefundReason.ShippingDelay,
    //                    TotalRefundAmount = 0.72m,
    //                    NoteToCustomer = "can courtesy refund 0528"
    //                }
    //            }
    //        };
    //        CheckRequestString<IssueCourtesyRefundRequest>(rmainfo);
    //        var result = await fakeapi.IssueCourtesyRefund(rmainfo);
    //        Assert.IsType<IssueCourtesyRefundResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.ResponseList.ResponseInfo.RequestStatus == CourtesyRefundRequestStatus.SUBMITTED);
    //    }
    //    [Fact]
    //    public async Task IssueCourtesyRefund_Json()
    //    {
    //        var rmainfo = new IssueCourtesyRefundRequest()
    //        {
    //            RequestBody = new IssueCourtesyRefundRequestBody()
    //            {
    //                IssueCourtesyRefund = new IssueCourtesyRefundRequestBody.IssueCourtesyRefundRequestInfo()
    //                {
    //                    SourceSONumber = "1313213",
    //                    RefundReason = CourtesyRefundReason.PricingError,
    //                    TotalRefundAmount = 999,
    //                    NoteToCustomer = "just test"
    //                }
    //            }
    //        };
    //        CheckRequestString<IssueCourtesyRefundRequest>(rmainfo);
    //        var result = await fakeapi_json.IssueCourtesyRefund(rmainfo);
    //        Assert.IsType<IssueCourtesyRefundResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.ResponseList.ResponseInfo.RequestStatus == CourtesyRefundRequestStatus.SUBMITTED);
    //    }

    //    [Fact]
    //    public async Task GetCourtesyRefundRequestStatus()
    //    {
    //        var rmainfo = new GetCourtesyRefundRequestStatusRequest()
    //        {
    //            RequestBody = new GetCourtesyRefundRequestStatusRequestBody()
    //            {
    //                GetRequestStatus = new GetCourtesyRefundRequestStatusRequestBody.GetCourtesyRefundRequestStatusInfo()
    //                {
    //                    RequestIDList = new List<string>() { "b58ca167-c119-4a1f-ad36-c7ada8a0b8a5" },
    //                    RequestStatus = CourtesyRefundRequestStatus.ALL
    //                }
    //            }
    //        };
    //        CheckRequestString<GetCourtesyRefundRequestStatusRequest>(rmainfo);
    //        var result = await fakeapi.GetCourtesyRefundRequestStatus(rmainfo);
    //        Assert.IsType<GetCourtesyRefundRequestStatusResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.Equal("COURTESYREFUND", result.ResponseBody.ResponseList.ResponseInfo.RequestType);
    //    }
    //    [Fact]
    //    public async Task GetCourtesyRefundRequestStatus_Json()
    //    {
    //        var rmainfo = new GetCourtesyRefundRequestStatusRequest()
    //        {
    //            RequestBody = new GetCourtesyRefundRequestStatusRequestBody()
    //            {
    //                GetRequestStatus = new GetCourtesyRefundRequestStatusRequestBody.GetCourtesyRefundRequestStatusInfo()
    //                {
    //                    RequestIDList = new List<string>() { "b58ca167-c119-4a1f-ad36-c7ada8a0b8a5" },
    //                    RequestStatus = CourtesyRefundRequestStatus.ALL
    //                }
    //            }
    //        };
    //        CheckRequestString<GetCourtesyRefundRequestStatusRequest>(rmainfo);
    //        var result = await fakeapi_json.GetCourtesyRefundRequestStatus(rmainfo);
    //        Assert.IsType<GetCourtesyRefundRequestStatusResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.Equal("COURTESYREFUND", result.ResponseBody.ResponseList.ResponseInfo.RequestType);
    //    }

    //    [Fact]
    //    public async Task GetCourtesyRefundInformation()
    //    {
    //        var rmainfo = new GetCourtesyRefundInformationRequest()
    //        {
    //            RequestBody = new GetCourtesyRefundInformationRequestBody()
    //            {
    //                KeywordsType = CourtesyRefundKeywordsType.All,
    //                Status = CourtesyRefundStatus.All
    //            }
    //        };
    //        CheckRequestString<GetCourtesyRefundInformationRequest>(rmainfo);
    //        var result = await fakeapi.GetCourtesyRefundInformation(rmainfo);
    //        Assert.IsType<GetCourtesyRefundInformationResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.CourtesyRefundInfoList.Count > 0);
    //    }
    //    [Fact]
    //    public async Task GetCourtesyRefundInformation_Json()
    //    {
    //        var rmainfo = new GetCourtesyRefundInformationRequest()
    //        {
    //            RequestBody = new GetCourtesyRefundInformationRequestBody()
    //            {
    //                KeywordsType = CourtesyRefundKeywordsType.All,
    //                Status = CourtesyRefundStatus.All
    //            }
    //        };
    //        CheckRequestString<GetCourtesyRefundInformationRequest>(rmainfo);
    //        var result = await fakeapi_json.GetCourtesyRefundInformation(rmainfo);
    //        Assert.IsType<GetCourtesyRefundInformationResponse>(result);
    //        Assert.True(result.IsSuccess);
    //        Assert.True(result.ResponseBody.CourtesyRefundInfoList.Count > 0);
    //    }
    //}
    public class RMAFakeTest : TestBase
    {
        private readonly RMACall fakeapi, fakeapi_json;

        public RMAFakeTest()
        {
            fakeapi = new RMACall(fakeUSAClientXML);
            fakeapi_json = new RMACall(fakeUSAClientJSON);
        }

        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public async Task SubmitRMA()
        {
            var rmainfo = new SubmitRMARequest()
            {
                RequestBody = new SubmitRMARequestBody()
                {
                    IssueRMA = new SubmitRMARequestBody.SubmitRMAInfo()
                    {
                        RMAType = RMAType.Refund,
                        SourceSONumber = 299232884,
                        SellerRMANumber = "E12345678",
                        AutoReceiveMark = SubmitRMARequestAutoReceiveMark.No,
                        RMANote = "API test refund RMA201601061001",
                        RMATransactionList = new List<SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo>()
                        {
                            new SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo()
                            {
                                SellerPartNumber = "Test_SP#A2EU_20181108_0003",
                                ReturnQuantity = 1,
                                ReturnUnitPrice = 0.02m,
                                RefundShippingPrice = 0.00m,
                                RMAReason = RMAReason.Defective
                            }
                        }
                    }
                }
            };
            CheckRequestString<SubmitRMARequest>(rmainfo);
            var result = await fakeapi.SubmitRMA(rmainfo);
            Assert.IsType<SubmitRMAResponse>(result);
            Assert.Equal("299232884", result.ResponseBody.RMAInfo.OrderNumber);
        }

        [Fact]
        public async Task SubmitRMA_Json()
        {
            var rmainfo = new SubmitRMARequest()
            {
                RequestBody = new SubmitRMARequestBody()
                {
                    IssueRMA = new SubmitRMARequestBody.SubmitRMAInfo()
                    {
                        RMAType = RMAType.Refund,
                        SourceSONumber = 299232884,
                        SellerRMANumber = "E12345678",
                        AutoReceiveMark = SubmitRMARequestAutoReceiveMark.No,
                        RMANote = "API test refund RMA201601061001",
                        RMATransactionList = new List<SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo>()
                        {
                            new SubmitRMARequestBody.SubmitRMAInfo.RMATransactionInfo()
                            {
                                SellerPartNumber = "Test_SP#A2EU_20181108_0003",
                                ReturnQuantity = 1,
                                ReturnUnitPrice = 0.02m,
                                RefundShippingPrice = 0.00m,
                                RMAReason = RMAReason.Defective
                            }
                        }
                    }
                }
            };
            CheckRequestString<SubmitRMARequest>(rmainfo);
            var result = await fakeapi_json.SubmitRMA(rmainfo);
            Assert.IsType<SubmitRMAResponse>(result);
            Assert.Equal("299232884", result.ResponseBody.RMAInfo.OrderNumber);
        }

        [Fact]
        public async Task EditRMA()
        {
            var rmainfo = new EditRMARequest()
            {
                RequestBody = new EditRMARequestBody()
                {
                    EditRMAInfo = new EditRMARequestBody.EditRMARequestInfo()
                    {
                        RMANumber = "21821229",
                        RMAType = RMAType.Refund,
                        SellerRMANumber = "E12131313",
                        RMANote = "testtest",
                        RMATransactionList = new List<EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo>()
                        {
                            new EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo()
                            {
                                SellerPartNumber = "Test_SP#A2EU_20181108_0003",
                                ReturnQuantity = 1,
                                ReturnUnitPrice = 0.02m,
                                RefundShippingPrice = 0.00m,
                                RMAReason = RMAReason.Defective
                            }
                        }
                    }
                }
            };
            CheckRequestString<EditRMARequest>(rmainfo);
            var result = await fakeapi.EditRMA(rmainfo);
            Assert.IsType<EditRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task EditRMA_Json()
        {
            var rmainfo = new EditRMARequest()
            {
                RequestBody = new EditRMARequestBody()
                {
                    EditRMAInfo = new EditRMARequestBody.EditRMARequestInfo()
                    {
                        RMANumber = "21821229",
                        RMAType = RMAType.Refund,
                        SellerRMANumber = "E12131313",
                        RMANote = "testtest",
                        RMATransactionList = new List<EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo>()
                        {
                            new EditRMARequestBody.EditRMARequestInfo.RMATransactionInfo()
                            {
                                SellerPartNumber = "Test_SP#A2EU_20181108_0003",
                                ReturnQuantity = 1,
                                ReturnUnitPrice = 0.02m,
                                RefundShippingPrice = 0.00m,
                                RMAReason = RMAReason.Defective
                            }
                        }
                    }
                }
            };
            CheckRequestString<EditRMARequest>(rmainfo);
            var result = await fakeapi_json.EditRMA(rmainfo);
            Assert.IsType<EditRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task RejectRMA()
        {
            var rmainfo = new RejectRMARequest()
            {
                RequestBody = new RejectRMARequestBody()
                {
                    RejectRMAInfo = new RejectRMARequestBody.RejectRMARequestInfo()
                    {
                        RMANumber = 131313,
                        RejectReason = RejectRMAReason.Physical_Damage,
                        ShipCarrier = RejectRMAShipCarrier.FedEx,
                        ShipService = "Fly",
                        TrackingNumberList = new List<string>()
                        {
                            "asdasda13131"
                        }
                    }
                }
            };
            CheckRequestString<RejectRMARequest>(rmainfo);
            var result = await fakeapi.RejectRMA(rmainfo);
            Assert.IsType<RejectRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task RejectRMA_Json()
        {
            var rmainfo = new RejectRMARequest()
            {
                RequestBody = new RejectRMARequestBody()
                {
                    RejectRMAInfo = new RejectRMARequestBody.RejectRMARequestInfo()
                    {
                        RMANumber = 131313,
                        RejectReason = RejectRMAReason.Physical_Damage,
                        ShipCarrier = RejectRMAShipCarrier.FedEx,
                        ShipService = "Fly",
                        TrackingNumberList = new List<string>()
                        {
                            "asdasda13131"
                        }
                    }
                }
            };
            CheckRequestString<RejectRMARequest>(rmainfo);
            var result = await fakeapi_json.RejectRMA(rmainfo);
            Assert.IsType<RejectRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task VoidRMA()
        {
            var rmainfo = new VoidRMARequest()
            {
                RequestBody = new VoidRMARequestBody()
                {
                    VoidRMAInfo = new VoidRMARequestBody.VoidRMARequestInfo()
                    {
                        RMANumber = "134632131",
                        VoidReason = "I like, I void"
                    }
                }
            };
            CheckRequestString<VoidRMARequest>(rmainfo);
            var result = await fakeapi.VoidRMA(rmainfo);
            Assert.IsType<VoidRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task VoidRMA_Json()
        {
            var rmainfo = new VoidRMARequest()
            {
                RequestBody = new VoidRMARequestBody()
                {
                    VoidRMAInfo = new VoidRMARequestBody.VoidRMARequestInfo()
                    {
                        RMANumber = "134632131",
                        VoidReason = "I like, I void"
                    }
                }
            };
            CheckRequestString<VoidRMARequest>(rmainfo);
            var result = await fakeapi_json.VoidRMA(rmainfo);
            Assert.IsType<VoidRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task ReceiveRMA()
        {
            var rmainfo = new ReceiveRMARequest()
            {
                RequestBody = new ReceiveRMARequestBody()
                {
                    ReceiveRMAInfo = new ReceiveRMARequestBody.ReceiveRMARequestInfo()
                    {
                        RMANumber = "134632131"
                    }
                }
            };
            CheckRequestString<ReceiveRMARequest>(rmainfo);
            var result = await fakeapi.ReceiveRMA(rmainfo);
            Assert.IsType<ReceiveRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task ReceiveRMA_Json()
        {
            var rmainfo = new ReceiveRMARequest()
            {
                RequestBody = new ReceiveRMARequestBody()
                {
                    ReceiveRMAInfo = new ReceiveRMARequestBody.ReceiveRMARequestInfo()
                    {
                        RMANumber = "134632131"
                    }
                }
            };
            CheckRequestString<ReceiveRMARequest>(rmainfo);
            var result = await fakeapi_json.ReceiveRMA(rmainfo);
            Assert.IsType<ReceiveRMAResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfo.RMATransactionList.Count > 0);
        }

        [Fact]
        public async Task GetRMAInformation()
        {
            var rmainfo = new GetRMAInformationRequest()
            {
                RequestBody = new GetRMAInformationRequestBody()
                {
                    KeywordsType = GetRMAInfoKeywordsType.RMANumber,
                    KeywordsValue = "21821229",
                    Status = RMAStatus.All,
                    RMADateFrom = "2018-01-11",
                    RMADateTo = "2019-12-30",
                    RMAType = RMAType.All,
                    ProcessedBy = RMAProcessedBy.All
                }
            };
            CheckRequestString<GetRMAInformationRequest>(rmainfo);
            var result = await fakeapi.GetRMAInformation(rmainfo);
            Assert.IsType<GetRMAInformationResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfoList.Count > 0);
        }

        [Fact]
        public async Task GetRMAInformation_Json()
        {
            var rmainfo = new GetRMAInformationRequest()
            {
                RequestBody = new GetRMAInformationRequestBody()
                {
                    KeywordsType = GetRMAInfoKeywordsType.RMANumber,
                    KeywordsValue = "21821229",
                    Status = RMAStatus.All,
                    RMADateFrom = "2018-01-11",
                    RMADateTo = "2019-12-30",
                    RMAType = RMAType.All,
                    ProcessedBy = RMAProcessedBy.All
                }
            };
            CheckRequestString<GetRMAInformationRequest>(rmainfo);
            var result = await fakeapi_json.GetRMAInformation(rmainfo);
            Assert.IsType<GetRMAInformationResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.RMAInfoList.Count > 0);
        }

        [Fact]
        public async Task IssueCourtesyRefund()
        {
            var rmainfo = new IssueCourtesyRefundRequest()
            {
                RequestBody = new IssueCourtesyRefundRequestBody()
                {
                    IssueCourtesyRefund = new IssueCourtesyRefundRequestBody.IssueCourtesyRefundRequestInfo()
                    {
                        SourceSONumber = "299395404",
                        RefundReason = CourtesyRefundReason.WrongItemInformation,
                        TotalRefundAmount = 0.72m,
                        NoteToCustomer = "just test"
                    }
                }
            };
            CheckRequestString<IssueCourtesyRefundRequest>(rmainfo);
            var result = await fakeapi.IssueCourtesyRefund(rmainfo);
            Assert.IsType<IssueCourtesyRefundResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.ResponseList.ResponseInfo.RequestStatus == CourtesyRefundRequestStatus.SUBMITTED);
        }

        [Fact]
        public async Task IssueCourtesyRefund_Json()
        {
            var rmainfo = new IssueCourtesyRefundRequest()
            {
                RequestBody = new IssueCourtesyRefundRequestBody()
                {
                    IssueCourtesyRefund = new IssueCourtesyRefundRequestBody.IssueCourtesyRefundRequestInfo()
                    {
                        SourceSONumber = "299395404",
                        RefundReason = CourtesyRefundReason.WrongItemInformation,
                        TotalRefundAmount = 0.72m,
                        NoteToCustomer = "just test"
                    }
                }
            };
            CheckRequestString<IssueCourtesyRefundRequest>(rmainfo);
            var result = await fakeapi_json.IssueCourtesyRefund(rmainfo);
            Assert.IsType<IssueCourtesyRefundResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.ResponseList.ResponseInfo.RequestStatus == CourtesyRefundRequestStatus.SUBMITTED);
        }

        [Fact]
        public async Task GetCourtesyRefundRequestStatus()
        {
            var rmainfo = new GetCourtesyRefundRequestStatusRequest()
            {
                RequestBody = new GetCourtesyRefundRequestStatusRequestBody()
                {
                    GetRequestStatus = new GetCourtesyRefundRequestStatusRequestBody.GetCourtesyRefundRequestStatusInfo()
                    {
                        RequestIDList = new List<string>() { "8f8648da-7d92-4086-bbe5-e399e07895e6" },
                        RequestStatus = CourtesyRefundRequestStatus.ALL,
                        MaxCount = 100
                    }
                }
            };
            CheckRequestString<GetCourtesyRefundRequestStatusRequest>(rmainfo);
            var result = await fakeapi.GetCourtesyRefundRequestStatus(rmainfo);
            Assert.IsType<GetCourtesyRefundRequestStatusResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.Equal("COURTESYREFUND", result.ResponseBody.ResponseList.ResponseInfo.RequestType);
        }

        [Fact]
        public async Task GetCourtesyRefundRequestStatus_Json()
        {
            var rmainfo = new GetCourtesyRefundRequestStatusRequest()
            {
                RequestBody = new GetCourtesyRefundRequestStatusRequestBody()
                {
                    GetRequestStatus = new GetCourtesyRefundRequestStatusRequestBody.GetCourtesyRefundRequestStatusInfo()
                    {
                        RequestIDList = new List<string>() { "8f8648da-7d92-4086-bbe5-e399e07895e6" },
                        RequestStatus = CourtesyRefundRequestStatus.ALL,
                        MaxCount = 100
                    }
                }
            };
            CheckRequestString<GetCourtesyRefundRequestStatusRequest>(rmainfo);
            var result = await fakeapi_json.GetCourtesyRefundRequestStatus(rmainfo);
            Assert.IsType<GetCourtesyRefundRequestStatusResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.Equal("COURTESYREFUND", result.ResponseBody.ResponseList.ResponseInfo.RequestType);
        }

        [Fact]
        public async Task GetCourtesyRefundInformation()
        {
            var rmainfo = new GetCourtesyRefundInformationRequest()
            {
                RequestBody = new GetCourtesyRefundInformationRequestBody()
                {
                    KeywordsType = CourtesyRefundKeywordsType.All,
                    Status = CourtesyRefundStatus.All,
                    DateFrom = "2019-01-01 09:30:47",
                    DateTo = "2019-12-17 12:30:47"
                }
            };
            CheckRequestString<GetCourtesyRefundInformationRequest>(rmainfo);
            var result = await fakeapi.GetCourtesyRefundInformation(rmainfo);
            Assert.IsType<GetCourtesyRefundInformationResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.CourtesyRefundInfoList.Count > 0);
        }

        [Fact]
        public async Task GetCourtesyRefundInformation_Json()
        {
            var rmainfo = new GetCourtesyRefundInformationRequest()
            {
                RequestBody = new GetCourtesyRefundInformationRequestBody()
                {
                    KeywordsType = CourtesyRefundKeywordsType.All,
                    Status = CourtesyRefundStatus.All,
                    DateFrom = "2019-01-01 09:30:47",
                    DateTo = "2019-12-17 12:30:47"
                }
            };
            CheckRequestString<GetCourtesyRefundInformationRequest>(rmainfo);
            var result = await fakeapi_json.GetCourtesyRefundInformation(rmainfo);
            Assert.IsType<GetCourtesyRefundInformationResponse>(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.ResponseBody.CourtesyRefundInfoList.Count > 0);
        }
    }
}

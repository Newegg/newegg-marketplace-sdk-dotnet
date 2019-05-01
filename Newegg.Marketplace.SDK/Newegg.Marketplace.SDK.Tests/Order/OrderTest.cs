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
using Newegg.Marketplace.SDK.Order;
using Newegg.Marketplace.SDK.Order.Model;

using Xunit;

namespace Newegg.Marketplace.SDK.Tests.Order
{
    public class OrderTest : TestBase
    {
        private readonly OrderCall api, api_B2B, api_CAN;
        private readonly OrderCall fakeapi, fakeapi_B2B;
        private readonly OrderCall api_json;
        private readonly OrderCall fakeapi_json;

        public OrderTest()
        {
            api = new OrderCall(USAClientXML);
            fakeapi = new OrderCall(fakeUSAClientXML);
            api_json = new OrderCall(USAClientJSON);
            fakeapi_json = new OrderCall(fakeUSAClientJSON);
            api_B2B = new OrderCall(B2BClientXML);
            api_CAN = new OrderCall(CANClientXML);
            fakeapi_B2B= new OrderCall(fakeB2BClientJSON);
        }
        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public async Task GetOrderStatus()
        {
            try
            {
                var orderstatus = await fakeapi.GetOrderStatus("105137040", 304);
                Assert.IsType<GetOrderStatusResponse>(orderstatus);
                Assert.Equal("105137040", orderstatus.OrderNumber);
                Assert.True(orderstatus.OrderDownloaded);
                Assert.Equal(OrderFulfillmentOption.ShipBySeller, orderstatus.FulfillmentOption);
                Assert.Equal(OrderSalesChannel.NeweggOrder, orderstatus.SalesChannel);
            }
            catch (SDK.Base.Exception.ApiException e)
            {
                Assert.True(((SDK.Base.Exception.Errors)e.Details).Count > 0);
            }
        }

        [Fact]
        public async Task GetOrderStatus_Json()
        {
            var orderstatus = await fakeapi_json.GetOrderStatus("105137040", 304);
            Assert.IsType<GetOrderStatusResponse>(orderstatus);
            //Assert.Equal("105137040", orderstatus.OrderNumber);
            Assert.True(orderstatus.OrderDownloaded);
            Assert.Equal(OrderFulfillmentOption.ShipBySeller, orderstatus.FulfillmentOption);
            Assert.Equal(OrderSalesChannel.NeweggOrder, orderstatus.SalesChannel);
        }

        [Fact]
        public async Task CancelOrder()
        {
            var cancelorderinfo = new CancelOrderRequest(CancelOrderReason.PriceError);
            CheckRequestString<CancelOrderRequest>(cancelorderinfo);
            var result = await fakeapi.CancelOrder("287811844", 304, cancelorderinfo);
            Assert.IsType<CancelOrderResponse>(result);
            //Assert.Equal("287811844", result.Result.OrderNumber);
        }

        [Fact]
        public async Task ShipOrder()
        {
            ShipmentInfo shipmentInfo = new ShipmentInfo()
            {
                Header = new ShipmentInfo.ShipmentHeader()
                {
                    SONumber = "287811844",
                    SellerID = "A006"
                },
                PackageList = new PackageInfo[]
                {
                    new PackageInfo()
                    {
                        ShipCarrier="Purolator",
                        ShipService="3-5",
                        TrackingNumber="12345",
                        ItemList=new ItemInfo[]
                        {
                            new ItemInfo()
                            {
                                SellerPartNumber="test123",
                                ShippedQty=10
                            }
                        }
                    }
                }
            };
            var shiporderinfo = new ShipOrderRequest(shipmentInfo, USA_Config_XML.APIFormat);
            CheckRequestString<ShipOrderRequest>(shiporderinfo);
            var result = await fakeapi.ShipOrder("287811844", 304, shiporderinfo);
            Assert.IsType<ShipOrderResponse>(result);
            //Assert.Equal("287811844", result.Result.OrderNumber);
        }

        [Fact]
        public async Task OrderConfirmation()
        {
            var orderconfirminfo = new OrderConfirmationRequest(new string[] { "159243598" });
            CheckRequestString<OrderConfirmationRequest>(orderconfirminfo);
            var result = await fakeapi.OrderConfirmation(orderconfirminfo);
            Assert.IsType<OrderConfirmationResponse>(result);
            //Assert.Equal("159243598", result.ResponseBody.DownloadedOrderList[0]);
        }
        [Fact]
        public async Task OrderConfirmation_JSON()
        {
            var orderconfirminfo = new OrderConfirmationRequest(new string[] { "159243598" });
            CheckRequestString<OrderConfirmationRequest>(orderconfirminfo);
            var result = await fakeapi_json.OrderConfirmation(orderconfirminfo);
            Assert.IsType<OrderConfirmationResponse>(result);
            //Assert.Equal("159243598", result.ResponseBody.DownloadedOrderList[0]);
        }

        [Fact]
        public async Task RemoveItem()
        {
            var removeinfo = new RemoveItemRequest(new string[] { "testseller#1", "testseller#2" });
            var result = await fakeapi.RemoveItem("88237462", removeinfo);
            Assert.IsType<RemoveItemResponse>(result);
            //Assert.Equal("88237462", result.ResponseBody.Orders.OrderNumber);
        }

        [Fact]
        public async Task RemoveItem_JSON()
        {
            var removeinfo = new RemoveItemRequest(new string[] { "testseller#1", "testseller#2" });
            var result = await fakeapi_json.RemoveItem("88237462", removeinfo);
            Assert.IsType<RemoveItemResponse>(result);
            //Assert.Equal("88237462", result.ResponseBody.Orders.OrderNumber);
        }

        [Fact]
        public async Task GetOrderInformation()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "126239540" },
                Status = OrderStatus.Invoiced,
                Type = OrderInfoType.All,
                OrderDateFrom = "2018-01-01 09:30:47",
                OrderDateTo = "2018-12-17 09:30:47",
                OrderDownloaded = 0
            });

            var result = await fakeapi.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            //Assert.Equal("126239540", result.ResponseBody.OrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetOrderInformation_JSON()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "287811844" },
                Status = OrderStatus.Voided,
                Type = OrderInfoType.All,
                OrderDateFrom = "2011-01-01 00:00:00",
                OrderDateTo = "2019-01-01 00:00:00",
                OrderDownloaded = 0,
                CountryCode = "USA",
                PremierOrder = 0
            });

            var result = await fakeapi_json.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            //Assert.Equal("287811844", result.ResponseBody.OrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetOrderInformation_B2B()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "1233434480" },
                Status = OrderStatus.Invoiced,
                Type = OrderInfoType.All,
                OrderDateFrom = "2018-01-01 09:30:47",
                OrderDateTo = "2018-12-17 09:30:47",
                OrderDownloaded = 0
            });

            var result = await fakeapi_B2B.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            //Assert.Equal("1233434480", result.ResponseBody.OrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetOrderInformation_CAN()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "299963364" },
                Status = OrderStatus.Invoiced,
                Type = OrderInfoType.All,
                OrderDateFrom = "2018-01-01 09:30:47",
                OrderDateTo = "2018-12-17 09:30:47",
                OrderDownloaded = 0
            });

            var result = await fakeapi.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            //Assert.Equal("299963364", result.ResponseBody.OrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult()
        {
            var result = await fakeapi.GetSBNOrderCancellationRequestResult("138120116");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            //Assert.Equal("138120116", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult_Json()
        {
            var result = await fakeapi_json.GetSBNOrderCancellationRequestResult("138120116");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            //Assert.Equal("138120116", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult_B2B_Error()
        {
            var result = await fakeapi.GetSBNOrderCancellationRequestResult("1233511920");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            //Assert.Equal("1233511920", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult_CAN()
        {
            var result = await fakeapi.GetSBNOrderCancellationRequestResult("279176564");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            //Assert.Equal("279176564", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetAdditionalOrderInformation()
        {
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "238440429", "331510918" },
                OrderDateFrom = "2017-01-11 00:30:47",
                OrderDateTo = "2017-10-31 09:30:47",
                CountryCode = "USA"
            });

            var result = await fakeapi.GetAdditionalOrderInformation(addorderreq);
            Assert.IsType<GetAdditionalOrderInformationResponse>(result);
            //Assert.Equal("238440429", result.ResponseBody.AddOrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetAdditionalOrderInformation_JSON()
        {
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "238440429", "331510918" },
                OrderDateFrom = "2017-01-11 00:30:47",
                OrderDateTo = "2017-10-31 09:30:47",
                CountryCode = "USA"
            });
            CheckRequestString<GetAdditionalOrderInformationRequest>(addorderreq);
            var result = await fakeapi.GetAdditionalOrderInformation(addorderreq);
            Assert.IsType<GetAdditionalOrderInformationResponse>(result);
            //Assert.Equal("238440429", result.ResponseBody.AddOrderInfoList[0].OrderNumber);

        }

        [Fact]
        public async Task OrderConfirmationTest()
        {
            var request = new OrderConfirmationRequest(new OrderConfirmationRequestBody()
            {
                DownloadedOrderList = new List<string> { "105137040", "104905420" }
            });
            var response = await fakeapi.OrderConfirmation(request);
            Assert.IsType<OrderConfirmationResponse>(response);
            Assert.Single(response.ResponseBody.DownloadedOrderList);
        }

        [Fact]
        public void DeserializeTest()
        {
            var serializer = SerializerFactory.GetSerializer(SDK.Base.APIFormat.JSON);
            string json = "{\"NeweggAPIResponse\":{\"IsSuccess\":\"true\",\"OperationType\":\"OrderConfirmationResponse\",\"SellerID\":\"A006\",\"ResponseDate\":\"02/26/2019 15:18:12\",\"ResponseBody\":{\"RequestDate\":\"02/26/2019 15:18:12\",\"DownloadedOrderList\":{\"OrderNumber\":[\"104905420\",\"105137040\"]}}}}";
            OrderConfirmationResponse response = serializer.Deserialize<OrderConfirmationResponse>(json);
            Assert.Equal(2, response.ResponseBody.DownloadedOrderList.Count);

        }

        [Fact]
        public void DeserializeInnerTest()
        {
            var serializer = SerializerFactory.GetSerializer(SDK.Base.APIFormat.JSON);
            string json = "{\"RequestDate\":\"02/26/2019 15:18:12\",\"DownloadedOrderList\":{\"OrderNumber\":[\"104905420\",\"105137040\"]}}";
            OrderConfirmationResponseBody ret = serializer.Deserialize<OrderConfirmationResponseBody>(json);
            Assert.Equal(2, ret.DownloadedOrderList.Count);

        }


    }

    public class OrderFakeTest : TestBase
    {
        private readonly OrderCall fakeapi, fakeapi_b2b, fakeapi_can;
        private readonly OrderCall fakeapi_json, fakeapi_json_b2b, fakeapi_json_can;

        public OrderFakeTest()
        {
            fakeapi = new OrderCall(fakeUSAClientXML);
            fakeapi_json = new OrderCall(fakeUSAClientJSON);
            fakeapi_b2b = new OrderCall(fakeB2BClientXML);
            fakeapi_json_b2b = new OrderCall(fakeB2BClientJSON);
            fakeapi_can = new OrderCall(fakeCANClientXML);
            fakeapi_json_can = new OrderCall(fakeCANClientJSON);
        }

        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public async Task GetOrderStatus()
        {
            var orderstatus = await fakeapi.GetOrderStatus("105137040", 304);
            Assert.IsType<GetOrderStatusResponse>(orderstatus);
            Assert.Equal("105137040", orderstatus.OrderNumber);
            Assert.True(orderstatus.OrderDownloaded);
            Assert.Equal(OrderFulfillmentOption.ShipBySeller, orderstatus.FulfillmentOption);
            Assert.Equal(OrderSalesChannel.NeweggOrder, orderstatus.SalesChannel);
        }

        [Fact]
        public async Task GetOrderStatus_Json()
        {
            var orderstatus = await fakeapi_json.GetOrderStatus("105137040", 304);
            Assert.IsType<GetOrderStatusResponse>(orderstatus);
            Assert.Equal("105137040", orderstatus.OrderNumber);
            Assert.True(orderstatus.OrderDownloaded);
            Assert.Equal(OrderFulfillmentOption.ShipBySeller, orderstatus.FulfillmentOption);
            Assert.Equal(OrderSalesChannel.NeweggOrder, orderstatus.SalesChannel);
        }

        [Fact]
        public async Task CancelOrder()
        {
            var cancelorderinfo = new CancelOrderRequest(CancelOrderReason.PriceError);
            CheckRequestString<CancelOrderRequest>(cancelorderinfo);
            var result = await fakeapi.CancelOrder("127237320", null, cancelorderinfo);
            Assert.IsType<CancelOrderResponse>(result);
            Assert.Equal("127237320", result.Result.OrderNumber);
            Assert.Equal("Void", result.Result.OrderStatus);
        }

        [Fact]
        public async Task CancelOrder_Json()
        {
            var cancelorderinfo = new CancelOrderRequest(CancelOrderReason.PriceError);
            CheckRequestString<CancelOrderRequest>(cancelorderinfo);
            var result = await fakeapi_json.CancelOrder("127237320", null, cancelorderinfo);
            Assert.IsType<CancelOrderResponse>(result);
            Assert.Equal("127237320", result.Result.OrderNumber);
            Assert.Equal("Void", result.Result.OrderStatus);
        }

        [Fact]
        public async Task ShipOrder()
        {
            ShipmentInfo shipmentInfo = new ShipmentInfo()
            {
                Header = new ShipmentInfo.ShipmentHeader()
                {
                    SONumber = "159243598",
                    SellerID = "A006"
                },
                PackageList = new PackageInfo[]
                {
                    new PackageInfo()
                    {
                        ShipCarrier="Purolator",
                        ShipService="3-5",
                        TrackingNumber="lztestA0060001",
                        ItemList=new ItemInfo[]
                        {
                            new ItemInfo()
                            {
                                SellerPartNumber="A006ZX-35833",
                                ShippedQty=10
                            }
                        }
                    }
                }
            };
            var shiporderinfo = new ShipOrderRequest(shipmentInfo, USA_Config_XML.APIFormat);
            CheckRequestString<ShipOrderRequest>(shiporderinfo);
            var result = await fakeapi.ShipOrder("159243598", null, shiporderinfo);
            Assert.IsType<ShipOrderResponse>(result);
            Assert.Equal("159243598", result.Result.OrderNumber);
            Assert.Equal("lztestA0060001", result.Result.Shipment.PackageList[0].TrackingNumber);
            Assert.True(result.Result.Shipment.PackageList[0].ProcessStatus);
        }

        [Fact]
        public async Task ShipOrder_Json()
        {
            ShipmentInfo shipmentInfo = new ShipmentInfo()
            {
                Header = new ShipmentInfo.ShipmentHeader()
                {
                    SONumber = "159243598",
                    SellerID = "A006"
                },
                PackageList = new PackageInfo[]
                {
                    new PackageInfo()
                    {
                        ShipCarrier="Purolator",
                        ShipService="3-5",
                        TrackingNumber="lztestA0060001",
                        ItemList=new ItemInfo[]
                        {
                            new ItemInfo()
                            {
                                SellerPartNumber="A006ZX-35833",
                                ShippedQty=10
                            }
                        }
                    }
                }
            };
            var shiporderinfo = new ShipOrderRequest(shipmentInfo, SDK.Base.APIFormat.JSON);
            CheckRequestString<ShipOrderRequest>(shiporderinfo);
            var result = await fakeapi_json.ShipOrder("159243598", null, shiporderinfo);
            Assert.IsType<ShipOrderResponse>(result);
            Assert.Equal("159243598", result.Result.OrderNumber);
            Assert.Equal("lztestA0060001", result.Result.Shipment.PackageList[0].TrackingNumber);
            Assert.True(result.Result.Shipment.PackageList[0].ProcessStatus);
        }

        [Fact]
        public async Task OrderConfirmation()
        {
            var orderconfirminfo = new OrderConfirmationRequest(new string[] { "283756617" });
            CheckRequestString<OrderConfirmationRequest>(orderconfirminfo);
            var result = await fakeapi.OrderConfirmation(orderconfirminfo);
            Assert.IsType<OrderConfirmationResponse>(result);
            Assert.Equal("283756617", result.ResponseBody.DownloadedOrderList[0]);
        }

        [Fact]
        public async Task OrderConfirmation_JSON()
        {
            var orderconfirminfo = new OrderConfirmationRequest(new string[] { "283756617" });
            CheckRequestString<OrderConfirmationRequest>(orderconfirminfo);
            var result = await fakeapi_json.OrderConfirmation(orderconfirminfo);
            Assert.IsType<OrderConfirmationResponse>(result);
            Assert.Equal("283756617", result.ResponseBody.DownloadedOrderList[0]);
        }

        [Fact]
        public async Task RemoveItem()
        {
            var removeinfo = new RemoveItemRequest(new string[] { "AWHZ3434" });
            CheckRequestString<RemoveItemRequest>(removeinfo);
            var result = await fakeapi.RemoveItem("88237462", removeinfo);
            Assert.IsType<RemoveItemResponse>(result);
            Assert.Equal("88237462", result.ResponseBody.Orders.OrderNumber);
            Assert.True(result.ResponseBody.Orders.Result.ItemList.Count == 1);
            Assert.Equal("AWHZ3434", result.ResponseBody.Orders.Result.ItemList[0].SellerPartNumber);
        }

        [Fact]
        public async Task RemoveItem_JSON()
        {
            var removeinfo = new RemoveItemRequest(new string[] { "AWHZ3434" });
            var result = await fakeapi_json.RemoveItem("88237462", removeinfo);
            Assert.IsType<RemoveItemResponse>(result);
            Assert.Equal("88237462", result.ResponseBody.Orders.OrderNumber);
            Assert.True(result.ResponseBody.Orders.Result.ItemList.Count == 1);
            Assert.Equal("AWHZ3434", result.ResponseBody.Orders.Result.ItemList[0].SellerPartNumber);
        }

        [Fact]
        public async Task GetOrderInformation()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "41473642", "159243598" },
                Type = OrderInfoType.All,
                OrderDateFrom = "2018-01-01 09:30:47",
                OrderDateTo = "2018-12-17 09:30:47",
                OrderDownloaded = 0
            });

            var result = await fakeapi.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            Assert.True(result.ResponseBody.OrderInfoList.Count == 2);
        }

        [Fact]
        public async Task GetOrderInformation_Json()
        {
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "41473642", "159243598" },
                Type = OrderInfoType.All,
                OrderDateFrom = "2018-01-01 09:30:47",
                OrderDateTo = "2018-12-17 09:30:47",
                OrderDownloaded = 0
            });

            var result = await fakeapi_json.GetOrderInformation(null, orderreq);
            Assert.IsType<GetOrderInformationResponse>(result);
            Assert.True(result.ResponseBody.OrderInfoList.Count == 2);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult()
        {
            var result = await fakeapi.GetSBNOrderCancellationRequestResult("159243598");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            Assert.Equal("159243598", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetSBNOrderCancellationRequestResult_Json()
        {
            var result = await fakeapi_json.GetSBNOrderCancellationRequestResult("159243598");
            Assert.IsType<GetSBNOrderCancellationRequestResultResponse>(result);
            Assert.Equal("159243598", result.ResponseBody.OrderNumber);
        }

        [Fact]
        public async Task GetAdditionalOrderInformation()
        {
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "41473642" },
                OrderDateFrom = "2017-01-01 09:30:47",
                OrderDateTo = "2019-12-17 09:30:47",
                CountryCode = "USA"
            });

            var result = await fakeapi.GetAdditionalOrderInformation(addorderreq);
            Assert.IsType<GetAdditionalOrderInformationResponse>(result);
            Assert.Equal("41473642", result.ResponseBody.AddOrderInfoList[0].OrderNumber);
        }

        [Fact]
        public async Task GetAdditionalOrderInformation_Json()
        {
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderNumberList = new string[] { "41473642" },
                OrderDateFrom = "2017-01-01 09:30:47",
                OrderDateTo = "2019-12-17 09:30:47",
                CountryCode = "USA"
            });

            var result = await fakeapi_json.GetAdditionalOrderInformation(addorderreq);
            Assert.IsType<GetAdditionalOrderInformationResponse>(result);
            Assert.Equal("41473642", result.ResponseBody.AddOrderInfoList[0].OrderNumber);
        }
    }
}

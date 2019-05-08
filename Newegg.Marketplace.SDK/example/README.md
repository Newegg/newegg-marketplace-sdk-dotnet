# NewEgg Marketplace SDK for .Net Demo Code

```csharp
public class Demo
    {
        private OrderCall ordercall;
        private ItemCall itemCall;
        private SellerCall sellerCall;
        private DatafeedCall datafeedCall;
        private RMACall rmaCall;
        private ShippingCall shippingCall;
        private ReportCall reportCall;
        private OtherCall otherCall;

        public Demo()
        {
            //Construct an APIConfig with SellerID,  APIKey(Authorization) and SecretKey.
            APIConfig config = new APIConfig("****", "********************************", "********-****-****-****-************");
            // or load the config file to get it.
            //APIConfig config = APIConfig.FromJsonFile("setting.json");

            //Create a APIClient with the config
            APIClient client = new APIClient(config);

            //Create the Api Call object with he client.
            ordercall = new OrderCall(client);
            itemCall = new ItemCall(client);
            sellerCall = new SellerCall(client);
            datafeedCall = new DatafeedCall(client);
            rmaCall = new RMACall(client);
            shippingCall = new ShippingCall(client);
            reportCall = new ReportCall(client);
            otherCall = new OtherCall(client);
        }

        #region Order API Demo

        public void GetOrderInfo()
        {
            Console.WriteLine("GetOrderInfo");

            // Create Request
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                Status = Newegg.Marketplace.SDK.Order.Model.OrderStatus.Voided,
                Type = OrderInfoType.All,
                OrderDateFrom = "2016-01-01 09:30:47",
                OrderDateTo = "2017-12-17 09:30:47",
                OrderDownloaded = 0
            });

            // Send your request and get response
            var response = ordercall.GetOrderInformation(null, orderreq).Result;

            // Get data from the response
            GetOrderInformationResponseBody info = response.GetResponseBody();

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} order(s) in the result.", info.OrderInfoList.Count.ToString()));

        }

        public void GetOrderStatus()
        {
            Console.WriteLine("GetOrderStatus");

            // Send your request and get response
            var orderstatus = ordercall.GetOrderStatus("105137040").Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There order status is {0}.", orderstatus.OrderStatusName));
        }

        public void GetAddOrderInfo()
        {
            Console.WriteLine("GetAddOrderInfo");

            // Create Request
            var addorderreq = new GetAdditionalOrderInformationRequest(new GetAdditionalOrderInformationRequestCriteria()
            {
                OrderDateFrom = "2019-01-11 00:30:47",
                OrderDateTo = "2019-1-31 09:30:47",
                CountryCode = "USA"
            });

            // Send your request and get response
            var result = ordercall.GetAdditionalOrderInformation(addorderreq).Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} orders infomation responsed.", result.GetResponseBody().AddOrderInfoList.Count));
        }

        #endregion

        #region Item API Demo
        public void GetInternationalPrice()
        {
            Console.WriteLine("GetInternationalPrice");

            // Create Request
            GetInternationalItemPriceRequest PriceRequest = new GetInternationalItemPriceRequest()
            {
                Condition = ItemCondition.Refurbished,
                Type = ItemQueryType.NewEggItemNumber,
                Value = "9SIA0068KA0333"
            };

            // Send your request and get response
            var body = itemCall.GetInternationalItemPrice(PriceRequest).Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} item infomation responsed.", body.PriceList.Count));

        }

        public void UpdateItemlPrice()
        {
            Console.WriteLine("UpdateItemlPrice");

            // Create Request
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
                       EnableFreeShipping=FreeShipping.Default

                     }

                 }

            };



            // Send your request and get response
            var body = itemCall.UpdateItemPrice(UpdateItemPricerequest).Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} item infomation responsed.", body.PriceList.Count));

        }

        #endregion

        #region Seller API Demo
        public void GetSellerStatusCheck()
        {
            Console.WriteLine("GetSellerStatusCheck");
            // Send your request and get response
            var response = sellerCall.SellerStatusCheck().Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("Current Seller Status is {0}.", response.GetResponseBody().Status));
        }

        public void GetSubcategoryProperties()
        {
            Console.WriteLine("GetSubcategoryProperties");
            // Create Request
            var req = new GetSubcategoryPropertiesRequest(1045);
            // Send your request and get response
            var response = sellerCall.GetSubcategoryProperties(req).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} property in the subcategory.",
                response.GetResponseBody().SubcategoryPropertyList.Count));
        }

        public void GetSubcategoryStatus()
        {
            Console.WriteLine("GetSubcategoryStatus");
            // Create Request
            var req = new GetSubcategoryStatusRequest(new List<string>() { "CH" });
            // Send your request and get response
            var response = sellerCall.GetSubcategoryStatus(req).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} subcategory in the industry.",
                response.GetResponseBody().SubcategoryList.Count));
        }

        #endregion

        #region Datafeed API Demo
        public void SubmitFeed()
        {
            Console.WriteLine("SubmitFeed");
            // Create Request
            ItemSubscriptionFeedRequest req = new ItemSubscriptionFeedRequest()
            {
                Message = new ItemSubscriptionFeedRequestBody()
                {
                    Item = new ItemSubscriptionFeedRequestBody.ItemSubscriptionFeedItem[]
                   {
                        new ItemSubscriptionFeedRequestBody.ItemSubscriptionFeedItem()
                        {
                            SellerPartNumber="test1321313",
                            Action=FeedItemSubscriptionAction.Add
                        },
                        new ItemSubscriptionFeedRequestBody.ItemSubscriptionFeedItem()
                        {
                            SellerPartNumber="tezsdzsdasd",
                            Action=FeedItemSubscriptionAction.Remove
                        }
                   }
                }
            };
            // Send your request and get response
            var feedstatus = datafeedCall.SubmitFeed_ItemSubscriptionFeed(req).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} Response messages.",
                feedstatus.GetResponseBody().ResponseList.Count));
        }

        public void GetFeedStatus()
        {
            Console.WriteLine("GetFeedStatus");
            // Create Request
            GetFeedStatusRequest req = new GetFeedStatusRequest(new string[] { "215Y2P8KRIADO", "28M78BB6CZ715" });
            // Send your request and get response            
            var feedstatus = datafeedCall.GetFeedStatus(req).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} Response messages.",
                feedstatus.GetResponseBody().ResponseList.Count));
        }

        public void GetFeedResult()
        {
            Console.WriteLine("GetFeedResult");
            // Send your request and get response
            var feedstatus = datafeedCall.GetFeedResult("26PULUGW4IR4V").Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There message is {0}.",
                feedstatus.Message));
        }
        #endregion

        #region RMA API Demo

        public void GetRMAInfo()
        {
            Console.WriteLine("GetRMAInfo");
            // Create Request
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
            // Send your request and get response
            var result = rmaCall.GetRMAInformation(rmainfo).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} RMA Infos.",
                result.GetResponseBody().RMAInfoList.Count));
        }

        public void GetCourtesyRefundRequestStatus()
        {
            Console.WriteLine("GetCourtesyRefundRequestStatus");

            // Create Request
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
            // Send your request and get response
            var result = rmaCall.GetCourtesyRefundRequestStatus(rmainfo).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("The request type is {0}.",
                result.GetResponseBody().ResponseList.ResponseInfo.RequestType));
        }

        public void GetCourtesyRefundInformation()
        {
            Console.WriteLine("GetCourtesyRefundInformation");

            // Create Request
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

            // Send your request and get response
            var result = rmaCall.GetCourtesyRefundInformation(rmainfo).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} Courtesy Refund info.",
                result.GetResponseBody().CourtesyRefundInfoList.Count));

        }

        #endregion

        #region Shipping API Demo

        public void SubmitShippingRequest()
        {
            Console.WriteLine("SubmitShippingRequest");

            // Create Request
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

            // Send your request and get response
            var result = shippingCall.SubmitShippingRequest(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("The request status is {0}.",
                result.GetResponseBody().RequestStatus));
        }

        public void GetShippingRequestDetail()
        {
            Console.WriteLine("GetShippingRequestDetail");

            // Create Request
            var request = new GetShippingDetailRequest()
            {
                RequestBody = new GetShippingDetailRequestBody()
                {
                    RequestID = "245BWZ383S93Y"
                }

            };

            // Send your request and get response
            var result = shippingCall.GetShippingRequestDetail(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} results.",
                result.GetResponseBody().RequestList.Count));
        }

        public void VoidShippingRequest()
        {
            Console.WriteLine("VoidShippingRequest");

            // Create Request
            var request = new VoidShippingRequest()
            {
                RequestBody = new VoidShippingRequestBody()
                {
                    RequestIDList = new List<string>
                    { "245BWZ383S93Y" }
                }

            };

            // Send your request and get response
            var result = shippingCall.VoidShippingRequest(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("The operation result is {0}.",
                result.GetResponseBody().RequestStatus));
        }

        public void ConfirmShippingRequest()
        {
            Console.WriteLine("ConfirmShippingRequest");

            // Create Request
            var request = new confirmShipRequest()
            {
                RequestBody = new confirmShipRequestBody()
                {
                    RequestIDList = new List<string>
                    { "27BBNUFEFG8HI"}
                }
            };

            // Send your request and get response
            var result = shippingCall.ConfirmShippingRequest(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("The operation result is {0}.",
                result.GetResponseBody().RequestStatus));
        }

        #endregion

        #region Report API Demo
        public void SubmitDailyInventoryReport()
        {
            Console.WriteLine("SubmitDailyInventoryReport");
            // Create Request
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

            // Send your request and get response
            var result = reportCall.SubmitDailyInventoryReport(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} response info.",
                result.GetResponseBody().ResponseList.Count));
        }

        public void SubmitDailyPriceReport()
        {
            Console.WriteLine("SubmitDailyPriceReport");

            // Create Request
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

            // Send your request and get response
            var result = reportCall.SubmitDailyPriceReport(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} response info.",
                result.GetResponseBody().ResponseList.Count));
        }

        public void GetReportStatus()
        {
            Console.WriteLine("GetReportStatus");

            // Create Request
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

            // Send your request and get response
            var result = reportCall.GetReportStatus(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are {0} response info.",
                result.GetResponseBody().ResponseList.Count));
        }

        public void GetDailyInventoryReport()
        {
            Console.WriteLine("GetDailyInventoryReport");

            // Create Request
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

            // Send your request and get response
            var result = reportCall.GetDailyInventoryReport(request).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("The request id is {0}.",
                result.GetResponseBody().RequestID));
        }
        #endregion

        #region Other API Demo

        public void VerifyServiceStatus()
        {
            Console.WriteLine("VerifyServiceStatus");            

            // Send your request and get response
            var result = otherCall.VerifyServiceStatus(ServiceDomain.Order).Result;
            // Use the data pre you business
            Console.WriteLine(string.Format("There are order service status is {0}.",
                result.GetResponseBody().Status));
        }

        #endregion
    }
```
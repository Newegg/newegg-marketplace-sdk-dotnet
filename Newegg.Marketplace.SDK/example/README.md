# Newegg Marketplace SDK for .Net Demo Code

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

        /// <summary>
        /// Get Unshipped Order during a time period.
        /// </summary>
        public void GetOrderInfo()
        {
            Console.WriteLine("GetOrderInfo");

            // Create Request
            var orderreq = new GetOrderInformationRequest(new GetOrderInformationRequestCriteria()
            {
                Status = Newegg.Marketplace.SDK.Order.Model.OrderStatus.Unshipped,
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

        /// <summary>
        /// Get the status of special order
        /// </summary>
        public void GetOrderStatus()
        {
            Console.WriteLine("GetOrderStatus");

            // Send your request and get response
            var orderstatus = ordercall.GetOrderStatus("105137040").Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("There order status is {0}.", orderstatus.OrderStatusName));
        }

        /// <summary>
        /// Get addtional Information of order.
        /// </summary>
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

        /// <summary>
        /// Get Item price for multiple countries.
        /// </summary>
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

        /// <summary>
        /// Update item price
        /// </summary>
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
        /// <summary>
        /// Check Seller Status
        /// </summary>
        public void GetSellerStatusCheck()
        {
            Console.WriteLine("GetSellerStatusCheck");
            // Send your request and get response
            var response = sellerCall.SellerStatusCheck().Result;

            // Use the data pre you business
            Console.WriteLine(string.Format("Current Seller Status is {0}.", response.GetResponseBody().Status));
        }

        /// <summary>
        /// Get the properties of special subcategory.
        /// </summary>
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

        /// <summary>
        /// Get Subcategory of special Industry.
        /// </summary>
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

        /// <summary>
        /// Submit data feed.
        /// </summary>
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

        /// <summary>
        /// Get the status of the submitted datafeed.
        /// </summary>
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

        /// <summary>
        /// Get the result of the submitted datafeed.
        /// </summary>
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

        /// <summary>
        /// Get RMA infomation by keyword
        /// </summary>
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

        /// <summary>
        /// Get Status of special Courtesy Refund Request by request id
        /// </summary>
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

        /// <summary>
        /// Get information of Courtesy Refund
        /// </summary>
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

        /// <summary>
        /// Submit the shipping request for your Newegg order to receive the estimation of shipping cost using Newegg Shipping Label Service.
        /// </summary>
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

        /// <summary>
        /// Retrieving the processing result of Submit Shipping Request.
        /// </summary>
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

        /// <summary>
        /// An unconfirmed shipping request is applicable for void using this function.
        /// </summary>
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

        /// <summary>
        /// Once shipping estimate is available, you must confirm it when you are ready to ship.
        /// Note: Once a shipping request is confirmed, Newegg will continue to process the order and the status 
        /// of order will soon become "Shipped".  Also, the shipping information will be displayed in Order Detail 
        /// under the customer's My Account section, and Newegg will send the customer an email notification with 
        /// all of the shipping information.  When shipping request is confirmed, the revoke of the operation is not available.
        /// </summary>
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

        /// <summary>
        /// Get item's available inventory quantity, price information, shipping, and activation status for defaulted warehouse.
        /// </summary>
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

        /// <summary>
        /// Get item's price information, shipping, and activation status for targeted countries, including United States.
        /// </summary>
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

        /// <summary>
        /// Get the status of specified report request.
        /// </summary>
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

        /// <summary>
        /// Get report when Get Report Status result is FINISHED.
        /// </summary>
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

        /// <summary>
        /// Check the status of Newegg Marketplace API
        /// </summary>
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

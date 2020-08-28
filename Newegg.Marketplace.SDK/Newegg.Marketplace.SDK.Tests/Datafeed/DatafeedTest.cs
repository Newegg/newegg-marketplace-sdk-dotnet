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

using Xunit;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.DataFeed;
using Newegg.Marketplace.SDK.DataFeed.Model;

namespace Newegg.Marketplace.SDK.Tests.Datafeed
{
    public class DatafeedTest : TestBase
    {
        private readonly DatafeedCall api, api_json, api_can;
        private readonly DatafeedCall fakeApi, fakeApi_json;


        public DatafeedTest()
        {
            api = new DatafeedCall(USAClientXML);
            fakeApi = new DatafeedCall(fakeUSAClientXML);
            api_json = new DatafeedCall(USAClientJSON);
            fakeApi_json = new DatafeedCall(fakeUSAClientJSON);
            api_can = new DatafeedCall(CANClientXML);
        }

        private void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public void TestRequestSerialize_InventoryUpdateFeed()
        {
            InventoryUpdateFeedRequest feed = new InventoryUpdateFeedRequest();
            feed.Message = new InventoryUpdateFeedRequestBody();
            feed.Message.Inventory = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedBasicInfo()
            {
                Item = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem[]
                {
                    new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                    {
                        SellerPartNumber = "test123",
                        Inventory = 123,
                        WarehouseLocation = "USA"
                    }
                }
            };
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<InventoryUpdateFeedRequest>(feed);
            string jsons = jsonSerializer.Serialize<InventoryUpdateFeedRequest>(feed);
        }

        [Fact]
        public void TestRequestSerialize_ItemVolumeDiscountInfo()
        {
            SDK.Item.Model.ItemVolumeDiscountInfo volumeDiscountInfo = new SDK.Item.Model.ItemVolumeDiscountInfo()
            {
                NeweggItemNumber = "9SIA0062TT3677",
                VolumeActivation = SDK.Item.Model.ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                DiscountSetting = new System.Collections.Generic.List<SDK.Item.Model.TierInfo>()
                {
                    new SDK.Item.Model.TierInfo()
                    {
                        Priority = 1,
                        SellingPrice = 0.98M,
                        Quantity = 10,
                        EnableFreeShipping = 0
                    },new SDK.Item.Model.TierInfo()
                    {
                        Priority = 2,
                        SellingPrice = 0.90M,
                        Quantity = 100,
                        EnableFreeShipping = 0
                    }
                }
            };
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<SDK.Item.Model.ItemVolumeDiscountInfo>(volumeDiscountInfo);
            string jsons = jsonSerializer.Serialize<SDK.Item.Model.ItemVolumeDiscountInfo>(volumeDiscountInfo);
        }


        [Fact]
        public void TestRequestSerialize_XmlSerializableHashtable()
        {
            AAA x = new AAA()
            {
                Other = "888888888",
                TestSubcategory = new XmlSerializableHashtable()
            };
            XmlSerializableHashtable y = new XmlSerializableHashtable();
            y.Add("A", "test");
            y.Add("B", 11541465351);
            x.TestSubcategory.Add("Properties", y);
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string jsons = jsonSerializer.Serialize(x);
            string xmls = xmlSerializer.Serialize(x);

        }
        public class AAA
        {
            public AAA() { }
            public string Other { get; set; }
            public XmlSerializableHashtable TestSubcategory
            {
                get; set;
            }
        }

        [Fact]
        public void TestRequestSerialize_MultiChannelOrderFeedRequest()
        {
            MultiChannelOrderFeedRequest req = new MultiChannelOrderFeedRequest()
            {
                Message = new MultiChannelOrderFeedRequestBody()
                {
                    MultiChannelOrder = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedBasicInfo()
                    {
                        Order = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo[]
                        {
                            new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo()
                            {
                                OrderDate = "2000/02/02",
                                SalesChannel = "3rd channel",
                                SellerOrderID = "131163115",
                                ShippingMethod = FeedShippingMethod.Expedited_Shipping_3to5_business_days,
                                ShipToFirstName = "BIG",
                                ShipToLastName = "MAMA",
                                ShipToAddressLine1 = "Deep Blue",
                                ShipToCity = "abc",
                                ShipToState = "vvvvv",
                                ShipToPostalCode = "61542",
                                ShipToCountry = "USA",
                                ShipToPhoneNumber = "000000000",
                                ItemList = new System.Collections.Generic.List<MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo>()
                                {
                                    new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo()
                                    {
                                        SellerPartNumber="test1111",
                                        Quantity=10
                                    }
                                }
                            }
                        }
                    }
                }
            };
            XmlSerializer xmlSerializer = new XmlSerializer();
            //JsonSerializer jsonSerializer = new JsonSerializer(true);
            //string jsons = jsonSerializer.Serialize(req);
            string xmls = xmlSerializer.Serialize(req);

        }


        [Fact]
        public async Task GetFeedStatus()
        {
            GetFeedStatusRequest req = new GetFeedStatusRequest(new string[] { "215Y2P8KRIADO", "28M78BB6CZ715" });
            CheckRequestString<GetFeedStatusRequest>(req);
            var feedstatus = await fakeApi.GetFeedStatus(req);
            var feedstatus2 = await fakeApi_json.GetFeedStatus(req);
            Assert.IsType<GetFeedStatusResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count > 0);
            Assert.IsType<GetFeedStatusResponse>(feedstatus2);
            Assert.True(feedstatus2.IsSuccess);
            Assert.True(feedstatus2.ResponseBody.ResponseList.Count > 0);
        }

        [Fact]
        public async Task SubmitFeed_ItemCreationOrUpdateFeed()
        {
            XmlSerializableHashtable Propertys = new XmlSerializableHashtable();
            Propertys.Add("BeltsColor", "Coyote Tan");
            Propertys.Add("BeltsGender", "Male");
            Propertys.Add("BeltsSize", "56");
            Propertys.Add("BeltsType", "Belts");
            XmlSerializableHashtable subCategoryProperty = new XmlSerializableHashtable();
            subCategoryProperty.Add("Propertys", Propertys);
            ItemCreationOrUpdateFeedRequest req = new ItemCreationOrUpdateFeedRequest()
            {
                Message = new ItemCreationOrUpdateFeedBody()
                {
                    Itemfeed = new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedInfo()
                    {
                        SummaryInfo = new ItemfeedSummaryInfo(1508)
                    }
                }
            };
            req.Message.Itemfeed.Item = new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedItemInfo[]
            {
                new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedItemInfo()
                {
                    BasicInfo = new ItemfeedItemBasicInfo()
                    {
                        SellerPartNumber = "Test_SP190306081022700",
                        Manufacturer = "test2013",
                        ManufacturerPartsNumber = "Test190306081022700",
                        WebsiteShortTitle = "Test_WST190306081022700",
                        BulletDescription = "Test_BulletDescript01^^Test_BulletDescript02^^Test_BulletDescript03",
                        ProductDescription = "Test_PD190306081022700",
                        ItemDimension = new ItemfeedItemBasicInfo.ItemfeedItemDimension()
                        {
                            ItemLength = 1,
                            ItemHeight = 2,
                            ItemWidth = 3
                        },
                        ItemWeight = 10,
                        PacksOrSets = 1,
                        ItemCondition = FeedItemCondition.New,
                        ItemPackage = FeedItemPackage.OEM,
                        ShippingRestriction = FeedShippingRestriction.Yes,
                        Currency = "USD",
                        MSRP = 500,
                        SellingPrice = 100,
                        MAP = 80,
                        CheckoutMAP = FeedCheckoutMAP.True,
                        Shipping = FeedShipping.Default,
                        Inventory = 100,
                        LimitQuantity=1,
                        ActivationMark = FeedActivationMark.True,
                        ItemImages = new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://images17.newegg.com/is/image/newegg/17-182-073-TS?$S640W$",
                                            IsPrimary=true
                                        }
                                    },
                        Warning = new ItemfeedItemBasicInfo.ItemfeedItemWarning()
                        {
                            CountryOfOrigin = "USA",
                            OverAge18Verification = FeedItemWarningOverAge18.Yes,
                            ChokingHazard = new ItemfeedItemBasicInfo.ItemfeedItemChokingHazard()
                            {
                                SmallParts = FeedChokingHazardSmallParts.Yes,
                                SmallBall = FeedChokingHazardSmallBall.Is_a_small_ball,
                                Balloons = FeedChokingHazardBalloons.Yes
                            }
                        }
                    },
                    SubCategoryProperty = subCategoryProperty
                }
            };
            CheckRequestString<ItemCreationOrUpdateFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemCreationOrUpdateFeed(req);
            Assert.IsType<ItemCreationOrUpdateFeedResponse>(feedstatus);
        }

        [Fact]
        public async Task SubmitFeed_ExistingItemCreationFeed()
        {
            ExistingItemCreationFeedRequest req = new ExistingItemCreationFeedRequest()
            {
                Message = new ExistingItemCreationFeedRequestBody()
                {
                    Itemfeed = new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedInfo()
                    {
                        Item = new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedItemInfo[]
                        {
                            new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedItemInfo()
                            {
                                BasicInfo=new ItemfeedItemBasicInfo()
                                {
                                    SellerPartNumber="JACKETEST0921001002",
                                    Manufacturer="AMD",
                                    ManufacturerPartsNumber="JACKETEST0921001002",
                                    NeweggItemNumber="9SIAWE50389435",
                                    Currency="USD",
                                    MSRP=500,
                                    CheckoutMAP=FeedCheckoutMAP.True,
                                    MAP=20,
                                    SellingPrice=100,
                                    Shipping=FeedShipping.Free,
                                    Inventory=100,
                                    ActivationMark=FeedActivationMark.False,
                                    ItemCondition=FeedItemCondition.UsedGood,
                                    PacksOrSets=2,
                                    UsedItemImages=new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://10.1.24.143:4567/images/20.gif",
                                            IsPrimary=true
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var feedstatus = await fakeApi.SubmitFeed_ExistingItemCreationFeed(req);
            Assert.IsType<ExistingItemCreationFeedResponse>(feedstatus);
        }

        [Fact]
        public async Task SubmitFeed_ItemBasicInformationFeed()
        {
            ItemBasicInformationFeedRequest req = new ItemBasicInformationFeedRequest()
            {
                Message = new ItemBasicInformationFeedRequestBody()
                {
                    Itemfeed = new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedInfo()
                    {
                        Item = new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedItemInfo[]
                        {
                            new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedItemInfo()
                            {
                                BasicInfo=new ItemfeedItemBasicInfo()
                                {
                                    SellerPartNumber="JACKETEST0921001002",
                                    WebsiteShortTitle="Sick1111111",
                                    ProductDescription="hello12131466",
                                    ItemWeight=10,
                                    ActivationMark=FeedActivationMark.True,
                                    ItemImages=new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://10.1.24.143:4567/images/20.gif",
                                            IsPrimary=true
                                        }
                                    },
                                    Warning=new ItemfeedItemBasicInfo.ItemfeedItemWarning()
                                    {
                                        OverAge18Verification=FeedItemWarningOverAge18.Yes,
                                        ChokingHazard=new ItemfeedItemBasicInfo.ItemfeedItemChokingHazard()
                                        {
                                            SmallParts=FeedChokingHazardSmallParts.Yes,
                                            SmallBall=FeedChokingHazardSmallBall.Is_a_small_ball,
                                            Balloons=FeedChokingHazardBalloons.Yes
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString<ItemBasicInformationFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemBasicInformationFeed(req);
            Assert.IsType<ItemBasicInformationFeedResponse>(feedstatus);
        }

        [Fact]
        public async Task SubmitFeed_InventoryUpdateFeed_Json_Test()
        {
            InventoryUpdateFeedRequest req = new InventoryUpdateFeedRequest()
            {
                Message = new InventoryUpdateFeedRequestBody()
                {
                    Inventory = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedBasicInfo()
                    {
                        Item = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem[]
                        {
                            new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                WarehouseLocation = "USA",
                                Inventory = 50
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi_json.SubmitFeed_InventoryUpdateFeed(req);
            Assert.IsType<InventoryUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("INVENTORY_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }


        [Fact]
        public async Task SubmitFeed_InventoryUpdateFeed()
        {
            InventoryUpdateFeedRequest req = new InventoryUpdateFeedRequest()
            {
                Message = new InventoryUpdateFeedRequestBody()
                {
                    Inventory = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedBasicInfo()
                    {
                        Item = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem[]
                        {
                            new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                WarehouseLocation = "USA",
                                Inventory = 50
                            },
                            new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3896",
                                WarehouseLocation = "USA",
                                Inventory = 10
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_InventoryUpdateFeed(req);
            Assert.IsType<InventoryUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("INVENTORY_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_PriceUpdateFeed()
        {
            PriceUpdateFeedRequest req = new PriceUpdateFeedRequest()
            {
                Message = new PriceUpdateFeedRequestBody()
                {
                    Price = new PriceUpdateFeedRequestBody.PriceUpdateFeedBasicInfo()
                    {
                        Item = new PriceUpdateFeedRequestBody.PriceUpdateFeedItem[]
                        {
                            new PriceUpdateFeedRequestBody.PriceUpdateFeedItem()
                            {
                                    NeweggItemNumber = "9SIA00602T3895",
                                    CountryCode = "USA",
                                    Currency = "USD",
                                    SellingPrice = 50,
                                    Shipping = FeedShipping.Default,
                                    ActivationMark = FeedActivationMark.True,
                                    LimitQuantity=1
                            },
                            new PriceUpdateFeedRequestBody.PriceUpdateFeedItem()
                            {
                                    NeweggItemNumber = "9SIA00602T3896",
                                    CountryCode = "USA",
                                    Currency = "USD",
                                    SellingPrice = 60,
                                    Shipping = FeedShipping.Default,
                                    ActivationMark = FeedActivationMark.True
                            }
                        }
                    }
                }
            };
            CheckRequestString<PriceUpdateFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_PriceUpdateFeed(req);
            Assert.IsType<PriceUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("PRICE_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_InventoryAndPriceFeed()
        {
            InventoryAndPriceFeedRequest req = new InventoryAndPriceFeedRequest()
            {
                Message = new InventoryAndPriceFeedRequestBody()
                {
                    Inventory = new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedBasicInfo()
                    {
                        Item = new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedItem[]
                        {
                            new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                Currency = "USD",
                                SellingPrice = 50,
                                Shipping = FeedShipping.Default,
                                Inventory = 10
                            },
                            new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3885",
                                Currency = "USD",
                                SellingPrice = 50,
                                Shipping = FeedShipping.Default,
                                Inventory = 10,
                                LimitQuantity=1
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_InventoryAndPriceFeed(req);
            Assert.IsType<InventoryAndPriceFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("INVENTORY_AND_PRICE_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_OrderShipNoticeFeed()
        {
            OrderShipNoticeFeedRequest req = new OrderShipNoticeFeedRequest()
            {
                Message = new OrderShipNoticeFeedRequestBody()
                {
                    ShipNotice = new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedBasicInfo()
                    {
                        Package = new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo[]
                        {
                            new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo()
                            {
                                OrderNumber = 11213213,
                                ActualShippingCarrier = "UPS",
                                ActualShippingMethod = "UPS Ground",
                                TrackingNumber = "20110922002",
                                ItemInformation = new System.Collections.Generic.List<OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo>()
                                {
                                    new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo()
                                    {
                                        SellerPartNumber="data_MP_32900973",
                                        ShippedQuantity=1
                                    }
                                }
                            },
                            new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo()
                            {
                                OrderNumber = 112413213,
                                ActualShippingCarrier = "UPS",
                                ActualShippingMethod = "UPS Ground",
                                TrackingNumber = "20110922002",
                                ItemInformation = new System.Collections.Generic.List<OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo>()
                                {
                                    new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo()
                                    {
                                        SellerPartNumber="data_MP_3s2900973",
                                        ShippedQuantity=1
                                    }
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_OrderShipNoticeFeed(req);
            Assert.IsType<OrderShipNoticeFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ORDER_SHIP_NOTICE_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_MultiChannelOrderFeed()
        {
            MultiChannelOrderFeedRequest req = new MultiChannelOrderFeedRequest()
            {
                Message = new MultiChannelOrderFeedRequestBody()
                {
                    MultiChannelOrder = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedBasicInfo()
                    {
                        Order = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo[]
                        {
                            new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo()
                            {
                                OrderDate = "2000/02/02",
                                SalesChannel = "3rd channel",
                                SellerOrderID = "131163115",
                                ShippingMethod = FeedShippingMethod.Expedited_Shipping_3to5_business_days,
                                ShipToFirstName = "BIG",
                                ShipToLastName = "MAMA",
                                ShipToAddressLine1 = "Deep Blue",
                                ShipToCity = "abc",
                                ShipToState = "vvvvv",
                                ShipToPostalCode = "61542",
                                ShipToCountry = "USA",
                                ShipToPhoneNumber = "000000000",
                                ItemList = new System.Collections.Generic.List<MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo>()
                                {
                                    new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo()
                                    {
                                        SellerPartNumber="test1111",
                                        Quantity=10
                                    }
                                }
                            },
                            new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo()
                            {
                                OrderDate = "2010/02/02",
                                SalesChannel = "3rd channel",
                                SellerOrderID = "13116315",
                                ShippingMethod = FeedShippingMethod.Expedited_Shipping_3to5_business_days,
                                ShipToFirstName = "BIG",
                                ShipToLastName = "MAMA",
                                ShipToAddressLine1 = "Deep Blue",
                                ShipToCity = "abc",
                                ShipToState = "vvvvv",
                                ShipToPostalCode = "61542",
                                ShipToCountry = "USA",
                                ShipToPhoneNumber = "000000000",
                                ItemList = new System.Collections.Generic.List<MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo>()
                                {
                                    new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo()
                                    {
                                        SellerPartNumber="test1a111",
                                        Quantity=1
                                    }
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_MultiChannelOrderFeed(req);
            Assert.IsType<MultiChannelOrderFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("MULTICHANNEL_ORDER_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_ItemSubscriptionFeed()
        {
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
            CheckRequestString<ItemSubscriptionFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemSubscriptionFeed(req);
            Assert.IsType<ItemSubscriptionFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ITEM_SUBSCRIPTION", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_VolumeDiscountFeed()
        {
            VolumeDiscountFeedRequest req = new VolumeDiscountFeedRequest()
            {
                Message = new VolumeDiscountFeedRequestBody()
                {
                    VolumeDiscountList = new System.Collections.Generic.List<SDK.Item.Model.ItemVolumeDiscountInfo>()
                    {
                        new SDK.Item.Model.ItemVolumeDiscountInfo()
                        {
                            SellerPartNumber="tessdasda431313",
                            VolumeActivation=SDK.Item.Model.ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                            DiscountSetting=new System.Collections.Generic.List<SDK.Item.Model.TierInfo>()
                            {
                                new SDK.Item.Model.TierInfo()
                                {
                                    Priority = 1,
                                    SellingPrice = 0.98M,
                                    Quantity = 10,
                                    EnableFreeShipping = 0
                                },new SDK.Item.Model.TierInfo()
                                {
                                    Priority = 2,
                                    SellingPrice = 0.90M,
                                    Quantity = 100,
                                    EnableFreeShipping = 0
                                }
                            }
                        }
                    }
                }
            };
            XmlSerializer xmlSerializer = new XmlSerializer();
            string xmls = xmlSerializer.Serialize<VolumeDiscountFeedRequest>(req);
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string jsons = jsonSerializer.Serialize<VolumeDiscountFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_VolumeDiscountFeed(req);
            Assert.IsType<VolumeDiscountFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("VOLUME_DISCOUNT_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_ItemPromotionFeed()
        {
            ItemPromotionFeedRequest req = new ItemPromotionFeedRequest()
            {
                Message = new ItemPromotionFeedRequestBody()
                {
                    Item = new ItemPromotionFeedRequestBody.ItemPromotionFeedItem[]
                    {
                        new ItemPromotionFeedRequestBody.ItemPromotionFeedItem()
                        {
                            SellerPartNumber = "test11111",
                            PromoMSRP = 55,
                            PromoSellingPrice = 20.9m,
                            PromoShipping = FeedShipping.Default,
                            PromoStartDate = System.DateTime.Now,
                            PromoEndDate = System.DateTime.Parse("2019/07/07"),
                            InventoryLocked = FeedInventoryLocked.No
                        },
                        new ItemPromotionFeedRequestBody.ItemPromotionFeedItem()
                        {
                            SellerPartNumber = "test111aa11",
                            PromoMSRP = 55,
                            PromoSellingPrice = 20.9m,
                            PromoShipping = FeedShipping.Default,
                            PromoStartDate = System.DateTime.Now,
                            PromoEndDate = System.DateTime.Parse("2019/07/07"),
                            InventoryLocked = FeedInventoryLocked.No
                        }
                    }
                }
            };
            CheckRequestString<ItemPromotionFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemPromotionFeed(req);
            Assert.IsType<ItemPromotionFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ITEM_PROMOTION_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_ItemPremierMarkFeed()
        {
            ItemPremierMarkFeedRequest req = new ItemPremierMarkFeedRequest()
            {
                Message = new ItemPremierMarkFeedRequestBody()
                {
                    Item = new ItemPremierMarkFeedRequestBody.ItemPremierMarkFeedItem[]
                    {
                        new ItemPremierMarkFeedRequestBody.ItemPremierMarkFeedItem()
                        {
                            SellerPartNumber="test6265661",
                            PremierMark=FeedPremierMark.TRUE
                        }
                    }
                }
            };
            CheckRequestString<ItemPremierMarkFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemPremierMarkFeed(req);
            Assert.IsType<ItemPremierMarkFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ITEM_PREMIER_MARK_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_ItemCAProp65Feed()
        {
            ItemCAProp65FeedRequest req = new ItemCAProp65FeedRequest()
            {
                Message = new ItemCAProp65FeedRequestBody()
                {
                    Itemfeed = new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo[]
                    {
                        new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo()
                        {
                            Item=new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem[]
                            {
                                new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem()
                                {
                                    SellerPartNumber="test113131313",
                                    WarningType_ID=FeedWarningTypeID.CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants__LongForm,
                                    ChemicalName_Carcinogen="dasdasdnlasndlnzlda"
                                }
                            }

                        },
                        new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo()
                        {
                            Item=new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem[]
                            {
                                new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem()
                                {
                                    SellerPartNumber="test1131ss31313",
                                    WarningType_ID=FeedWarningTypeID.CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants__LongForm,
                                    ChemicalName_Carcinogen="dasdasadnlasndlnzlda"
                                }
                            }

                        }
                    }
                }
            };
            CheckRequestString<ItemCAProp65FeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemCAProp65Feed(req);
            Assert.IsType<ItemCAProp65FeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ITEM_CAPROP65_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task SubmitFeed_ItemChinaTaxSettingFeed()
        {
            ItemChinaTaxSettingFeedRequest req = new ItemChinaTaxSettingFeedRequest()
            {
                Message = new ItemChinaTaxSettingFeedRequestBody()
                {
                    ChinaTaxSetting = new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo[]
                    {
                        new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo()
                        {
                            Item=new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem[]
                            {
                                new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem()
                                {
                                    SellerPartNumber="test113131313",
                                    TaxDutyType=FeedTaxDutyType.DDP,
                                    ImportType=FeedImportType.EE
                                }
                            }
                        },
                        new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo()
                        {
                            Item=new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem[]
                            {
                                new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem()
                                {
                                    SellerPartNumber="test11313ss1313",
                                    TaxDutyType=FeedTaxDutyType.ATI,
                                    ImportType=FeedImportType.EE
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemChinaTaxSettingFeed(req);
            Assert.IsType<ItemChinaTaxSettingFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            //Assert.Equal("ITEM_CHINATAXSETTING_DATA", feedstatus.ResponseBody.ResponseList[0].RequestType);
        }

        [Fact]
        public async Task GetFeedResult()
        {
            //var feedstatus = await api.GetFeedResult("230YVZLG79V4T");
            var feedstatus2 = await fakeApi_json.GetFeedResult("26PULUGW4IR4V");
            //Assert.IsType<GetFeedResultResponse>(feedstatus);
            Assert.IsType<GetFeedResultResponse>(feedstatus2);
        }

        [Fact]
        public async Task GetFeedResult_CAN()
        {
            var feedstatus = await fakeApi_json.GetFeedResult("ZJLHB8P1G529");
            Assert.IsType<GetFeedResultResponse>(feedstatus);
        }
    }

    public class DatafeedFakeTest : TestBase
    {
        private readonly DatafeedCall fakeApi, fakeApi_json;


        public DatafeedFakeTest()
        {
            fakeApi = new DatafeedCall(fakeUSAClientXML);
            fakeApi_json = new DatafeedCall(fakeUSAClientJSON);
        }

        void CheckRequestString<T>(T req)
        {
            XmlSerializer xmlSerializer = new XmlSerializer();
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string xmls = xmlSerializer.Serialize<T>(req);
            string jsons = jsonSerializer.Serialize<T>(req);
        }

        [Fact]
        public async Task GetFeedStatus()
        {
            GetFeedStatusRequest req = new GetFeedStatusRequest(new string[] { "215Y2P8KRIADO", "28M78BB6CZ715" });
            CheckRequestString<GetFeedStatusRequest>(req);
            var feedstatus = await fakeApi.GetFeedStatus(req);
            Assert.IsType<GetFeedStatusResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count > 0);
        }

        [Fact]
        public async Task GetFeedStatus_Json()
        {
            GetFeedStatusRequest req = new GetFeedStatusRequest(new string[] { "215Y2P8KRIADO", "28M78BB6CZ715" });
            CheckRequestString<GetFeedStatusRequest>(req);
            var feedstatus2 = await fakeApi_json.GetFeedStatus(req);
            Assert.IsType<GetFeedStatusResponse>(feedstatus2);
            Assert.True(feedstatus2.IsSuccess);
            Assert.True(feedstatus2.ResponseBody.ResponseList.Count > 0);
        }

        [Fact]
        public async Task SubmitFeed_ItemCreationOrUpdateFeed()
        {
            XmlSerializableHashtable Propertys = new XmlSerializableHashtable();
            Propertys.Add("BeltsColor", "Coyote Tan");
            Propertys.Add("BeltsGender", "Male");
            Propertys.Add("BeltsSize", "56");
            Propertys.Add("BeltsType", "Belts");
            XmlSerializableHashtable subCategoryProperty = new XmlSerializableHashtable();
            subCategoryProperty.Add("Propertys", Propertys);
            ItemCreationOrUpdateFeedRequest req = new ItemCreationOrUpdateFeedRequest()
            {
                Message = new ItemCreationOrUpdateFeedBody()
                {
                    Itemfeed = new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedInfo()
                    {
                        SummaryInfo = new ItemfeedSummaryInfo(1508)
                    }
                }
            };
            req.Message.Itemfeed.Item = new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedItemInfo[]
            {
                new ItemCreationOrUpdateFeedBody.ItemCreationUpdateFeedItemInfo()
                {
                    BasicInfo = new ItemfeedItemBasicInfo()
                    {
                        SellerPartNumber = "Test_SP190306081022700",
                        Manufacturer = "test2013",
                        ManufacturerPartsNumber = "Test190306081022700",
                        WebsiteShortTitle = "Test_WST190306081022700",
                        BulletDescription = "Test_BulletDescript01^^Test_BulletDescript02^^Test_BulletDescript03",
                        ProductDescription = "Test_PD190306081022700",
                        ItemDimension = new ItemfeedItemBasicInfo.ItemfeedItemDimension()
                        {
                            ItemLength = 1,
                            ItemHeight = 2,
                            ItemWidth = 3
                        },
                        ItemWeight = 10,
                        PacksOrSets = 1,
                        ItemCondition = FeedItemCondition.New,
                        ItemPackage = FeedItemPackage.OEM,
                        ShippingRestriction = FeedShippingRestriction.Yes,
                        Currency = "USD",
                        MSRP = 500,
                        SellingPrice = 100,
                        MAP = 80,
                        CheckoutMAP = FeedCheckoutMAP.True,
                        Shipping = FeedShipping.Default,
                        Inventory = 100,
                        ActivationMark = FeedActivationMark.True,
                        ItemImages = new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://images17.newegg.com/is/image/newegg/17-182-073-TS?$S640W$",
                                            IsPrimary=true
                                        }
                                    },
                        Warning = new ItemfeedItemBasicInfo.ItemfeedItemWarning()
                        {
                            CountryOfOrigin = "USA",
                            OverAge18Verification = FeedItemWarningOverAge18.Yes,
                            ChokingHazard = new ItemfeedItemBasicInfo.ItemfeedItemChokingHazard()
                            {
                                SmallParts = FeedChokingHazardSmallParts.Yes,
                                SmallBall = FeedChokingHazardSmallBall.Is_a_small_ball,
                                Balloons = FeedChokingHazardBalloons.Yes
                            }
                        }
                    },
                    SubCategoryProperty = subCategoryProperty
                }
            };
            CheckRequestString<ItemCreationOrUpdateFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemCreationOrUpdateFeed(req);
            Assert.IsType<ItemCreationOrUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ExistingItemCreationFeed()
        {
            ExistingItemCreationFeedRequest req = new ExistingItemCreationFeedRequest()
            {
                Message = new ExistingItemCreationFeedRequestBody()
                {
                    Itemfeed = new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedInfo()
                    {
                        Item = new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedItemInfo[]
                        {
                            new ExistingItemCreationFeedRequestBody.ExistingItemCreationFeedItemInfo()
                            {
                                BasicInfo=new ItemfeedItemBasicInfo()
                                {
                                    SellerPartNumber="JACKETEST0921001002",
                                    Manufacturer="AMD",
                                    ManufacturerPartsNumber="JACKETEST0921001002",
                                    NeweggItemNumber="9SIAWE50389435",
                                    Currency="USD",
                                    MSRP=500,
                                    CheckoutMAP=FeedCheckoutMAP.True,
                                    MAP=20,
                                    SellingPrice=100,
                                    Shipping=FeedShipping.Free,
                                    Inventory=100,
                                    ActivationMark=FeedActivationMark.False,
                                    ItemCondition=FeedItemCondition.UsedGood,
                                    PacksOrSets=2,
                                    UsedItemImages=new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://10.1.24.143:4567/images/20.gif",
                                            IsPrimary=true
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var feedstatus = await fakeApi.SubmitFeed_ExistingItemCreationFeed(req);
            Assert.IsType<ExistingItemCreationFeedResponse>(feedstatus);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemBasicInformationFeed()
        {
            ItemBasicInformationFeedRequest req = new ItemBasicInformationFeedRequest()
            {
                Message = new ItemBasicInformationFeedRequestBody()
                {
                    Itemfeed = new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedInfo()
                    {
                        Item = new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedItemInfo[]
                        {
                            new ItemBasicInformationFeedRequestBody.ItemBasicInformationFeedItemInfo()
                            {
                                BasicInfo=new ItemfeedItemBasicInfo()
                                {
                                    SellerPartNumber="JACKETEST0921001002",
                                    WebsiteShortTitle="Sick1111111",
                                    ProductDescription="hello12131466",
                                    ItemWeight=10,
                                    ActivationMark=FeedActivationMark.True,
                                    ItemImages=new System.Collections.Generic.List<ItemfeedItemBasicInfo.ItemfeedItemImage>()
                                    {
                                        new ItemfeedItemBasicInfo.ItemfeedItemImage()
                                        {
                                            ImageUrl ="http://10.1.24.143:4567/images/20.gif",
                                            IsPrimary=true
                                        }
                                    },
                                    Warning=new ItemfeedItemBasicInfo.ItemfeedItemWarning()
                                    {
                                        OverAge18Verification=FeedItemWarningOverAge18.Yes,
                                        ChokingHazard=new ItemfeedItemBasicInfo.ItemfeedItemChokingHazard()
                                        {
                                            SmallParts=FeedChokingHazardSmallParts.Yes,
                                            SmallBall=FeedChokingHazardSmallBall.Is_a_small_ball,
                                            Balloons=FeedChokingHazardBalloons.Yes
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString<ItemBasicInformationFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemBasicInformationFeed(req);
            Assert.IsType<ItemBasicInformationFeedResponse>(feedstatus);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_InventoryUpdateFeed_Json_Test()
        {
            InventoryUpdateFeedRequest req = new InventoryUpdateFeedRequest()
            {
                Message = new InventoryUpdateFeedRequestBody()
                {
                    Inventory = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedBasicInfo()
                    {
                        Item = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem[]
                        {
                            new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                WarehouseLocation = "USA",
                                Inventory = 50
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi_json.SubmitFeed_InventoryUpdateFeed(req);
            Assert.IsType<InventoryUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }


        [Fact]
        public async Task SubmitFeed_InventoryUpdateFeed()
        {
            InventoryUpdateFeedRequest req = new InventoryUpdateFeedRequest()
            {
                Message = new InventoryUpdateFeedRequestBody()
                {
                    Inventory = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedBasicInfo()
                    {
                        Item = new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem[]
                        {
                            new InventoryUpdateFeedRequestBody.InventoryUpdateFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                WarehouseLocation = "USA",
                                Inventory = 50
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi.SubmitFeed_InventoryUpdateFeed(req);
            Assert.IsType<InventoryUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_PriceUpdateFeed()
        {
            PriceUpdateFeedRequest req = new PriceUpdateFeedRequest()
            {
                Message = new PriceUpdateFeedRequestBody()
                {
                    Price = new PriceUpdateFeedRequestBody.PriceUpdateFeedBasicInfo()
                    {
                        Item = new PriceUpdateFeedRequestBody.PriceUpdateFeedItem[]
                        {
                            new PriceUpdateFeedRequestBody.PriceUpdateFeedItem()
                            {
                                    NeweggItemNumber = "9SIA00602T3895",
                                    CountryCode = "USA",
                                    Currency = "USD",
                                    SellingPrice = 50,
                                    Shipping = FeedShipping.Default,
                                    ActivationMark = FeedActivationMark.True
                            }
                        }
                    }
                }
            };
            CheckRequestString<PriceUpdateFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_PriceUpdateFeed(req);
            Assert.IsType<PriceUpdateFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_InventoryAndPriceFeed()
        {
            InventoryAndPriceFeedRequest req = new InventoryAndPriceFeedRequest()
            {
                Message = new InventoryAndPriceFeedRequestBody()
                {
                    Inventory = new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedBasicInfo()
                    {
                        Item = new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedItem[]
                        {
                            new InventoryAndPriceFeedRequestBody.InventoryAndPriceFeedItem()
                            {
                                NeweggItemNumber = "9SIA00602T3895",
                                Currency = "USD",
                                SellingPrice = 50,
                                Shipping = FeedShipping.Default,
                                Inventory = 10
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi.SubmitFeed_InventoryAndPriceFeed(req);
            Assert.IsType<InventoryAndPriceFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_OrderShipNoticeFeed()
        {
            OrderShipNoticeFeedRequest req = new OrderShipNoticeFeedRequest()
            {
                Message = new OrderShipNoticeFeedRequestBody()
                {
                    ShipNotice = new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedBasicInfo()
                    {
                        Package = new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo[]
                        {
                            new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo()
                            {
                                OrderNumber = 11213213,
                                ActualShippingCarrier = "UPS",
                                ActualShippingMethod = "UPS Ground",
                                TrackingNumber = "20110922002",
                                ItemInformation = new System.Collections.Generic.List<OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo>()
                                {
                                    new OrderShipNoticeFeedRequestBody.OrderShipNoticeFeedPackageInfo.OrderShipNoticeFeedShipItemInfo()
                                    {
                                        SellerPartNumber="data_MP_32900973",
                                        ShippedQuantity=1
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi.SubmitFeed_OrderShipNoticeFeed(req);
            Assert.IsType<OrderShipNoticeFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_MultiChannelOrderFeed()
        {
            MultiChannelOrderFeedRequest req = new MultiChannelOrderFeedRequest()
            {
                Message = new MultiChannelOrderFeedRequestBody()
                {
                    MultiChannelOrder = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedBasicInfo()
                    {
                        Order = new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo[]
                        {
                            new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo()
                            {
                                OrderDate = "2000/02/02",
                                SalesChannel = "3rd channel",
                                SellerOrderID = "131163115",
                                ShippingMethod = FeedShippingMethod.Expedited_Shipping_3to5_business_days,
                                ShipToFirstName = "BIG",
                                ShipToLastName = "MAMA",
                                ShipToAddressLine1 = "Deep Blue",
                                ShipToCity = "abc",
                                ShipToState = "vvvvv",
                                ShipToPostalCode = "61542",
                                ShipToCountry = "USA",
                                ShipToPhoneNumber = "000000000",
                                ItemList = new System.Collections.Generic.List<MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo>()
                                {
                                    new MultiChannelOrderFeedRequestBody.MultiChannelOrderFeedOrderInfo.MultiChannelOrderFeedItemInfo()
                                    {
                                        SellerPartNumber="test1111",
                                        Quantity=10
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var feedstatus = await fakeApi.SubmitFeed_MultiChannelOrderFeed(req);
            Assert.IsType<MultiChannelOrderFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemSubscriptionFeed()
        {
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
            CheckRequestString<ItemSubscriptionFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemSubscriptionFeed(req);
            Assert.IsType<ItemSubscriptionFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_VolumeDiscountFeed()
        {
            VolumeDiscountFeedRequest req = new VolumeDiscountFeedRequest()
            {
                Message = new VolumeDiscountFeedRequestBody()
                {
                    VolumeDiscountList = new System.Collections.Generic.List<SDK.Item.Model.ItemVolumeDiscountInfo>()
                    {
                        new SDK.Item.Model.ItemVolumeDiscountInfo()
                        {
                            SellerPartNumber="tessdasda431313",
                            VolumeActivation=SDK.Item.Model.ItemVolumeDiscountInfo.VolumeDiscountVolumeActivation.True,
                            DiscountSetting=new System.Collections.Generic.List<SDK.Item.Model.TierInfo>()
                            {
                                new SDK.Item.Model.TierInfo()
                                {
                                    Priority = 1,
                                    SellingPrice = 0.98M,
                                    Quantity = 10,
                                    EnableFreeShipping = 0
                                },new SDK.Item.Model.TierInfo()
                                {
                                    Priority = 2,
                                    SellingPrice = 0.90M,
                                    Quantity = 100,
                                    EnableFreeShipping = 0
                                }
                            }
                        }
                    }
                }
            };
            XmlSerializer xmlSerializer = new XmlSerializer();
            string xmls = xmlSerializer.Serialize<VolumeDiscountFeedRequest>(req);
            JsonSerializer jsonSerializer = new JsonSerializer(true);
            string jsons = jsonSerializer.Serialize<VolumeDiscountFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_VolumeDiscountFeed(req);
            Assert.IsType<VolumeDiscountFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemPromotionFeed()
        {
            ItemPromotionFeedRequest req = new ItemPromotionFeedRequest()
            {
                Message = new ItemPromotionFeedRequestBody()
                {
                    Item = new ItemPromotionFeedRequestBody.ItemPromotionFeedItem[]
                    {
                        new ItemPromotionFeedRequestBody.ItemPromotionFeedItem()
                        {
                            SellerPartNumber = "test11111",
                            PromoMSRP = 55,
                            PromoSellingPrice = 20.9m,
                            PromoShipping = FeedShipping.Default,
                            PromoStartDate = System.DateTime.Now,
                            PromoEndDate = System.DateTime.Parse("2019/07/07"),
                            InventoryLocked = FeedInventoryLocked.No
                        },
                        new ItemPromotionFeedRequestBody.ItemPromotionFeedItem()
                        {
                            SellerPartNumber = "test11ss111",
                            PromoMSRP = 55,
                            PromoSellingPrice = 20.9m,
                            PromoShipping = FeedShipping.Default,
                            PromoStartDate = System.DateTime.Now,
                            PromoEndDate = System.DateTime.Parse("2019/07/10"),
                            InventoryLocked = FeedInventoryLocked.No
                        }
                    }
                }
            };
            CheckRequestString<ItemPromotionFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemPromotionFeed(req);
            Assert.IsType<ItemPromotionFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemPremierMarkFeed()
        {
            ItemPremierMarkFeedRequest req = new ItemPremierMarkFeedRequest()
            {
                Message = new ItemPremierMarkFeedRequestBody()
                {
                    Item = new ItemPremierMarkFeedRequestBody.ItemPremierMarkFeedItem[]
                    {
                        new ItemPremierMarkFeedRequestBody.ItemPremierMarkFeedItem()
                        {
                            SellerPartNumber="test6265661",
                            PremierMark=FeedPremierMark.TRUE
                        }
                    }
                }
            };
            CheckRequestString<ItemPremierMarkFeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemPremierMarkFeed(req);
            Assert.IsType<ItemPremierMarkFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemCAProp65Feed()
        {
            ItemCAProp65FeedRequest req = new ItemCAProp65FeedRequest()
            {
                Message = new ItemCAProp65FeedRequestBody()
                {
                    Itemfeed = new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo[]
                    {
                        new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo()
                        {
                            Item=new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem[]
                            {
                                new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem()
                                {
                                    SellerPartNumber="test113131313",
                                    WarningType_ID=FeedWarningTypeID.CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants__LongForm,
                                    ChemicalName_Carcinogen="dasdasdnlasndlnzlda"
                                }
                            }

                        },
                        new ItemCAProp65FeedRequestBody.ItemCAProp65FeedInfo()
                        {
                            Item=new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem[]
                            {
                                new ItemCAProp65FeedRequestBody.ItemCAProp65FeedItem()
                                {
                                    SellerPartNumber="test1131ss31313",
                                    WarningType_ID=FeedWarningTypeID.CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants__LongForm,
                                    ChemicalName_Carcinogen="dasdasadnlasndlnzlda"
                                }
                            }

                        }
                    }
                }
            };
            CheckRequestString<ItemCAProp65FeedRequest>(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemCAProp65Feed(req);
            Assert.IsType<ItemCAProp65FeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task SubmitFeed_ItemChinaTaxSettingFeed()
        {
            ItemChinaTaxSettingFeedRequest req = new ItemChinaTaxSettingFeedRequest()
            {
                Message = new ItemChinaTaxSettingFeedRequestBody()
                {
                    ChinaTaxSetting = new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo[]
                    {
                        new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo()
                        {
                            Item=new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem[]
                            {
                                new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem()
                                {
                                    SellerPartNumber="test113131313",
                                    TaxDutyType=FeedTaxDutyType.DDP,
                                    ImportType=FeedImportType.EE
                                }
                            }
                        },
                        new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedInfo()
                        {
                            Item=new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem[]
                            {
                                new ItemChinaTaxSettingFeedRequestBody.ItemChinaTaxSettingFeedItem()
                                {
                                    SellerPartNumber="test11313ss1313",
                                    TaxDutyType=FeedTaxDutyType.ATI,
                                    ImportType=FeedImportType.EE
                                }
                            }
                        }
                    }
                }
            };
            CheckRequestString(req);
            var feedstatus = await fakeApi.SubmitFeed_ItemChinaTaxSettingFeed(req);
            Assert.IsType<ItemChinaTaxSettingFeedResponse>(feedstatus);
            Assert.True(feedstatus.IsSuccess);
            Assert.True(feedstatus.ResponseBody.ResponseList.Count == 1);
        }

        [Fact]
        public async Task GetFeedResult()
        {
            var feedstatus = await fakeApi.GetFeedResult("230YVZLG79V4T");
            Assert.IsType<GetFeedResultResponse>(feedstatus);
            Assert.True(feedstatus.Message.ProcessingReport.ResultList.Length == 2);
        }

        [Fact]
        public async Task GetFeedResult_Json()
        {
            var feedstatus2 = await fakeApi_json.GetFeedResult("230YVZLG79V4T");
            Assert.IsType<GetFeedResultResponse>(feedstatus2);
            Assert.True(feedstatus2.Message.ProcessingReport.ResultList.Length == 2);
        }
    }
}

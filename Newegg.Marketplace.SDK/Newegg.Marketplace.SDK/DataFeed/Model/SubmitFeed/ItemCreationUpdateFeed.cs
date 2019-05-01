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
using System.Xml.Serialization;
using System.Xml;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.DataFeed.Model
{

    [XmlRoot("NeweggEnvelope")]
    [JsonConverter(typeof(JsonMoreLevelSeClassConverter), "NeweggEnvelope")]
    public class ItemCreationOrUpdateFeedRequest : SubmitFeedRequest<ItemCreationOrUpdateFeedBody>
    {
        public ItemCreationOrUpdateFeedRequest() : base("1.0", "BatchItemCreation")
        { }
    }

    public class ItemCreationOrUpdateFeedBody
    {
        public ItemCreationUpdateFeedInfo Itemfeed { get; set; }

        public class ItemCreationUpdateFeedInfo
        {
            public ItemfeedSummaryInfo SummaryInfo { get; set; }
            [XmlElement("Item")]
            public ItemCreationUpdateFeedItemInfo[] Item { get; set; }
        }

        public class ItemCreationUpdateFeedItemInfo
        {
            public ItemCreationUpdateFeedItemInfo()
            {
                Action = FeedAction.CreateItem;
            }
            public ItemCreationUpdateFeedItemInfo(FeedAction action)
            {
                Action = action;
            }

            public FeedAction? Action { get; set; }
            public bool ShouldSerializeAction()
            {
                return Action.HasValue;
            }

            public ItemfeedItemBasicInfo BasicInfo { get; set; }
            public XmlSerializableHashtable SubCategoryProperty { get; set; }
        }
    }

    public class ItemfeedSummaryInfo
    {
        public ItemfeedSummaryInfo() { }
        public ItemfeedSummaryInfo(int subCategoryID)
        {
            SubCategoryID = subCategoryID;
        }
        public int SubCategoryID { get; set; }
    }
    public class ItemfeedItemBasicInfo
    {
        [XmlIgnore]
        public string SellerPartNumber { get; set; }
        [XmlElement("SellerPartNumber"), JsonIgnore]
        public XmlNode CDATASellerPartNumber
        {
            get
            {
                if (string.IsNullOrEmpty(SellerPartNumber))
                    return null;
                return new XmlDocument().CreateCDataSection(SellerPartNumber);
            }
            set { SellerPartNumber = value.Value; }
        }

        public string Manufacturer { get; set; }

        [XmlIgnore]
        public string ManufacturerPartsNumber { get; set; }
        [XmlElement("ManufacturerPartsNumber"), JsonIgnore]
        public XmlNode CDATAManufacturerPartsNumber
        {
            get
            {
                if (string.IsNullOrEmpty(ManufacturerPartsNumber))
                    return null;
                return new XmlDocument().CreateCDataSection(ManufacturerPartsNumber);
            }
            set { }
        }

        public string UPCOrISBN { get; set; }
        public string NeweggItemNumber { get; set; }
        public string ManufacturerItemURL { get; set; }
        
        [XmlIgnore]
        public string RelatedSellerPartNumber { get; set; }
        [XmlElement("RelatedSellerPartNumber"), JsonIgnore]
        public XmlNode CDATARelatedSellerPartNumber
        {
            get
            {
                if (string.IsNullOrEmpty(RelatedSellerPartNumber))
                    return null;
                return new XmlDocument().CreateCDataSection(RelatedSellerPartNumber);
            }
            set { }
        }
        
        [XmlIgnore]
        public string WebsiteShortTitle { get; set; }
        [XmlElement("WebsiteShortTitle"), JsonIgnore]
        public XmlNode CDATAWebsiteShortTitle
        {
            get
            {
                if (string.IsNullOrEmpty(WebsiteShortTitle))
                    return null;
                return new XmlDocument().CreateCDataSection(WebsiteShortTitle);
            }
            set { }
        }
        
        [XmlIgnore]
        public string BulletDescription { get; set; }
        [XmlElement("BulletDescription"), JsonIgnore]
        public XmlNode CDATABulletDescription
        {
            get
            {
                if (string.IsNullOrEmpty(BulletDescription))
                    return null;
                return new XmlDocument().CreateCDataSection(BulletDescription);
            }
            set { }
        }
        
        [XmlIgnore]
        public string ProductDescription { get; set; }
        [XmlElement("ProductDescription"), JsonIgnore]
        public XmlNode CDATAProductDescription
        {
            get
            {
                if (string.IsNullOrEmpty(ProductDescription))
                    return null;
                return new XmlDocument().CreateCDataSection(ProductDescription);
            }
            set { }
        }

        public ItemfeedItemDimension ItemDimension { get; set; }

        public decimal ItemWeight { get; set; }
        public int PacksOrSets { get; set; }
        
        public FeedItemCondition? ItemCondition { get; set; }
        public bool ShouldSerializeItemCondition()
        {
            return ItemCondition.HasValue;
        }

        public FeedItemPackage? ItemPackage { get; set; }
        public bool ShouldSerializeItemPackage()
        {
            return ItemPackage.HasValue;
        }
        
        public FeedShippingRestriction? ShippingRestriction { get; set; }
        public bool ShouldSerializeShippingRestriction()
        {
            return ShippingRestriction.HasValue;
        }

        public string Currency { get; set; }

        public decimal? MSRP { get; set; }
        public bool ShouldSerializeMSRP()
        {
            return MSRP.HasValue;
        }

        public decimal? MAP { get; set; }
        public bool ShouldSerializeMAP()
        {
            return MAP.HasValue;
        }

        public FeedCheckoutMAP? CheckoutMAP { get; set; }
        public bool ShouldSerializeCheckoutMAP()
        {
            return CheckoutMAP.HasValue;
        }

        public decimal SellingPrice { get; set; }

        public FeedShipping? Shipping { get; set; }
        public bool ShouldSerializeShipping()
        {
            return Shipping.HasValue;
        }

        public int Inventory { get; set; }

        
        public FeedActivationMark? ActivationMark { get; set; }
        public bool ShouldSerializeActivationMark()
        {
            return ActivationMark.HasValue;
        }

        [XmlArrayItem("Image")]
        [JsonConverter(typeof(JsonMoreLevelSeConverter), "Image")]
        public List<ItemfeedItemImage> ItemImages { get; set; }

        /// <summary>
        /// USA Only
        /// </summary>
        public string ConditionDetails { get; set; }

        /// <summary>
        /// USA Only
        /// </summary>
        [XmlArrayItem("Image")]
        [JsonConverter(typeof(JsonMoreLevelSeConverter), "Image")]
        public List<ItemfeedItemImage> UsedItemImages { get; set; }

        public ItemfeedItemWarning Warning { get; set; }


        public class ItemfeedItemDimension
        {
            public decimal? ItemLength { get; set; }
            public bool ShouldSerializeItemLength()
            {
                return ItemLength.HasValue;
            }

            public decimal? ItemWidth { get; set; }
            public bool ShouldSerializeItemWidth()
            {
                return ItemWidth.HasValue;
            }

            public decimal? ItemHeight { get; set; }
            public bool ShouldSerializeItemHeight()
            {
                return ItemHeight.HasValue;
            }
        }
        public class ItemfeedItemImage
        {
            public string ImageUrl { get; set; }
            public bool? IsPrimary { get; set; }
        }
        public class ItemfeedItemWarning
        {
            public string CountryOfOrigin { get; set; }
            
            public FeedItemWarningOverAge18? OverAge18Verification { get; set; }
            public bool ShouldSerializeOverAge18Verification()
            {
                return OverAge18Verification.HasValue;
            }

            public ItemfeedItemChokingHazard ChokingHazard { get; set; }
        }

        public class ItemfeedItemChokingHazard
        {
            public FeedChokingHazardSmallParts? SmallParts { get; set; }
            public bool ShouldSerializeSmallParts()
            {
                return SmallParts.HasValue;
            }
            
            public FeedChokingHazardSmallBall? SmallBall { get; set; }
            public bool ShouldSerializeSmallBall()
            {
                return SmallBall.HasValue;
            }
            
            public FeedChokingHazardBalloons? Balloons { get; set; }
            public bool ShouldSerializeBalloons()
            {
                return Balloons.HasValue;
            }
            
            public FeedChokingHazardMarble? Marble { get; set; }
            public bool ShouldSerializeMarble()
            {
                return Marble.HasValue;
            }
        }
    }
    
    [XmlRoot("NeweggAPIResponse")]
    public class ItemCreationOrUpdateFeedResponse : SubmitFeedResponse
    { }
}

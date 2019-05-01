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

using System.Runtime.Serialization;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Newegg.Marketplace.SDK.DataFeed.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedRequestStatus
    {
        [XmlEnum("ALL"), EnumMember(Value = "ALL")]
        ALL,
        [XmlEnum("SUBMITTED"), EnumMember(Value = "SUBMITTED")]
        SUBMITTED,
        [XmlEnum("IN_PROGRESS"), EnumMember(Value = "IN_PROGRESS")]
        IN_PROGRESS,
        [XmlEnum("FINISHED"), EnumMember(Value = "FINISHED")]
        FINISHED,
        [XmlEnum("CANCELLED"), EnumMember(Value = "CANCELLED")]
        CANCELLED
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedOverwrite
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedFulfillmentOption
    {
        [XmlEnum("Newegg"), EnumMember(Value = "Newegg")]
        Newegg,
        [XmlEnum("Seller"), EnumMember(Value = "Seller")]
        Seller
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedWarningTypeID
    {
        [XmlEnum("103"), EnumMember(Value = "103")]
        CONSUMER_PRODUCTS_For_exposures_to_listed_carcinogens_LongForm = 103,
        [XmlEnum("104"), EnumMember(Value = "104")]
        CONSUMER_PRODUCTS_For_exposures_to_listed_carcinogens_ShortForm = 104,
        [XmlEnum("105"), EnumMember(Value = "105")]
        CONSUMER_PRODUCTS_For_exposures_to_listed_reproductive_toxicants_LongForm = 105,
        [XmlEnum("106"), EnumMember(Value = "106")]
        CONSUMER_PRODUCTS_For_exposures_to_listed_reproductive_toxicants_ShortForm = 106,
        [XmlEnum("107"), EnumMember(Value = "107")]
        CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants__LongForm = 107,
        [XmlEnum("108"), EnumMember(Value = "108")]
        CONSUMER_PRODUCTS_For_exposures_to_both_listed_carcinogens_and_reproductive_toxicants_ShortForm = 108,
        [XmlEnum("109"), EnumMember(Value = "109")]
        CONSUMER_PRODUCTS_For_exposures_to_a_chemical_that_is_listed_as_both_a_carcinogen_and_a_reproductive_toxicant_LongForm = 109,
        [XmlEnum("110"), EnumMember(Value = "110")]
        FOOD_For_exposure_to_a_listed_carcinogen = 110,
        [XmlEnum("111"), EnumMember(Value = "111")]
        FOOD_For_exposure_to_a_listed_reproductive_toxicant = 111,
        [XmlEnum("112"), EnumMember(Value = "112")]
        FOOD_For_exposure_to_both_listed_carcinogens_and_reproductive_toxicants = 112,
        [XmlEnum("113"), EnumMember(Value = "113")]
        FOOD_For_exposure_to_a_chemical_that_is_listed_as_both_a_carcinogen_and_a_reproductive_toxicant = 113,
        [XmlEnum("114"), EnumMember(Value = "114")]
        ALCOHOLIC_BEVERAGES = 114,
        [XmlEnum("115"), EnumMember(Value = "115")]
        DIESEL_ENGINES = 115,
        [XmlEnum("116"), EnumMember(Value = "116")]
        FURNITURE = 116,
        [XmlEnum("117"), EnumMember(Value = "117")]
        RECREATIONAL_MARINE_VESSELS = 117,
        [XmlEnum("118"), EnumMember(Value = "118")]
        VEHICLES = 118,
        [XmlEnum("119"), EnumMember(Value = "119")]
        WOOD_DUST_TOOLS = 119
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedTaxDutyType
    {
        [XmlEnum("Default"), EnumMember(Value = "Default")]
        Default,
        [XmlEnum("DDU"), EnumMember(Value = "DDU")]
        DDU,
        [XmlEnum("DDP"), EnumMember(Value = "DDP")]
        DDP,
        [XmlEnum("ATI"), EnumMember(Value = "ATI")]
        ATI
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedImportType
    {
        [XmlEnum("Default"), EnumMember(Value = "Default")]
        Default,
        [XmlEnum("EE"), EnumMember(Value = "EE")]
        EE,
        [XmlEnum("EEP"), EnumMember(Value = "EEP")]
        EEP
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedAction
    {
        [XmlEnum("Create Item"), EnumMember(Value = "Create Item")]
        CreateItem,
        [XmlEnum("Update Item"), EnumMember(Value = "Update Item")]
        UpdateItem,
        [XmlEnum("Update/Append Image"), EnumMember(Value = "Update/Append Image")]
        UpdateAppendImage,
        [XmlEnum("Replace Image"), EnumMember(Value = "Replace Image")]
        ReplaceImage
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedItemCondition
    {
        [XmlEnum("New"), EnumMember(Value = "New")]
        New,
        [XmlEnum("Refurbished"), EnumMember(Value = "Refurbished")]
        Refurbished,
        [XmlEnum("UsedLikeNew"), EnumMember(Value = "UsedLikeNew")]
        UsedLikeNew,
        [XmlEnum("UsedVeryGood"), EnumMember(Value = "UsedVeryGood")]
        UsedVeryGood,
        [XmlEnum("UsedGood"), EnumMember(Value = "UsedGood")]
        UsedGood,
        [XmlEnum("UsedAcceptable"), EnumMember(Value = "UsedAcceptable")]
        UsedAcceptable
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedPremierMark
    {
        [XmlEnum("TRUE"), EnumMember(Value = "TRUE")]
        TRUE,
        [XmlEnum("FALSE"), EnumMember(Value = "FALSE")]
        FALSE
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedInventoryLocked
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("No"), EnumMember(Value = "No")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedItemSubscriptionAction
    {
        /// <summary>
        /// default
        /// </summary>
        [XmlEnum("Add"), EnumMember(Value = "Add")]
        Add,
        [XmlEnum("Remove"), EnumMember(Value = "Remove")]
        Remove
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedShippingMethod
    {
        [XmlEnum("Standard Shipping (5-7 business days)"), EnumMember(Value = "Standard Shipping (5-7 business days)")]
        Standard_Shipping_5to7_business_days,
        [XmlEnum("Expedited Shipping (3-5 business days)"), EnumMember(Value = "Expedited Shipping (3-5 business days)")]
        Expedited_Shipping_3to5_business_days,
        [XmlEnum("Two-Day Shipping"), EnumMember(Value = "Two-Day Shipping")]
        Two_Day_Shipping,
        [XmlEnum("One-Day Shipping"), EnumMember(Value = "One-Day Shipping")]
        One_Day_Shipping,
        /// <summary>
        /// CAN Only
        /// </summary>
        [XmlEnum("CAN Ground (2-7 business days)"), EnumMember(Value = "CAN Ground (2-7 business days)")]
        CAN_Ground_2to7_business_days,
        /// <summary>
        /// CAN Only
        /// </summary>
        [XmlEnum("CAN Express (2-5 business days)"), EnumMember(Value = "CAN Express (2-5 business days)")]
        CAN_Express_2to5_business_days
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedChokingHazardSmallParts
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("No"), EnumMember(Value = "No")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedChokingHazardSmallBall
    {
        [XmlEnum("Is a small ball"), EnumMember(Value = "AddIs a small ball")]
        Is_a_small_ball,
        [XmlEnum("Contains a small ball"), EnumMember(Value = "Contains a small ball")]
        Contains_a_small_ball
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedChokingHazardBalloons
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("No"), EnumMember(Value = "No")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedChokingHazardMarble
    {
        [XmlEnum("Is a marble"), EnumMember(Value = "Is a marble")]
        Is_a_marble,
        [XmlEnum("Contains a marble"), EnumMember(Value = "Contains a marble")]
        Contains_a_marble
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedShippingRestriction
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("No"), EnumMember(Value = "No")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedItemPackage
    {
        [XmlEnum("Retail"), EnumMember(Value = "Retail")]
        Retail,
        [XmlEnum("OEM"), EnumMember(Value = "OEM")]
        OEM
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedShipping
    {
        [XmlEnum("Default"), EnumMember(Value = "Default")]
        Default,
        [XmlEnum("Free"), EnumMember(Value = "Free")]
        Free
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedItemWarningOverAge18
    {
        [XmlEnum("Yes"), EnumMember(Value = "Yes")]
        Yes,
        [XmlEnum("No"), EnumMember(Value = "No")]
        No
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedActivationMark
    {
        [XmlEnum("True"), EnumMember(Value = "True")]
        True,
        [XmlEnum("False"), EnumMember(Value = "False")]
        False
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeedCheckoutMAP
    {
        [XmlEnum("True"), EnumMember(Value = "True")]
        True,
        [XmlEnum("False"), EnumMember(Value = "False")]
        False
    }
   


    public enum RequestType
    {
        ITEM_DATA,
        INVENTORY_DATA,
        PRICE_DATA,
        INVENTORY_AND_PRICE_DATA,
        ORDER_SHIP_NOTICE_DATA,
        MULTICHANNEL_ORDER_DATA,
        ITEM_SUBSCRIPTION,
        VOLUME_DISCOUNT_DATA,
        ITEM_PROMOTION_DATA,
        ITEM_PREMIER_MARK_DATA,
        ITEM_CAPROP65_DATA,
        ITEM_CHINATAXSETTING_DATA,
        INTERNATIONAL_INVENTORY_REPORT,
        SETTLEMENT_TRANSACTION_REPORT,
        CAPROP65_REPORT
    }

}

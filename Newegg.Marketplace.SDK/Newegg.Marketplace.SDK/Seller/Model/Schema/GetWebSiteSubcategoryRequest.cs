using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetWebSiteSubcategoryRequest : RequestModel<GetWebSiteSubcategoryRequestBody>
    {
        public GetWebSiteSubcategoryRequest()
        {
            OperationType = "GetSellerSubcategoryRequest";
        }
    }

    /// <summary>
    /// 所有符合条件的im itemcatalog信息
    /// </summary>
    public class GetWebSiteSubcategoryRequestBody
    {
        /// <summary>
        /// 国家code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///  隐藏显示
        /// </summary>
        [JsonIgnore]
        public string PlatformCode { get; set; }

        /// <summary>
        /// 相关参数
        /// </summary>
        public GetWebSiteSubcategory GetItemSubcategory { get; set; }
    }

    /// <summary>
    ///  具体的过滤条件
    /// </summary>
    public class GetWebSiteSubcategory
    {
        /// <summary>
        ///  子分类id
        /// </summary>
        [XmlArrayItem(ElementName = "SubcategoryID")]
        public List<int> SubcategoryIDList { set; get; }

        /// <summary>
        ///  行业code
        /// </summary>
        [XmlArrayItem(ElementName = "IndustryCode")]
        public List<string> IndustryCodeList { set; get; }

        /// <summary>
        ///  过滤分类的启用状态
        /// </summary>
        public SellerSubcategoryStatusEnabled? Enabled { set; get; }

        /// <summary>
        ///  类别id
        /// </summary>
        [XmlArrayItem(ElementName = "WebSiteCategoryID")]
        public List<int> WebSiteCategoryIDList { get; set; }

        /// <summary>
        ///   分类名称
        /// </summary>
        public string WebSiteCatalogName { get; set; }
    }
}

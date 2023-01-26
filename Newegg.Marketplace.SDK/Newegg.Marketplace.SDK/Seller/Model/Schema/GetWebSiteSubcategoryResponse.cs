using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetWebSiteSubcategoryResponse : ResponseModel<GetWebSiteSubcategoryResponseBody>
    {
        public GetWebSiteSubcategoryResponse()
        {
            OperationType = "GetSellerSubcategoryResponse";
        }
    }

    /// <summary>
    ///  获取item子分类接口的返回实体
    /// </summary>
    public class GetWebSiteSubcategoryResponseBody
    {
        [XmlArrayItem(ElementName = "Subcategory")]
        public List<WebSiteSubcategory> SubcategoryList { set; get; }
    }

    /// <summary>
    ///  子分类相关信息
    /// </summary>
    public class WebSiteSubcategory
    {

        /// <summary>
        ///  行业code
        /// </summary>
        public string IndustryCode { get; set; }

        /// <summary>
        /// 行业名称
        /// </summary>
        [XmlIgnore]
        public string IndustryName { set; get; }

        /// <summary>
        ///  xml 序列化时显示的名称
        /// </summary>
        [XmlElement("IndustryName"), JsonIgnore]
        public XmlNode CDATAIndustryName
        {
            get { return new XmlDocument().CreateCDataSection(IndustryName); }
            set { IndustryName = value.Value; }

        }

        /// <summary>
        ///  分类id
        /// </summary>
        public int SubcategoryID { get; set; }

        /// <summary>
        ///  子分类名称 ,xml 序列化时不返回 
        /// </summary>
        [XmlIgnore]
        public string SubcategoryName { set; get; }

        /// <summary>
        ///  xml 序列化时显示的名称
        /// </summary>
        [XmlElement("SubcategoryName"), JsonIgnore]
        public XmlNode CDATASubcategoryName
        {
            get { return new XmlDocument().CreateCDataSection(SubcategoryName); }
            set { SubcategoryName = value.Value; }

        }

        /// <summary>
        ///  商家是否启用此分类
        /// </summary>
        public int Enabled { get; set; }

        /// <summary>
        ///  正确类别id
        /// </summary>
        public int WebSiteCategoryID { get; set; }

        /// <summary>
        /// 正确的类别名称
        /// </summary>
        [XmlIgnore]
        public string WebSiteCatalogName { get; set; }

        /// <summary>
        ///  xml 序列化时显示的名称
        /// </summary>
        [XmlElement("WebSiteCatalogName")]
        [JsonIgnore]
        public XmlNode CDATAWebSiteCatalogName
        {
            get { return new XmlDocument().CreateCDataSection(WebSiteCatalogName); }
            set { WebSiteCatalogName = value.Value; }

        }

    }
}

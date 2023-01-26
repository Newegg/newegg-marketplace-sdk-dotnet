using Newegg.Marketplace.SDK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Seller.Model
{
    [XmlRoot("NeweggAPIResponse")]
    public class GetWarehouseResponse : ResponseModel<GetWebSiteSubcategoryResponseBody>
    {
        public GetWarehouseResponse()
        {
            OperationType = "GetSellerWarehouseResponse";
        }
    }

    public class WarehouseListResponseBody
    {
        [XmlArrayItem(ElementName = "Warehouse")]
        public List<WarehouseItem> WarehouseList { set; get; }
    }


    public class WarehouseItem
    {
        /// <summary>
        ///  仓库所在国家
        /// </summary>
        public string WarehouseLocation { get; set; }

        /// <summary>
        ///  是否启用 1：启用 0：不启用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArrayItem(ElementName = "CountryCode")]
        public List<string> ShippingDestination { get; set; }
    }
}

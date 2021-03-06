﻿/**
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
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Model;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Report.Model

{
    [XmlRoot("NeweggAPIResponse")]
    public class GetItemLookupReportResponse : ResponseModel<GetItemLookupReportResponseBody>
    {      
        public GetItemLookupReportResponse()
        {
            OperationType = "ItemLookupResponse";
            ResponseDate = DateTime.Now.ToString("MM\\/dd\\/yyyy HH:mm:ss");
        }
        public string Memo { get; set; }
       
    }

    public class GetItemLookupReportResponseBody
    {
        [DataMember(Order = 0)]
        public GetReportPageInfo PageInfo { get; set; }

        [DataMember(Order = 1)]
        public string RequestID { get; set; }

        [DataMember(Order = 2)]      
        public string RequestDate { get; set; }
      

        [XmlArrayItem("Item"), JsonConverter(typeof(JsonMoreLevelSeConverter), "Item")]
        [DataMember(Order = 3)]
        public List<ItemLookup> ItemList { set; get; }
    }

    public class ItemLookup
    {
        public string NeweggItemNumber { get; set; }
        public string ParentItemNumber { get; set; }
        public string UPC { get; set; }
     
        public ReportCondition Condition { get; set; }
       
        public int? PacksOrSets { set; get; }        
        public bool ShouldSerializePacksOrSets()
        {
            return PacksOrSets.HasValue;
        }

        public string ManufacturerName { get; set; }
      
        public string ManufacturerPartNumber { get; set; }
      
        public string WebsiteShortTitle { get; set; }
       
        public string Note { get; set; }
    }

}

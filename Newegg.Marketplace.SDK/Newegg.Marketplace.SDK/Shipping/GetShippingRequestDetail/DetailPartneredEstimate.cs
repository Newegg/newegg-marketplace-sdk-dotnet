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

using System;
using System.Xml.Serialization;

using Newtonsoft.Json;
namespace Newegg.Marketplace.SDK.Shipping.Model
{
    public class DetailPartneredEstimate
    {
        
        [XmlElement("BillableWeight"), JsonProperty("BillableWeight")]
        public string _BillableWeight { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? BillableWeight
        {
            get
            {
                if (string.IsNullOrEmpty(_BillableWeight))
                    return null;
                return decimal.Parse(_BillableWeight);
            }
            set { }
        }


        public string EstimatedDeliveryDay
        {
            get
            {
                if (!this.EstimatedDeliveryDateObj.HasValue)
                {
                    return string.Empty;
                }
                return this.EstimatedDeliveryDateObj.Value.ToString("MM\\/dd\\/yyyy");
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.EstimatedDeliveryDateObj = null;
                    return;
                }
                else
                {
                    EstimatedDeliveryDateObj = DateTime.Parse(value);
                }
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        public DateTime? EstimatedDeliveryDateObj { get; set; }
      
        [XmlElement("EstimatedChargeAmount"), JsonProperty("EstimatedChargeAmount")]
        public string _EstimatedChargeAmount { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? EstimatedChargeAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_EstimatedChargeAmount))
                    return null;
                return decimal.Parse(_EstimatedChargeAmount);
            }
            set { }
        }



    }
}
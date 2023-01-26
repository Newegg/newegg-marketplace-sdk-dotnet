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
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.Model;

using Newtonsoft.Json;

namespace Newegg.Marketplace.SDK.Report.Model

{
    [XmlRoot("NeweggAPIResponse")]
    public class GetSettlementSummaryInfoResponse : ResponseModel<GetSettlementSummaryInfoResponseBody>
    {
        public string sellerID { get; set; }
        public GetSettlementSummaryInfoResponse()
        {
            OperationType = "GetSettlementSummaryInfoResponse";
        }
       
        public string Memo { get; set; }
       
    }

    public class GetSettlementSummaryInfoResponseBody
    {
        [DataMember(Order = 0)]
        public GetReportPageInfo PageInfo { get; set; }

        [DataMember(Order = 1)]
        public string RequestID { get; set; }

        [DataMember(Order = 2)]
      
        public string RequestDate { get; set; }

       
        [XmlArrayItem("SettlementSummary"), JsonConverter(typeof(JsonMoreLevelSeConverter), "SettlementSummary")]
        [DataMember(Order = 3)]
        public List<SettlementSummary> SettlementSummaryList { get; set; }

    }

   
    public class SettlementSummary
    {
        #region SettlementSummary
        public string SettlementDate { get; set; }
       
        public string SettlementDateFrom { get; set; }
        
        public string SettlementDateTo { get; set; }
        
        public string SettlementID { get; set; }
       
        public string CheckNumber { get; set; }
        
        public decimal ItemPrice { get; set; }
        
        public decimal Shipping { get; set; }
       
        public decimal Other { get; set; }
        
        public decimal TotalOrderAmount { get; set; }
        
        public decimal Refunds { get; set; }
        
        public decimal ChargeBack { get; set; }
       
        public decimal MiscellaneousAdjustment { get; set; }
       
        public decimal TotalRefunds { get; set; }
       
        public decimal NeweggCommissionFee { get; set; }
        
        public decimal NeweggTransactionFee { get; set; }
       
        public decimal NeweggRefundCommissionFee { get; set; }
        
        public decimal NeweggMonthlyFee { get; set; }
       
        public decimal NeweggStorageFee { get; set; }
      
        public decimal NeweggRMABuyoutFee { get; set; }
      
        public decimal NeweggPremierFee { get; set; }
      
        public decimal NeweggShippingLabelFee { get; set; }       
        
        public decimal TotalNeweggFee { get; set; }
       
        public decimal TotalSettlement { get; set; }

        [XmlElement("RecyclingFeeTotal"), JsonProperty("RecyclingFeeTotal")]
        public string _RecyclingFeeTotal { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? RecyclingFeeTotal
        {
            get
            {
                if (string.IsNullOrEmpty(_RecyclingFeeTotal))
                    return null;
                return decimal.Parse(_RecyclingFeeTotal);
            }
        }
        [XmlElement("TaxDuty"), JsonProperty("TaxDuty")]
        public string _TaxDuty { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? TaxDuty
        {
            get
            {
                if (string.IsNullOrEmpty(_TaxDuty))
                    return null;
                return decimal.Parse(_TaxDuty);
            }
        }
        [XmlElement("CourtesyRefund"), JsonProperty("CourtesyRefund")]
        public string _CourtesyRefund { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? CourtesyRefund
        {
            get
            {
                if (string.IsNullOrEmpty(_CourtesyRefund))
                    return null;
                return decimal.Parse(_CourtesyRefund);
            }
        }

        [XmlElement("CreditCardPayment"), JsonProperty("CreditCardPayment")]
        public string _CreditCardPayment { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? CreditCardPayment
        {
            get
            {
                if (string.IsNullOrEmpty(_CreditCardPayment))
                    return null;
                return decimal.Parse(_CreditCardPayment);
            }
        }

        [XmlElement("FulfillmentByNeweggFee"), JsonProperty("FulfillmentByNeweggFee")]
        public string _FulfillmentByNeweggFee { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? FulfillmentByNeweggFee
        {
            get
            {
                if (string.IsNullOrEmpty(_FulfillmentByNeweggFee))
                    return null;
                return decimal.Parse(_FulfillmentByNeweggFee);
            }
        }

        [XmlElement("MultiChannelFee"), JsonProperty("MultiChannelFee")]
        public string _MultiChannelFee { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? MultiChannelFee
        {
            get
            {
                if (string.IsNullOrEmpty(_MultiChannelFee))
                    return null;
                return decimal.Parse(_MultiChannelFee);
            }
        }

        [XmlElement("AdjustmentFee"), JsonProperty("AdjustmentFee")]
        public string _AdjustmentFee { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? AdjustmentFee
        {
            get
            {
                if (string.IsNullOrEmpty(_AdjustmentFee))
                    return null;
                return decimal.Parse(_AdjustmentFee);
            }
        }

        [XmlElement("MerchandisingFee"), JsonProperty("MerchandisingFee")]
        public string _MerchandisingFee { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? MerchandisingFee
        {
            get
            {
                if (string.IsNullOrEmpty(_MerchandisingFee))
                    return null;
                return decimal.Parse(_MerchandisingFee);
            }
        }

        [XmlElement("GSTAndHST"), JsonProperty("GSTAndHST")]
        public string _GSTAndHST { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? GSTAndHST
        {
            get
            {
                if (string.IsNullOrEmpty(_GSTAndHST))
                    return null;
                return decimal.Parse(_GSTAndHST);
            }
        }

        [XmlElement("PSTAndQST"), JsonProperty("PSTAndQST")]
        public string _PSTAndQST { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PSTAndQST
        {
            get
            {
                if (string.IsNullOrEmpty(_PSTAndQST))
                    return null;
                return decimal.Parse(_PSTAndQST);
            }
        }

        [XmlElement("PSTTotal"), JsonProperty("PSTTotal")]
        public string _PSTTotal { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PSTTotal
        {
            get
            {
                if (string.IsNullOrEmpty(_PSTTotal))
                    return null;
                return decimal.Parse(_PSTTotal);
            }
        }

        [XmlElement("ReservedBalance"), JsonProperty("ReservedBalance")]
        public string _ReservedBalance { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? ReservedBalance
        {
            get
            {
                if (string.IsNullOrEmpty(_ReservedBalance))
                    return null;
                return decimal.Parse(_ReservedBalance);
            }
        }

        [XmlElement("PreviousReservedBalance"), JsonProperty("PreviousReservedBalance")]
        public string _PreviousReservedBalance { get; set; }
        [XmlIgnore, JsonIgnore]
        public decimal? PreviousReservedBalance
        {
            get
            {
                if (string.IsNullOrEmpty(_PreviousReservedBalance))
                    return null;
                return decimal.Parse(_PreviousReservedBalance);
            }
        }


        #endregion

    }




}

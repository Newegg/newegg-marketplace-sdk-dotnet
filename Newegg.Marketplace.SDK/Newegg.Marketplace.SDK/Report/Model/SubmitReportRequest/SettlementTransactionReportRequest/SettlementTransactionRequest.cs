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


using Newegg.Marketplace.SDK.Model;


namespace Newegg.Marketplace.SDK.Report.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class SettlementTransactionRequest : RequestModel<SettlementTransactionRequestBody>
    {
        public SettlementTransactionRequest()
        {
            OperationType = "SettlementTransactionReportRequest";
          
        }
       
    }
    public class SettlementTransactionRequestBody
    {
        public SettlementTransactionReportCriteria SettlementTransactionReportCriteria
        {
            get;
            set;
        }

    }

    public class SettlementTransactionReportCriteria
    {
        #region Constructors
        public SettlementTransactionReportCriteria()
            : this(DateTime.Now, DateTime.Now)
        { }
        public SettlementTransactionReportCriteria(DateTime settlementDateFrom, DateTime settlementDateTo)
        {
            this.RequestType = ReportRequestType.SETTLEMENT_TRANSACTION_REPORT.ToString();
            this.TransactionType = (int)(ReportTransactionType.All);//預設為ALL
            this.SettlementDateFrom = settlementDateFrom.ToString("yyyy-MM-dd");
            this.SettlementDateTo = settlementDateTo.ToString("yyyy-MM-dd");
            this.SettlementDate = settlementDateTo.ToString("MM/dd/yyyy");
        }
        #endregion

        #region Properties
        public string OrderNumber
        {
            get;
            set;
        }
        public ReportTransactionType TransactionType 
        {
            get;
            set;
        }
        public string SettlementDateFrom
        {
            get;
            set;
        }
        public string SettlementDateTo
        {
            get;
            set;
        }
        public string SettlementDate
        {
            get;
            set;
        }
        public string SettlementID
        {
            get;
            set;
        }
        public string RequestType
        {
            get;
            set;
        }

      
        #endregion

    }

  
}

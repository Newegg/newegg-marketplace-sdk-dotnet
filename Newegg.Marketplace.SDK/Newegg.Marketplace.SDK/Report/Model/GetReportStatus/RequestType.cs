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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Report.Model
{
    /// <summary>
	/// Why do we use Struct but not Class when define OperationType class?
	/// <para>Because we can't be permited to customize json serialization when using ServiceStack;</para>
	/// <para>Refer to http://www.servicestack.net/docs/text-serializers/json-serializer</para>
	/// </summary>
	public struct RequestType : IXmlSerializable
    {
        #region Fields
        private string value;
        #endregion

        #region Constructors
        private RequestType(string value)
        {
            this.value = value;
        }
        #endregion

        #region Properties
        public static readonly RequestType ORDER_LIST_REPORT = new RequestType("ORDER_LIST_REPORT");
        public static readonly RequestType SETTLEMENT_SUMMARY_REPORT = new RequestType("SETTLEMENT_SUMMARY_REPORT");
        public static readonly RequestType SETTLEMENT_TRANSACTION_REPORT = new RequestType("SETTLEMENT_TRANSACTION_REPORT");
        public static readonly RequestType SETTLEMENT_TRASACTION_REPORT = new RequestType("SETTLEMENT_TRASACTION_REPORT");
        public static readonly RequestType DAILY_INVENTORY_REPORT = new RequestType("DAILY_INVENTORY_REPORT");
        public static readonly RequestType RMA_LIST_REPORT = new RequestType("RMA_LIST_REPORT");
        public static readonly RequestType INTERNATIONAL_INVENTORY_REPORT= new RequestType("INTERNATIONAL_INVENTORY_REPORT");
        public static readonly RequestType INTERNATIONAL_PRICE_REPORT = new RequestType("INTERNATIONAL_PRICE_REPORT");
        public static readonly RequestType PREMIER_ITEM_REPORT = new RequestType("PREMIER_ITEM_REPORT");
        public static readonly RequestType CAPROP65_REPORT = new RequestType("CAPROP65_REPORT");
        public static readonly RequestType ITEM_CHINATAXSETTING_REPORT = new RequestType("ITEM_CHINATAXSETTING_REPORT");
        #endregion

        #region Methods
        public override string ToString()
        {
            return this.value;
        }
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            try
            {
                RequestType instance = (RequestType)obj;
                return this.value == instance.value;
            }
            catch
            {
                return false;
            }
        }
        public static implicit operator string(RequestType obj)
        {
            return obj.value;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(value);
        }
        public void ReadXml(XmlReader reader)
        {
            value = reader.ReadString();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public static RequestType Parse(string str)
        {
            if (str == ORDER_LIST_REPORT.value)
            {
                return ORDER_LIST_REPORT;
            }
            else if (str == SETTLEMENT_SUMMARY_REPORT.value)
            {
                return SETTLEMENT_SUMMARY_REPORT;
            }
            else if (str == SETTLEMENT_TRANSACTION_REPORT.value)
            {
                return SETTLEMENT_TRANSACTION_REPORT;
            }
            else if (str == SETTLEMENT_TRASACTION_REPORT.value)
            {
                return SETTLEMENT_TRASACTION_REPORT;
            }
            else if (str == DAILY_INVENTORY_REPORT.value)
            {
                return DAILY_INVENTORY_REPORT;
            }
            else if (str == RMA_LIST_REPORT.value)
            {
                return RMA_LIST_REPORT;
            }
            else if (str == INTERNATIONAL_INVENTORY_REPORT.value)
            {
                return INTERNATIONAL_INVENTORY_REPORT;
            }
            else if (str == INTERNATIONAL_PRICE_REPORT.value)
            {
                return INTERNATIONAL_PRICE_REPORT;
            }
            else if (str == PREMIER_ITEM_REPORT.value)
            {
                return PREMIER_ITEM_REPORT;
            }
            else if (str == CAPROP65_REPORT.value)
            {
                return CAPROP65_REPORT;
            }
            else if (str == ITEM_CHINATAXSETTING_REPORT.value)
            {
                return ITEM_CHINATAXSETTING_REPORT;
            }
            else
            {
                throw new InvalidCastException("The value cannot be converted to RequestType instance");
            }
        }
        #endregion
    }
}
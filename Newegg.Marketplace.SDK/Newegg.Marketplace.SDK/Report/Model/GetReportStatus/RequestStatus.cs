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
	public struct RequestStatus : IXmlSerializable
    {
        #region Fields
        private string value;
        #endregion

        #region Constructors
        private RequestStatus(string value)
        {
            this.value = value;
        }
        #endregion

        #region Properties
        public static readonly RequestStatus SUBMITTED = new RequestStatus("SUBMITTED");
        public static readonly RequestStatus IN_PROGRESS = new RequestStatus("IN_PROGRESS");
        public static readonly RequestStatus FINISHED = new RequestStatus("FINISHED");
        public static readonly RequestStatus CANCELLED = new RequestStatus("CANCELLED");
        public static readonly RequestStatus ALL = new RequestStatus("ALL");
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
                RequestStatus instance = (RequestStatus)obj;
                return this.value == instance.value;
            }
            catch
            {
                return false;
            }
        }
        public static implicit operator string(RequestStatus obj)
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
        public static RequestStatus Parse(string str)
        {
            if (str == SUBMITTED.value)
            {
                return SUBMITTED;
            }
            else if (str == IN_PROGRESS.value)
            {
                return IN_PROGRESS;
            }
            else if (str == FINISHED.value)
            {
                return FINISHED;
            }
            else if (str == CANCELLED.value)
            {
                return CANCELLED;
            }
            else if (str == ALL.value)
            {
                return ALL;
            }
            else
            {
                throw new InvalidCastException("The value cannot be converted to RequestStatus instance");
            }
        }
        #endregion
    }
}
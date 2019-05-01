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
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Newegg.Marketplace.SDK.Model;
using Newtonsoft.Json;

namespace Newegg.Marketplace.SDK.Shipping.Model
{
    [XmlRoot("NeweggAPIRequest")]
    public class GetShippingDetailRequest : RequestModel<GetShippingDetailRequestBody>
    {
        public GetShippingDetailRequest()
        {
            OperationType = "GetShippingDetailRequest";
        }
    }

    public class GetShippingDetailRequestBody
    {
        public string RequestID { get; set; }

        public string OrderNumber { get; set; }

        // <summary>
        // <para>在程序中所使用的OrderNumber</para>
        // <para>仅在当前对象RequestID不为空时,此属性才有值</para>
        // </summary>
        // <exception cref = "Newegg.MKTPLS.Common.API.APIBusinessException" >
        // SL025:表示当前OrderNumber转换失败
        // </exception>
        [XmlIgnore]
        [JsonIgnore]
        public int? SONumber
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.RequestID))
                {
                    int number = 0;
                    if (!int.TryParse(this.OrderNumber, out number))
                    {
                       // 如果RequestID为空,则说明是使用OrderNumber,如果OrderNumber转换失败,则抛出异常
                        throw new APIBusinessException("SL018");//TODO
                    }
                    return number;
                }
                return null;
            }
            set { }

        }



    }

    [Serializable]
    internal class APIBusinessException : Exception
    {
        public APIBusinessException()
        {
        }

        public APIBusinessException(string message) : base(message)
        {
        }

        public APIBusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected APIBusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

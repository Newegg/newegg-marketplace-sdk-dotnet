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
using System.Text;

using Xunit;
using Newtonsoft.Json;

using Newegg.Marketplace.SDK.Base.Util;
using Newegg.Marketplace.SDK.RMA.Model;

namespace Newegg.Marketplace.SDK.Tests.Base
{
    public class ConverterTest
    {
        [Fact]
        public void MoreLevelConverterTest()
        {
            var model = new Parent()
            {
                Good = "Yes",
                kid = new Kid()
                {
                    First = "1",
                    Seconed = 2
                }
            };

            string json = JsonConvert.SerializeObject(model, Formatting.None);
            Assert.Equal(@"{""kid"":{""Level0"":{""First"":""1"",""Seconed"":2}},""Good"":""Yes""}", json);
        }

        [Fact]
        public void ListConvertTest()
        {
            string Json1 = "{\"NeweggAPIResponse\":{\"IsSuccess\":\"true\",\"OperationType\":\"EditRMAResponse\",\"SellerID\":\"A2EU\",\"ResponseBody\":{\"RMAInfo\":{\"RMANumber\":\"21821229\",\"RMAType\":\"2\",\"RMATypeDescription\":\"Refund\",\"SourceSONumber\":\"299232884\",\"RMANote\":\"edit refund rma to 201601211001\",\"RMATransactionList\":{\"RMATransaction\":{\"SellerPartNumber\":\"Test_SP#A2EU_20181108_0003\",\"ReturnQuantity\":\"1\",\"ReturnUnitPrice\":\"0.02\",\"RefundShippingPrice\":\"0\",\"RMAReason\":\"2\",\"RMAReasonDescription\":\"Defective\"}}}},\"ResponseDate\":\"03/14/2019 18:06:42\"}}";
            string Json2 = "{\"NeweggAPIResponse\":{\"IsSuccess\":\"true\",\"OperationType\":\"EditRMAResponse\",\"SellerID\":\"A2EU\",\"ResponseBody\":{\"RMAInfo\":{\"RMANumber\":\"21821229\",\"RMAType\":\"2\",\"RMATypeDescription\":\"Refund\",\"SourceSONumber\":\"299232884\",\"RMANote\":\"edit refund rma to 201601211001\",\"RMATransactionList\":{\"RMATransaction\":[{\"SellerPartNumber\":\"Test_SP#A2EU_20181108_0003\",\"ReturnQuantity\":\"1\",\"ReturnUnitPrice\":\"0.02\",\"RefundShippingPrice\":\"0\",\"RMAReason\":\"2\",\"RMAReasonDescription\":\"Defective\"},{\"SellerPartNumber\":\"Test_SP#A2EU_20181108_0004\",\"ReturnQuantity\":\"1\",\"ReturnUnitPrice\":\"0.02\",\"RefundShippingPrice\":\"0\",\"RMAReason\":\"2\",\"RMAReasonDescription\":\"Defective\"}]}}},\"ResponseDate\":\"02/25/2019 23:52:57\"}}";
            var serializer = SerializerFactory.GetSerializer(SDK.Base.APIFormat.JSON);
            var result1  = serializer.Deserialize<EditRMAResponse>(Json1);
            var result2 = serializer.Deserialize<EditRMAResponse>(Json2);
            Assert.IsType<EditRMAResponse>(result1);
            Assert.IsType<EditRMAResponse>(result2);
        }

    }

    public class Kid
    {
        public string First { get; set; }
        public int Seconed { get; set; }
    }

    public class Parent
    {
        [JsonConverter(typeof(JsonMoreLevelSeConverter), "Level0")]
        public Kid kid { get; set; }
        public string Good { get; set; }
    }


}

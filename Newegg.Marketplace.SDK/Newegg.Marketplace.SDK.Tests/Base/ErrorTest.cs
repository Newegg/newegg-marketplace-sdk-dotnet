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

using Newegg.Marketplace.SDK.Seller;
using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Seller.Model;
using Newegg.Marketplace.SDK.Base.Http.Exception;

namespace Newegg.Marketplace.SDK.Tests.Base
{

    public class ErrorTest
    {
        private readonly APIConfig config;
        private readonly APIClient client;
        public ErrorTest()
        {
            config = APIConfig.FromJsonFile("configUSA_Error.json");
            client = new APIClient(config);


        }

        [Fact]
        public async System.Threading.Tasks.Task GetSellerStatusErrorAsync()
        {
            SellerCall call = new SellerCall(client);
            NoRetriesLeftException ex = await Assert.ThrowsAsync<NoRetriesLeftException>(
                () => call.SellerStatusCheck()
                );
            Assert.IsType<AuthenticationException>(ex.InnerException);

        }
    }
}

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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base.Exception;
using Newegg.Marketplace.SDK.Base.Http;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Base
{
    public class BaseCall
    {
        protected APIConfig config;
        protected Handler client;
        private readonly BaseAPIClient apiClient;
        protected ExceptionFactory exceptionFactory = new ExceptionFactory();

        public object ApiException { get; private set; }

        public BaseCall(BaseAPIClient apiClient)
        {
            this.apiClient = apiClient;
            client = apiClient.GetHttpHandler();
            config = apiClient.GetEndpointConfig();
        }

        protected Request CreateRequest()
        {
            Request request = new Request(config);
            request.QueryParams.Add("sellerID", config.SellerID);
            return request;
        }

        protected Request CreateRequest(APIFormat apiFormat)
        {
            Request request = new Request(config, apiFormat);
            request.QueryParams.Add("sellerID", config.SellerID);
            return request;
        }

        protected Request CreateRequest<RType>(RType reqMode, string version = null, APIFormat? apiFormat = null)
        {
            Request request = new Request(config, apiFormat);
            request.QueryParams.Add("sellerID", config.SellerID);
            request.SetContent<RType>(reqMode);
            return request;
        }

        public async Task<MType> ProcessResponse<MType>(IResponse response)
        {
            if (!response.IsSuccessful)
            {
                var rawErrors = await response.GetRawContent();
                System.Exception ex;
                try
                {
                    ex = exceptionFactory.CreateApiException(response.GetAPIFormat(), rawErrors, response);
                }
                catch (System.Exception e)
                {
                    var innerEx = new System.Exception("Error response is " + rawErrors, e);
                    throw new Base.Exception.InvalidValueException("Unexspect ", innerEx);
                }

                throw ex;
            }
            string content = await response.GetRawContent();
            var serializer = SerializerFactory.GetSerializer(response.GetAPIFormat());
            return serializer.Deserialize<MType>(content);
        }
    }
}

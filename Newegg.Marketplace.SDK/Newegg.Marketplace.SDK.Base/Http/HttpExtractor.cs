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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base.Http.Exception;
using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Base.Http
{
    public class HttpExtractor : BaseExtractor
    {
        private HttpClient client = new HttpClient();

        public HttpExtractor(APIConfig config) : base(config)
        {
            client.Timeout = TimeSpan.FromMilliseconds(config.Connection.RequestTimeoutMs);
        }

        override public async Task<IResponse> ExecuteAsync(IRequest request, ConnectSetting connectSetting = null)
        {

            if (request.URI == "")
            {
                throw new Base.Exception.InvalidValueException("Empty URI.");
            }

            try
            {
                request.GetReady();
                HttpResponseMessage result = await client.SendAsync(await CloneRequestMessageAsync(request.HttpRequest).ConfigureAwait(false)).ConfigureAwait(false);
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    ExceptionInfo info = await GetInfromationFromResponseAsync(result, request.GetAPIFormat());
                    switch (result.StatusCode)
                    {
                        case HttpStatusCode.ServiceUnavailable:
                            throw new GatewayException("Can not connect to Server.");
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.Unauthorized:
                            throw new AuthenticationException("Authentication Failed.");
                        case (HttpStatusCode)429:
                            throw new ThrottleException("Too many requests in the time period.");
                    }
                }
                return new Response(result, request.GetAPIFormat());
            }
            catch (SocketException ex)
            {                
                throw new ConnectionException("Network error while connecting to the API.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new ConnectionException("The connection is interrupted.", ex);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private static bool IsNetworkError(System.Exception ex)
        {
            if (ex is SocketException)
                return true;
            if (ex.InnerException != null)
                return IsNetworkError(ex.InnerException);
            return false;
        }

        private async Task<ExceptionInfo> GetInfromationFromResponseAsync(HttpResponseMessage response, APIFormat format)
        {
            ExceptionInfo ret = new ExceptionInfo(format);
            ret.RawContent = await response.Content.ReadAsStringAsync();            
            return ret;
        }

        private async Task<HttpRequestMessage> CloneRequestMessageAsync(HttpRequestMessage request)
        {
            var clone = new HttpRequestMessage(request.Method, request.RequestUri)
            {
                Content = await CloneHttpContentAsync(request.Content).ConfigureAwait(false),
                Version = request.Version
            };
            foreach (KeyValuePair<string, object> prop in request.Properties)
            {
                clone.Properties.Add(prop);
            }
            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        private async static Task<HttpContent> CloneHttpContentAsync(HttpContent content)
        {
            if (content == null) return null;

            var ms = new MemoryStream();
            await content.CopyToAsync(ms).ConfigureAwait(false);
            ms.Position = 0;

            HttpContent clone = new StreamContent(ms);
            foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
            {
                clone.Headers.Add(header.Key, header.Value);
            }
            return clone;
        }
    }
}

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
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NLog;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Base.Http
{
    public class HttpLogger : DelegatingHandler
    {
        private Logger log;
        public HttpLogger(HttpMessageHandler innerHandler) : base(innerHandler)
        {
            log = LoggerFactory.GetLogger();
        }

        private async Task<string> GenerateRequestMessage(HttpRequestMessage request)
        {
            var sBuilder = new StringBuilder();
            var sWriter = new StringWriter(sBuilder);

            sWriter.WriteLine("Request:");
            sWriter.WriteLine(request.ToString());
            if (request.Content != null)
            {
                sWriter.WriteLine(await request.Content.ReadAsStringAsync());
            }
            sWriter.WriteLine();
            return sBuilder.ToString();
        }

        private async Task<string> GenerateResponseLog(HttpResponseMessage response)
        {
            var sBuilder = new StringBuilder();
            var sWriter = new StringWriter(sBuilder);

            sWriter.WriteLine("Response:");
            sWriter.WriteLine(response.ToString());
            if (response.Content != null)
            {
                sWriter.WriteLine(await response.Content.ReadAsStringAsync());
            }
            sWriter.WriteLine();
            return sBuilder.ToString();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (LoggerFactory.IsLevelEnabled(LogLevel.Debug))
            {
                var debugMessage = await GenerateRequestMessage(request);
                log.Debug(debugMessage);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (LoggerFactory.IsLevelEnabled(LogLevel.Debug))
            {
                var debugMessage = await GenerateResponseLog(response);
                log.Debug(debugMessage);
            }

            return response;
        }
    }
}


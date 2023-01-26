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

namespace Newegg.Marketplace.SDK.Base.Http.Retry
{
    public class FixedCountPolicy : BasePolicy
    {
        public const int DEFAULT_DELAY = 5000;
        public const int DEFAULT_RETRY_COUNT = 3;

        public int RetryCount { get; private set; } = DEFAULT_RETRY_COUNT;
        public int DelayMs;

        public FixedCountPolicy(int attempts, int delayMs = DEFAULT_DELAY)
        {
            if (attempts < 1)
            {
                throw new Base.Exception.InitException("Retry count must more than 0.");
            }
            RetryCount = attempts;
            DelayMs = delayMs < 0 ? DEFAULT_DELAY : delayMs;
        }

        public override async Task<IResponse> GetResponse(Http.IExtractor extractor, IRequest request)
        {
            for (var i = 0; i < RetryCount; i++)
            {                              
                if (await ExecuteOnce(extractor, request).ConfigureAwait(false))
                    return response;

                if (DelayMs > 0)
                    await Task.Delay(DelayMs);
            }
            throw Http.Exception.NoRetriesLeftException.Factory(RetryCount, latestException);
        }
    }
}

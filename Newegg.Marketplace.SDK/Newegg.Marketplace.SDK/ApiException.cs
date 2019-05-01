
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

using Newegg.Marketplace.SDK.Base;
using Newegg.Marketplace.SDK.Base.Exception;
using Newegg.Marketplace.SDK.Base.Http;


namespace Newegg.Marketplace.SDK
{
    public class ApiException:BaseException
    {
        public IErrors Details { get; private set; }
        public IResponse Response { get; private set; }

        protected ApiException(string message) : base(message)
        { }

        public static ApiException Factory(IErrors errorDetails, IResponse errorResponse)
        {
            var httpResponse = errorResponse.RawResponse;
            var exceptionMessage = string.Format("API Error Occured [{0} {1}]", ((int)httpResponse.StatusCode).ToString(), httpResponse.ReasonPhrase);
            exceptionMessage += errorDetails.Render();
            var exception = new ApiException(exceptionMessage)
            {
                Details = errorDetails,
                Response = errorResponse
            };

            return exception;
        }
    }
}

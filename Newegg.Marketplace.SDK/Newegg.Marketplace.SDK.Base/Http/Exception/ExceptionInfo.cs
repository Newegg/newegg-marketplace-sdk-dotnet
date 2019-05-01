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
using System.Net;

using Newegg.Marketplace.SDK.Base.Exception;
using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Base.Http.Exception
{
    /// <summary>
    /// Information collect from Error response
    /// </summary>
    internal class ExceptionInfo
    {
        public ExceptionInfo(APIFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// HTTP Response Code
        /// </summary>
        public HttpStatusCode Code { get; set; }

        private string _RawContent;

        /// <summary>
        /// Raw content from Response
        /// </summary>
        public string RawContent
        {
            get
            {
                return _RawContent;
            }
            set {
                _RawContent = value;
                try
                {                    
                    this._errors = SerializerFactory.GetSerializer(Format).Deserialize<Errors>(_RawContent);
                }
                catch 
                {

                }
            }
        }

        private Errors _errors = null;

        public Errors Errors
        {
            get
            {
                return _errors;
            }
        }
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public APIFormat Format { get; set; }
    }
}

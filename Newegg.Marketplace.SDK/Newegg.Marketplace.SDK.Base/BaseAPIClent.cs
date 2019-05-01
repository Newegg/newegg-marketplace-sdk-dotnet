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
using System.Text;
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base.Http;
using Newegg.Marketplace.SDK.Base.Http.Retry;


namespace Newegg.Marketplace.SDK.Base
{
    public abstract class BaseAPIClient 
    {

        protected Handler httpHandler;

        public Handler GetHttpHandler() => httpHandler;
        private APIConfig config;
        public APIConfig GetEndpointConfig() => config;

        public BaseAPIClient(APIConfig cfg)
        {
            config = cfg;
            httpHandler = new Http.Handler(cfg);
        }

        public bool SimulationEnabled
        {
            get { return httpHandler.SimulationEnabled; }
            set { httpHandler.SimulationEnabled = value; }
        }

        private string _MockPath = Directory.GetCurrentDirectory();
        public string MockPath
        {
            get { return this._MockPath; }
            set { this._MockPath = value; }
        }

        public IRetryPolicy RetryPolicy
        {
            get { return httpHandler.RetryPolicy; }
            set { httpHandler.RetryPolicy = value; }
        }
       
    }
}

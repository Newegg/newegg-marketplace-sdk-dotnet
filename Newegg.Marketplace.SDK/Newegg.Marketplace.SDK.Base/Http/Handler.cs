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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Newegg.Marketplace.SDK.Base.Http
{
    public class Handler
    {
        public static ExtractorFactory extractorFactory = new Http.ExtractorFactory();

        private readonly APIConfig config;
        private IExtractor _extractor;

        public IExtractor Extractor
        {
            get
            {
                if (_extractor == null)
                    _extractor = extractorFactory.CreateExtractor(SimulationEnabled, config);
                return _extractor;
            }
        }

        public Retry.IRetryPolicy RetryPolicy { get; set; }
        private bool simulationEnabled = false;

        public bool SimulationEnabled
        {
            get { return simulationEnabled; }
            set
            {
                if (simulationEnabled == value) return;
                simulationEnabled = value;
                _extractor = extractorFactory.CreateExtractor(simulationEnabled, config);
            }
        }

        public Handler(APIConfig apiConfig)
        {
            config = apiConfig;
            RetryPolicy = new Retry.FixedCountPolicy(config.Connection.AttemptsTimes, config.Connection.RetryIntervalMs);
        }

        private Task<IResponse> ExecuteAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            if (connectSetting == null)
                return RetryPolicy.GetResponse(Extractor, request);
            else {
                var copyConfig = config.Clone();
                copyConfig.Connection = connectSetting;
                return new Retry.FixedCountPolicy(connectSetting.AttemptsTimes, connectSetting.RetryIntervalMs)
                    .GetResponse(extractorFactory.CreateExtractor(SimulationEnabled, copyConfig), request); 
            }
        }

        public Task<IResponse> GetAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            request.Method = HttpMethod.Get;
            return ExecuteAsync(request, connectSetting);
        }

        public Task<IResponse> PostAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            request.Method = HttpMethod.Post;
            return ExecuteAsync(request, connectSetting);
        }

        public Task<IResponse> PutAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            request.Method = HttpMethod.Put;
            return ExecuteAsync(request, connectSetting);
        }

        public Task<IResponse> DeleteAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            request.Method = HttpMethod.Delete;
            return ExecuteAsync(request, connectSetting);
        }
    }
}

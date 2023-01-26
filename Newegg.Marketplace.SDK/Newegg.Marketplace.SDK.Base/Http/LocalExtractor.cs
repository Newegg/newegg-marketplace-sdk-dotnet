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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

using Newegg.Marketplace.SDK.Base.Util;


namespace Newegg.Marketplace.SDK.Base.Http
{
    // The Extractor get local file to resposne the request.
    public class LocalExtractor : BaseExtractor
    {
        const string mappingFilename = "settings.json";

        private static readonly Logger log = LoggerFactory.GetLogger();
        private Dictionary<string, string> mapping;
        private string customFolder = "";

        public LocalExtractor(APIConfig config) : base(config)
        {
            this.customFolder = config.MockPath;
            mapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(LoadFile(mappingFilename));
        }

        public void SetCustomMockFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                var exceptionMessage = string.Format("Can't find the folder {0} for fade request files.", folderPath);
                log.Error(exceptionMessage);
                throw new Base.Exception.InitException(exceptionMessage);
            }

            Dictionary<string, string> newMapping;
            try
            {
                var content = File.ReadAllText(folderPath + mappingFilename);
                newMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

            }
            catch (System.Exception ex)
            {
                var exceptionMessage = string.Format("Can't read setting from the folder '{0}'.", customFolder);
                log.Error(exceptionMessage);
                throw new Base.Exception.InitException(exceptionMessage, ex);
            }
            mapping = newMapping;
            customFolder = folderPath;
        }

        private string LoadFile(string filename)
        {
            if (customFolder == "")
                return File.ReadAllText(filename);
            else
                return File.ReadAllText(customFolder + filename);

        }

        private Response BuildResponseObject(string content, System.Net.HttpStatusCode code, APIFormat apiFormat)
        {
            var httpResponse = new HttpResponseMessage()
            {
                Content = new StringContent(content),
                StatusCode = code
            };
            return new Response(httpResponse, apiFormat);
        }

        override public Task<IResponse> ExecuteAsync(IRequest request, ConnectSetting connectSetting = null)
        {
            var requestModel = (Request)request;

            var fullKey = request.Method.Method + " " + requestModel.Config.Platform + " " + request.URI + request.QueryString;
            var partKey= request.Method.Method + " " + requestModel.Config.Platform + " " + request.URI;
            var matches = mapping.Where(d => fullKey == d.Key).ToList();
            if (matches.Count == 0)
                matches = mapping.Where(d => partKey == d.Key).ToList();
            if (matches.Count == 0)
                matches = mapping.Where(d => fullKey.StartsWith(d.Key)).OrderBy(d => d.Key.Length).ToList();
            if (matches.Count == 0)
                throw new Exception.GatewayException("Unable to find fade file for the request.");

            string content = LoadFile(matches[0].Value + "." + request.GetAPIFormat().ToString().ToLower());

            var response = BuildResponseObject(content, (System.Net.HttpStatusCode)200, request.GetAPIFormat());
            return Task.FromResult<IResponse>(response);
        }
    }
}

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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Base.Http
{
    public class Request : IRequest
    {
        private APIFormat _APIFormat;
        private APIConfig config;
        public APIConfig Config { get { return config; } }
        public string URI { get; set; }
        public HttpRequestMessage HttpRequest { get; }
        public Dictionary<string, string> QueryParams { get; set; } = new Dictionary<string, string>();

        public HttpMethod Method
        {
            get { return HttpRequest.Method; }
            set { HttpRequest.Method = value; }
        }

        public Request(APIConfig cfg, APIFormat? apiFormat = null)
        {
            config = cfg;
            if (apiFormat.HasValue)
            {
                _APIFormat = apiFormat.Value;
            }
            else
            {
                _APIFormat = cfg.APIFormat;
            }
            HttpRequest = new HttpRequestMessage();
        }

        public APIFormat GetAPIFormat()
        {
            return _APIFormat;
        }

        public void AddMultipartContent(byte[] content)
        {
            var multipartContent = new MultipartFormDataContent
            {
                new ByteArrayContent(content)
            };
            HttpRequest.Content = multipartContent;
        }

        public void SetStringContent(string content)
        {
            HttpRequest.Content = new StringContent(content);
            HttpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(GetContentType());
        }

        public void SetContent<RType>(RType reqMode)
        {
            if (reqMode != null)
            {
                HttpRequest.Content = new StringContent(SerializerFactory.GetSerializer(_APIFormat).Serialize<RType>(reqMode));
                HttpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(GetContentType());
            }
        }

        public void AddMultipartContent(System.IO.Stream contentStream)
        {
            var multipartContent = new MultipartFormDataContent
            {
                new StreamContent(contentStream)
            };
            HttpRequest.Content = multipartContent;
        }      

        public string QueryString
        {
            get
            {
                var list = new List<string>();
                foreach (var param in this.QueryParams)
                {
                    if (param.Value != null)
                    {
                        list.Add(param.Key + "=" + param.Value);
                    }
                }
                if (list.Count > 0)
                {
                    return "?" + string.Join("&", list);
                }
                return "";
            }
        }
        

        public void GetReady()
        {
            HttpRequest.RequestUri = new Uri(config.BaseUrl + URI + QueryString);            
            HttpRequest.Headers.Clear();
            HttpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(GetContentType()));
            HttpRequest.Headers.Authorization = new AuthenticationHeaderValue(config.Credentials.Authorization);
            HttpRequest.Headers.Add("SecretKey", config.Credentials.SecretKey);
            HttpRequest.Headers.Add("APIVersion", ".NetCore 1.0");
        }

       
        public string GetContentType()
        {
            switch (_APIFormat)
            {
                case APIFormat.JSON:
                    return "application/json";
                default:
                case APIFormat.XML:
                    return "application/xml";
            }
        }


    }
}

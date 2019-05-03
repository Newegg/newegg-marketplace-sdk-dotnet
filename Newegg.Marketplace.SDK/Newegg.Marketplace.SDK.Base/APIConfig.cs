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
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

using Newegg.Marketplace.SDK.Base.Util;

namespace Newegg.Marketplace.SDK.Base
{

    /// <summary>
    /// Main configuration class, holds all global settings for SDK 
    /// </summary>
    public class APIConfig
    {
        /// <summary>
        /// The Credentials to call API
        /// </summary>
        public Credentials Credentials { get; private set; }

        /// <summary>        
        /// The platfrom of seller: There are three options:
        ///USA: seller on www.newegg.com
        ///B2B: seller on www.neweggbussiness.com
        ///CAN: seller on www.newegg.ca Optional, Default: USA.
        /// </summary>
        public APIPlatform Platform { get; set; } = APIPlatform.USA;

        private string baseUrl = "https://apis.newegg.com/marketplace/";

        /// <summary>
        /// The base url of the Newegg marketplace API. Optional, Default: https://apis.newegg.com/marketplace/
        /// </summary>
        public string BaseUrl
        {
            get
            {
                return baseUrl + (Platform == APIPlatform.USA ? "" : Platform.ToString() + "/");
            }
            set
            {
                baseUrl = value;
            }
        }
        private LogLevel _logLevel = LogLevel.Info;

        /// <summary>
        /// The log level when call API, If log level above LogLevel.Debug, will log the request and response content.
        /// </summary>
        public LogLevel LogLevel
        {
            get
            {
                return _logLevel;
            }
            set
            {
                _logLevel = value;
                LoggerFactory.Level = _logLevel;
            }
        }

        /// <summary>
        /// Seller's ID usually is a 4-character string
        /// </summary>
        public string SellerID { get; set; }

        /// <summary>
        /// The Format to call API
        /// </summary>
        public APIFormat APIFormat { get; set; } = APIFormat.JSON;

        /// <summary>
        /// The mock file path, which is use for simulation
        /// </summary>
        public string MockPath { get; set; }

        /// <summary>
        /// Connectin Setting
        /// </summary>
        public ConnectSetting Connection { get; set; }

        /// <summary>
        /// Three nessary params to create the API config. Other property will use the default value.
        /// </summary>
        /// <param name="sellerid">Seller ID</param>
        /// <param name="authorization">The API Key</param>
        /// <param name="secretKey">The Secret Key</param>
        public APIConfig(string sellerid, string authorization, string secretKey)
        {
            this.SellerID = sellerid;
            this.Credentials = new Credentials(authorization, secretKey);
            this.Connection = new ConnectSetting()
            {
                RequestTimeoutMs = 3000,
                RetryIntervalMs = 1000,
                AttemptsTimes = 3
            };
        }

        /// <summary>
        /// Clone a config object
        /// </summary>
        /// <returns></returns>
        public APIConfig Clone()
        {
            APIConfig ret = this.MemberwiseClone() as APIConfig;
            ret.Credentials = new Credentials(this.Credentials.Authorization, this.Credentials.SecretKey);
            ret.Connection = new ConnectSetting()
            {
                AttemptsTimes = this.Connection.AttemptsTimes,
                RequestTimeoutMs = this.Connection.RequestTimeoutMs,
                RetryIntervalMs = this.Connection.RetryIntervalMs
            };
            return ret;
        }

        /// <summary>
        /// Generate from Json File
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <returns></returns>
        public static APIConfig FromJsonFile(string jsonFile)
        {
            if (File.Exists(jsonFile))
            {
                return FromJson(File.ReadAllText(jsonFile));
            }
            throw new FileNotFoundException("Can't find the file.");
        }

        /// <summary>
        /// Generate APIConfig from Json String
        /// </summary>
        /// <param name="jsonString">the json string</param>
        /// <returns></returns>
        public static APIConfig FromJson(string jsonString)
        {
            JToken json = Newtonsoft.Json.Linq.JToken.Parse(jsonString);
            JObject o = json.Value<JObject>();
            dynamic d = json as dynamic;
            string sellerID = d.SellerID, authorization = d.Credentials.Authorization, secretKey = d.Credentials.SecretKey;
            if (string.IsNullOrEmpty(sellerID) || string.IsNullOrEmpty(authorization) || string.IsNullOrEmpty(secretKey))
            {
                throw new FormatException("SellerID, Authorization and SecretKey Setting file is required.");
            }
            APIConfig ret = new APIConfig(sellerID, authorization, secretKey);

            foreach (var p in o.Properties())
            {
                if (p.Name == "Credentials" || p.Name == "SellerID") continue;
                if (p.Name == "Connection")
                {
                    JObject c = p.Value.Value<JObject>();
                    if (c.Property("RequestTimeoutMs") != null)
                        ret.Connection.RequestTimeoutMs = (int)c.Property("RequestTimeoutMs").Value;
                    if (c.Property("AttemptsTimes") != null)
                        ret.Connection.AttemptsTimes = (int)c.Property("AttemptsTimes").Value;
                    if (c.Property("RetryIntervalMs") != null)
                        ret.Connection.RetryIntervalMs = (int)c.Property("RetryIntervalMs").Value;
                    continue;
                }
                if (p.Name == "LogLevel")
                {
                    ret.LogLevel = LogLevel.FromString(p.Value.ToString());
                    continue;
                }

                PropertyInfo pro = ret.GetType().GetProperty(p.Name);
                if (pro != null)
                {
                    try
                    {
                        pro.SetValue(ret, p.Value.ToObject(pro.PropertyType));
                    }
                    catch { }
                }
            }


            return ret;
        }
    }

    /// <summary>
    /// API Format
    /// </summary>
    public enum APIFormat
    {
        XML,
        JSON,
    }

    /// <summary>
    /// The platfrom of seller: There are three options:
    /// USA: seller on www.newegg.com
    /// B2B: seller on www.neweggbussiness.com
    /// CAN: seller on www.newegg.ca Optional, Default: USA.
    /// </summary>
    public enum APIPlatform
    {
        USA,
        B2B,
        CAN
    }

    /// <summary>
    ///  Merchant Credentials
    /// </summary>
    public class Credentials
    {
        public string Authorization { get; private set; }
        public string SecretKey { get; private set; }

        public Credentials(string authorization, string secretKey)
        {
            Authorization = authorization;
            SecretKey = secretKey;
        }
    }

    /// <summary>
    /// Setting of Connection
    /// </summary>
    public class ConnectSetting
    {
        public int RequestTimeoutMs { get; set; } = 5000;
        public int AttemptsTimes { get; set; } = 5;
        public int RetryIntervalMs { get; set; } = 1000;
    }
}

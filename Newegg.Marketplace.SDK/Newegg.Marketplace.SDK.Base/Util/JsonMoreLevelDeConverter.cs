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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Newegg.Marketplace.SDK.Base.Util
{
    public class JsonMoreLevelDeConverter : JsonConverter
    {
        private string _levelName;
        public JsonMoreLevelDeConverter(string levelName)
        {
            _levelName = levelName;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JTokenReader tokenreader = new JTokenReader(JToken.ReadFrom(reader));
            tokenreader.Read();
            var token = tokenreader.CurrentToken.SelectToken("$." + _levelName);
            if (token != null)
            {
                string kidJson = token.ToString().Trim();
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(objectType))
                {
                    if (!kidJson.StartsWith("["))
                    {
                        var kidtype = objectType.GetGenericArguments()[0];
                        //var ret = Convert.ChangeType(Activator.CreateInstance(objectType), typeof(IEnumerable<>).MakeGenericType(kidtype));
                        var ret = Activator.CreateInstance(objectType);
                        objectType.GetMethod("Add").Invoke(ret, new object[] { JsonConvert.DeserializeObject(kidJson, kidtype) });
                        return ret;
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject(kidJson, objectType);
                    }
                }
                else
                {
                    return JsonConvert.DeserializeObject(kidJson, objectType);
                }
            }
            else
            {
                var obj = Activator.CreateInstance(objectType);
                var properties = tokenreader.CurrentToken.Value<JObject>().Properties();
                foreach (var p in properties)
                {
                    PropertyInfo pro = objectType.GetProperty(p.Name);
                    if (pro != null)
                    {
                        try
                        {
                            pro.SetValue(obj, p.Value.ToObject(pro.PropertyType, serializer));
                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                return obj;
            }

        }
    }
}

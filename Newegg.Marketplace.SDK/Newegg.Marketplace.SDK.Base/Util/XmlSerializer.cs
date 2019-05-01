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
using System.Xml;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Base.Util
{
    public class XmlSerializer : ISerializer
    {
        public sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        /// <summary>
        /// Converts to object and returns
        /// </summary>
        /// <typeparam name="MType">Deserialize type</typeparam>
        /// <param name="content">Xml string</param>
        /// <returns>Object</returns>
        public MType Deserialize<MType>(string content)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MType));
            using (var reader = new StringReader(content))
            {
                return (MType)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Converts to xml string and returns
        /// </summary>
        /// <returns>Xml string</returns>
        public string Serialize<MType>(MType item)
        {
            return Serialize<MType>(item, false, false);
        }
        /// <summary>
        /// Converts to xml string and returns
        /// </summary>
        /// <typeparam name="MType">Serialize type</typeparam>
        /// <param name="item">To serialize object</param>
        /// <param name="IsNoXmlNameSpace">Serialized string contains xmlnameSpace or not</param>
        /// <param name="IsRemoveEncodingLine">Serialized string contains xml encoding line or not</param>
        /// <returns>Xml string</returns>
        public string Serialize<MType>(MType item, bool IsNoXmlNameSpace = false, bool IsRemoveEncodingLine = false)
        {
            using (Utf8StringWriter stringWriter = new Utf8StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                if (IsRemoveEncodingLine)
                    // Remove the <?xml version="1.0" encoding="utf-8"?>
                    settings.OmitXmlDeclaration = true;

                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MType));
                    if (IsNoXmlNameSpace)
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        serializer.Serialize(xmlWriter, item, ns);
                    }
                    else
                        serializer.Serialize(xmlWriter, item);
                    return stringWriter.ToString();
                }
            }
        }
    }
}

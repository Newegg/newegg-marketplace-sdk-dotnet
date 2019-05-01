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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Base.Util
{
    public class XmlSerializableHashtable : Hashtable, IXmlSerializable
    {
        public XmlSerializableHashtable() { }
        public XmlSerializableHashtable(Dictionary<object, object> dic) : base(dic) { }

        public XmlSchema GetSchema()
        {
            return null;
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (object key in this.Keys)
            {
                object value = this[key];
                if (value is XmlSerializableHashtable)
                {
                    writer.WriteStartElement(key.ToString());
                    WriteXml(writer, (XmlSerializableHashtable)value);
                    writer.WriteEndElement();
                }
                else
                    writer.WriteElementString(key.ToString(), value.ToString());
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer, XmlSerializableHashtable serializableHashtable)
        {
            foreach (var key in serializableHashtable.Keys)
            {
                object value = serializableHashtable[key];
                if (value is XmlSerializableHashtable)
                    WriteXml(writer, (XmlSerializableHashtable)value);
                else
                    writer.WriteElementString(key.ToString(), value.ToString());
            }
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            // Start to use the reader.
            reader.Read();
            // Read the first element i.e. root of this object
            reader.ReadStartElement("dictionary");

            // Read all elements
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                // parsing the item
                reader.ReadStartElement("item");

                // Parsing the key and value 
                string key = reader.ReadElementString("key");
                string value = reader.ReadElementString("value");

                // end reading the item.
                reader.ReadEndElement();
                reader.MoveToContent();

                // add the item
                this.Add(key, value);
            }

            // Extremely important to read the node to its end.
            // next call of the reader methods will crash if not called.
            reader.ReadEndElement();
        }
    }
}


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
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Newegg.Marketplace.SDK.Report.Model.SubmitReportRequest
{
    [DataContract]
    public class StatusResponseBody
    {
        public StatusResponseBody()
        {
            ResponseList = new List<ResponseInfo>();
        }

        [DataMember]
        public List<ResponseInfo> ResponseList { set; get; }
    }

    [DataContract]
    public class ResponseInfo
    {
        [DataMember]

        public string RequestId { get; set; }

        [DataMember]

        public string RequestType { set; get; }


        [XmlIgnore]
        public DateTime RequestDate { set; get; }

        [DataMember(Name = "RequestDate")]
        [XmlElement(ElementName = "RequestDate")]
        public string RequestDateStr
        {
            get { return RequestDate.ToString("MM\\/dd\\/yyyy HH:mm:ss"); }
            set { }
        }

        [DataMember]

        public string RequestStatus { set; get; }

        [DataMember]

        public string Memo { set; get; }


        [DataMember]

        public string Error { get; set; }

       

    }

}

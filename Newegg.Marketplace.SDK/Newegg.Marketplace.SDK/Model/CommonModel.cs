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


namespace Newegg.Marketplace.SDK.Model
{
    public class CommondPageInfo
    {
        public CommondPageInfo()
        {
            PageIndex = 1;
            PageSize = 100;
        }
        public CommondPageInfo(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int? TotalCount { get; set; }
        public bool ShouldSerializeTotalCount()
        {
            return TotalCount.HasValue;
        }

        public int? TotalPageCount { get; set; }
        public bool ShouldSerializeTotalPageCount()
        {
            return TotalPageCount.HasValue;
        }

        public int? PageIndex { get; set; }
        public bool ShouldSerializePageIndex()
        {
            return PageIndex.HasValue;
        }

        public int? PageSize { get; set; }
        public bool ShouldSerializePageSize()
        {
            return PageSize.HasValue;
        }
    }

    public class CommonHeader
    {
        public string DocumentVersion { get; set; }
    }

    public class RequestVersion
    {
        public static readonly string SBN = "304";
        public static readonly string ISO = "305";
        public static readonly string CrazyEgg = "306";
        public static readonly string NeweggShippingLabel = "307";
        /// <summary>
        /// Only for 3PL Seller
        /// </summary>
        public static readonly string For3PLOnly = "308";
        public static readonly string ReplacementOrder = "309";
    }
}

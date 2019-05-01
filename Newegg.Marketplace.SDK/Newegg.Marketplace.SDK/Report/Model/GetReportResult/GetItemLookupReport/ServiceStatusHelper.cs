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
using System.Threading.Tasks;

namespace Newegg.Marketplace.SDK.Report.Model
{
    public class ServiceStatusHelper
    {
        #region Condition转换相关类型
        private static List<Tuple<string, string, string>> _conditionsList = new List<Tuple<string, string, string>>()
        {
            //Item1=ClientCondition, Item2=Sever Condition, Item3= Server Condition Name
            new Tuple<string,string,string>("1","001","New"),
            new Tuple<string,string,string>("2","002","Refurbished"),
            new Tuple<string,string,string>("3","005","Used - Like New"),
            new Tuple<string,string,string>("4","006","Used - Very Good"),
            new Tuple<string,string,string>("5","007","Used - Good"),
            new Tuple<string,string,string>("6","008","Used - Acceptable")
        };
        /// <summary>
        /// 将服务端Condition枚举转换为客户端Condition枚举
        /// </summary>
        /// <param name="serverCondition">服务端Condition枚举</param>
        /// <returns></returns>
        public static string ConvertConditionToClient(string serverCondition)
        {
            var condition = _conditionsList.FirstOrDefault(e => e.Item2 == serverCondition);
            if (condition != null)
                return condition.Item1;
            return null;
        }
        #endregion
    }
}

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

namespace Newegg.Marketplace.SDK.Item.Model
{
    public class VolumeDiscountData
    {
        public string SellerPartNumber { get; set; }
        public string ItemNumber { get; set; }
        public int T1_Quantity { get; set; }
        public decimal T1_SellingPrice { get; set; }
        public int T1_ShippingType { get; set; }
        public int T2_Quantity { get; set; }
        public decimal T2_SellingPrice { get; set; }
        public int T2_ShippingType { get; set; }
        public int T3_Quantity { get; set; }
        public decimal T3_SellingPrice { get; set; }
        public int T3_ShippingType { get; set; }
        public int T4_Quantity { get; set; }
        public decimal T4_SellingPrice { get; set; }
        public int T4_ShippingType { get; set; }
        public int T5_Quantity { get; set; }
        public decimal T5_SellingPrice { get; set; }
        public int T5_ShippingType { get; set; }
        public decimal SellingPrice { get; set; }
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// VolumeDiscount是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExists()
        {
            return T1_Quantity > 0;
        }
    }
}

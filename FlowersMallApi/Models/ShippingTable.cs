using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 购物车
    /// </summary>
    public partial class ShippingTable
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int SUId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int SCId { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string SCName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal SPrice { get; set; }
        /// <summary>
        /// 展示图
        /// </summary>
        public string SPic { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int SNum { get; set; }
        /// <summary>
        /// 是否购买
        /// </summary>
        public bool SBuy { get; set; }
    }
}

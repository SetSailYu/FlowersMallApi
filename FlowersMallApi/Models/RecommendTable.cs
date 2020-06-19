using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 推荐表
    /// </summary>
    public partial class RecommendTable
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int CId { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 展示图
        /// </summary>
        public string CPic { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal CPrice { get; set; }
        /// <summary>
        /// 价格变动
        /// </summary>
        public decimal CPriceAlt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 商品表
    /// </summary>
    public partial class CommodityTable
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
        /// 系列,细分的用途
        /// </summary>
        public string CSeries { get; set; }
        /// <summary>
        /// 种类, 鲜花永生花,礼盒
        /// </summary>
        public string CKind { get; set; }
        /// <summary>
        /// 花语
        /// </summary>
        public string CFlowerLanguage { get; set; }
        /// <summary>
        /// 花材
        /// </summary>
        public string CFlowerMaterial { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string CIntroduce { get; set; }
        /// <summary>
        /// 展示图
        /// </summary>
        public string CPic { get; set; }
        /// <summary>
        /// 详细图
        /// </summary>
        public string CDetailedPic { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int CStock { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int CSale { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal CPrice { get; set; }
        /// <summary>
        /// 包装
        /// </summary>
        public string CPacking { get; set; }
    }
}

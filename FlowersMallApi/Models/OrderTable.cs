using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public partial class OrderTable
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int OUId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int OCId { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string OAPostcode { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string OAAddress { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string OAName { get; set; }
        /// <summary>
        /// 收货手机号
        /// </summary>
        public string OAIphone { get; set; }
        /// <summary>
        /// 留言
        /// </summary>
        public string OMessage { get; set; }
        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime ODate { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        public string ODelivery { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int OSNum { get; set; }
        /// <summary>
        /// 是否付款
        /// </summary>
        public bool OFlag { get; set; }
    }
}

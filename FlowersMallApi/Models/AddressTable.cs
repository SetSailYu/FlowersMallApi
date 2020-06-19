using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 地址表
    /// </summary>
    public partial class AddressTable
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int AId { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string AAddress { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string AName { get; set; }
        /// <summary>
        /// 收货手机号
        /// </summary>
        public string AIphone { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string APostcode { get; set; }
    }
}

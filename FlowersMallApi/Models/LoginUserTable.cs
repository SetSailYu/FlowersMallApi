using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 登录用户表
    /// </summary>
    public partial class LoginUserTable
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 用户身份
        /// </summary>
        public int URank { get; set; }
        /// <summary>
        /// token值（身份验证）
        /// </summary>
        public string UToken { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class UserTable
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UPassword { get; set; }
        /// <summary>
        /// 手机号码--个人中心安全性
        /// </summary>
        public string UIphone { get; set; }
        /// <summary>
        /// 邮箱--个人中心安全性
        /// </summary>
        public string UMail { get; set; }
        /// <summary>
        /// 身份证--货到付款使用
        /// </summary>
        public string UCard { get; set; }
    }
}

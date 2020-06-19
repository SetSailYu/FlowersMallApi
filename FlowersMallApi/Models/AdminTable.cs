using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 管理员表
    /// </summary>
    public partial class AdminTable
    {
        /// <summary>
        /// 管理员id
        /// </summary>
        public string AId { get; set; }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string APassword { get; set; }
    }
}

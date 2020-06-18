using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 用户身份枚举
    /// </summary>
    public enum Rank : int
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        User = 0,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 1
    }
}

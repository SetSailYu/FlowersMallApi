using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    public partial class LvmessageTable
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string UInformation { get; set; }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime UTime { get; set; }
        /// <summary>
        /// 优秀的
        /// </summary>
        public string USuler { get; set; }
    }
}

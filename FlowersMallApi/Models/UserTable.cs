using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class UserTable
    {
        public int UId { get; set; }
        public string UName { get; set; }
        public string UPassword { get; set; }
        public string UIphone { get; set; }
        public string UMail { get; set; }
        public string UCard { get; set; }
    }
}

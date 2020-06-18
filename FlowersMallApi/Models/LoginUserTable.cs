using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class LoginUserTable
    {
        public int UId { get; set; }
        public int URank { get; set; }
        public string UToken { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class ShippingTable
    {
        public int SUId { get; set; }
        public int SCId { get; set; }
        public string SCName { get; set; }
        public decimal SPrice { get; set; }
        public string SPic { get; set; }
        public int SNum { get; set; }
        public bool SBuy { get; set; }
    }
}

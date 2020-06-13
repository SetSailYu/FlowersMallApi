using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class RecommendTable
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CPic { get; set; }
        public decimal CPrice { get; set; }
        public decimal CPriceAlt { get; set; }
    }
}

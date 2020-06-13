using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class CommodityTable
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CSeries { get; set; }
        public string CKind { get; set; }
        public string CFlowerLanguage { get; set; }
        public string CFlowerMaterial { get; set; }
        public string CIntroduce { get; set; }
        public string CPic { get; set; }
        public string CDetailedPic { get; set; }
        public int CStock { get; set; }
        public int CSale { get; set; }
        public decimal CPrice { get; set; }
        public string CPacking { get; set; }
    }
}

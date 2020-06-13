using System;
using System.Collections.Generic;

namespace FlowersMallApi.Models
{
    public partial class OrderTable
    {
        public string OId { get; set; }
        public int OUId { get; set; }
        public int OCId { get; set; }
        public string OAPostcode { get; set; }
        public string OAAddress { get; set; }
        public string OAName { get; set; }
        public string OAIphone { get; set; }
        public string OMessage { get; set; }
        public DateTime ODate { get; set; }
        public string ODelivery { get; set; }
        public int OSNum { get; set; }
        public bool OFlag { get; set; }
    }
}

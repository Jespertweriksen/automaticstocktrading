using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class OrderPostDto
    {
        public int amount { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
}

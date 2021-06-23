using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class StockTypePriceDto
    {
        public string name { get; set; }
        public string price { get; set; }
        public string closeYesterday { get; set; }
        public string closeOneMonth { get; set; }
        public string closeOneYear { get; set; }
    }
}

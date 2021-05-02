using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class OrderDtoModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int stockID { get; set; }
        public int amount { get; set; }
        public DateTime dateTime { get; set; }
        public float price { get; set; }

        public string name { get; internal set; }
        public string stock_name { get; internal set; }
    }
}

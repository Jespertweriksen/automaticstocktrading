using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class StockPriceDto
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int stockID { get; set; }
        public int amount { get; set; }
        public DateTime dateTime { get; set; }
        public int buy_price { get; set; }
        
        
        // 
        public UserModel user { get; set; }
        public StockTypeModel stockType { get; set; }
        public string name { get; internal set; }
        public string stock_name { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class StockHistoriesModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int stockID { get; set; }
        public int portfolioID { get; set; }
    }
}

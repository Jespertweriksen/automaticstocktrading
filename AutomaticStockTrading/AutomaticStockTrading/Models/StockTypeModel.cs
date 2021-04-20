using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class StockTypeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string stock_name { get; set; }
        public List<StockDataModel> stockData { get; set; }
        public List<OrderModel> order { get; set; }
        public ForecastDataModel forecast { get; set; }
    }
}

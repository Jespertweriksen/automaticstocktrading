using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomaticStockTrading.DataContext;

namespace AutomaticStockTrading.Models
{
    public class StockTypeModel
    {
        public int id2 = 5;

        public int id { get; set; }
        public string name { get; set; }
        public string stock_name { get; set; }

        public List<StockDataModel> stockData { get; set; }
        public List<OrderModel> order { get; set; }
        public List<PortfolioModel> portfolio { get; set; }
        public List<ForecastDataModel> forecast { get; set; }

       

        public int myInt()
        {
            var x = 5;
            return x;
        }
    }
}
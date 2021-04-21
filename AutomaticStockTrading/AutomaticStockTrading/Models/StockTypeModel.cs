using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomaticStockTrading.DataContext;

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

        public List<StockTypeModel> getAllTypes()
        {
            using (var db = new Context())
            {
                var query = db.stocktype.Where(t => t.id == 1).ToList();
                return query;
            }
        }

        public int myInt()
        {
            var x = 5;
            return x;
        }
    }
}

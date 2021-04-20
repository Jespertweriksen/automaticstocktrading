using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    
    public class ForecastDataModel
    {
        public int id { get; set; }
        public float close { get; set; }
        public int stock_type_id { get; set; }
        public StockTypeModel stockType { get; set;}
    }
}

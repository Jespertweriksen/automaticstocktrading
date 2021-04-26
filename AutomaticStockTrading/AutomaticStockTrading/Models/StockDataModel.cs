using System.Collections.Generic;

namespace AutomaticStockTrading.Models
{
    [System.ComponentModel.DataAnnotations.Schema.ComplexType]
    public class StockDataModel
    {
        public int id { get; set; }
        public string datetime { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }

        
        public int stock_type_id { get; set; }
        public StockTypeModel stockType { get; set; }

    }
}

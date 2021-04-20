using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutomaticStockTrading.Models
{
    public class RootObject
    {
        [JsonProperty("Values")]
        public List<StockModel> Stocks { get; set; }
    }

    public class StockModel
    {
        public string currency { get; set; }
        public DateTime dateTime { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
    }

    
}

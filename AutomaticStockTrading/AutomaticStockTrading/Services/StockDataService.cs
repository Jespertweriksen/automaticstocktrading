using System;
using System.Collections.Generic;
using System.Linq;
using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;

namespace AutomaticStockTrading.Services
{

    public class StockDataService
    {
        

        private readonly Context context;
        public StockDataService(Context context)
        {
            this.context = context;
        }

        public int x()
        {
            return 5;
        }


        public List<string> GetAllTypes()

        {
            
            var query = (from t in context.stocktype select t.name).ToList();
            
            return query;
        }

        
    }
    
}


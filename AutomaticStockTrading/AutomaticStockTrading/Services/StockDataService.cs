using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;


namespace AutomaticStockTrading.Services
{

    public class StockDataService
    {

        private static readonly HttpClient client = new HttpClient();
        

        private readonly Context context;


        public StockDataService(Context context)
        {
            this.context = context;
        }

        public int x()
        {
            return 5;
        }


        public List<StockTypePriceDto> GetAllTypes()

        {
        
            var query = (from t in context.stocktype select new StockTypePriceDto() { 
                name = t.name
            }).ToList();

            foreach (StockTypePriceDto element in query)
            {
                var currentPrice = GetCurrentPrice(element.name);
                element.price = (currentPrice.price).ToString();             
            }

            
            
            return query;
        }

        
        public StockTypePriceDto GetCurrentPrice(string stockName)
        {
        
            var stockAlias = context.stocktype
                .Where(x => x.name == stockName)
                .Select(x => x.stock_name)
                .FirstOrDefault()
                .ToString();
            
            var response = Get($"https://api.twelvedata.com/price?symbol={stockAlias}&apikey=6a81f55d739d49c2a19610cd4a98e366").ToString();
            var stockObject = JsonSerializer.Deserialize<StockTypePriceDto>(response);
            stockObject.name = stockAlias;
            return stockObject;
        }


        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
    
}


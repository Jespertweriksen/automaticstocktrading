using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text.Json;
using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using TimeZoneConverter;

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

        // Get all types of stocks with their current price.
        public List<StockTypePriceDto> GetAllTypes()
        {
            var query = (from t in context.stocktype
                         select new StockTypePriceDto()
                         {
                             name = t.name
                         }).ToList();

            foreach (StockTypePriceDto element in query)
            {
                var currentPrice = GetCurrentPrice(element.name);
                var newestClose = GetAllClosePriceYesterday(element.name);
                // UDKOMMENTER NEDENSTÅENDE VED TEST
                element.price = (currentPrice.price).ToString();
                element.closeYesterday = (newestClose).ToString();
            }
            return query;
        }
        public string GetAllClosePriceYesterday(string stockName)
        {
            var query = (from data in context.stockdata
                         join stock in context.stocktype on data.stock_type_id equals stock.id
                         where stock.name == stockName
                         select data.close).ToList();

            var yesterDayClose = query[0];
            return yesterDayClose;
        }

        // Get yesterdays close price for at stock name


        // query twelvedata for current price of stock return stockDto object
        public StockTypePriceDto GetCurrentPrice(string stockName)
        {
             var stockAlias = context.stocktype
                .Where(x => x.name == stockName)
                .Select(x => x.stock_name)
                .FirstOrDefault()
                .ToString();

            var cache = MemoryCache.Default;
            TimeZoneInfo cet = TZConvert.GetTimeZoneInfo("W. Europe Standard Time");
            DateTimeOffset offset = TimeZoneInfo.ConvertTime(DateTime.Now, cet);

            if (!cache.Contains(stockName))
            {
                var expiration = offset.AddHours(1);
                var response = Get($"https://api.twelvedata.com/price?symbol={stockAlias}&apikey=6a81f55d739d49c2a19610cd4a98e366").ToString();
                var stockObject = JsonSerializer.Deserialize<StockTypePriceDto>(response);
                stockObject.name = stockAlias;
                cache.Add(stockName, stockObject, expiration);
            }
            return cache.Get(stockName, null) as StockTypePriceDto;
        }

        
        // Diverse function for fetching data
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


        // Denne funktion er til at fetche for en specific stock baseret på navn
        public IEnumerable<StockDataModel> GetSpecificTypeData(string stockName)
        {

            
            var query = (from data in context.stockdata
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select data).ToList().Where((data, i) => i % 100 == 0);

            
            return query;

        }

    }
    
}


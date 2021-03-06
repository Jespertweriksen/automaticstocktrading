using System;
using System.Collections.Generic;
using System.Globalization;
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
                var oneMonthClose = GetAllClosePriceOneMonth(element.name);
                var oneYearClose = GetAllClosePriceOneYear(element.name);
                // UDKOMMENTER NEDENSTÅENDE VED TEST
                element.price = (currentPrice.price).ToString();
                element.closeYesterday = (newestClose).ToString();
                element.closeOneMonth = oneMonthClose.ToString();
                element.closeOneYear = oneYearClose.ToString();
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
        
        public string GetAllClosePriceOneMonth(string stockName)
        {
            var query = (from data in context.stockdata
                join stock in context.stocktype on data.stock_type_id equals stock.id
                where stock.name == stockName
                select data.close).ToList();

            var yesterDayClose = query[30];
            return yesterDayClose;
        }
        
        public string GetAllClosePriceOneYear(string stockName)
        {
            var query = (from data in context.stockdata
                join stock in context.stocktype on data.stock_type_id equals stock.id
                where stock.name == stockName
                select data.close).ToList();

            var yesterDayClose = query[364];
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

        public List<ForecastDataModel> GetForeCastByStockName(string stockName)
        {
            var query = (from data in context.forecast_data
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select data).ToList();

            return query;
        }

        // Vi vil kun have den seneste close værdi
        public StockDataModel GetCloseByStockName(string stockName)
        {

            var query = (from data in context.stockdata
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select data).First();

            return query;
        }



        public decimal GetAvarageStockDataLastYear(string stockName, int yearsBack)
        {
            var lastYearData = new List<decimal>();

            var YearBack = GetLastYear(yearsBack);

            var query = (from data in context.stockdata
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select data).ToList();

            foreach (StockDataModel row in query)
            {
                if (row.datetime.Contains(YearBack))
                {
                    var containerFloat = decimal.Parse(row.close, CultureInfo.InvariantCulture);
                    var rand = Convert.ToInt32(containerFloat);
                    lastYearData.Add(containerFloat);
                }
            }

            var lenghtOfYearBack = lastYearData.Count();

            decimal count = 0;

            foreach (var row in lastYearData)
            {
                count += row;
            }

            count = (count / lenghtOfYearBack);

            return count;
        }


        public string GetLastYear(int yearsBack)
        {
            var lastYear = DateTime.Now.AddYears(-(yearsBack)).Year;


            return lastYear.ToString();
        }

        // Need to know the newest date af stock and its data has been logged
        public string GetLastDateOfStockData(string stockName)
        {
            var query = (from data in context.stockdata
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select data.datetime).First();
            return query;
        }

        public struct dataHolder
        {
            string date { get; set; }
            string close { get; set; }
        }

        public Array GetCloseAndDate(string stockName)
        {
            var query = (from data in context.stockdata
                         join t in context.stocktype on data.stock_type_id equals t.id
                         where t.name == stockName
                         select new { data.datetime, data.close }).ToArray();

            return query;

        }

        public int GetStockId(string stockName)
        {
            var query = (from data in context.stocktype
                         where data.name == stockName
                         select data.id).FirstOrDefault();

            return query;
        }

        public void AddOrder(int userId, int stockId, int amount, DateTime date, float currentPrice)
        {
            OrderModel post = new OrderModel();

            post.userID = userId;
            post.stockID = stockId;
            post.amount = amount;
            post.dateTime = date;
            post.price = currentPrice;

            context.Add(new OrderModel {userID = userId, dateTime= date, stockID=stockId, amount= amount, price= currentPrice });
            context.SaveChanges();
        }
       
    }
    
}


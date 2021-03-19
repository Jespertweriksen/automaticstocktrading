using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using AutomaticStockTrading.Models;
using TwelveDataSharp;
using TwelveDataSharp.Interfaces;
using TwelveDataSharp.Library.ResponseModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Runtime.Caching;

namespace AutomaticStockTrading.Services
{
    public class Tools
    {
        public static List<StockModel> JsonParseStocks(string jsonText)
        {
            return JsonConvert.DeserializeObject<RootObject>(jsonText).Stocks;
        }
        

        public static List<StockModel> Stocks(string stockAlias)
        {
            TimeZoneInfo cet = TimeZoneInfo.FindSystemTimeZoneById("Europe/Copenhagen");
            DateTimeOffset offset = TimeZoneInfo.ConvertTime(DateTime.Now, cet);

            Console.WriteLine(offset);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.twelvedata.com/time_series?symbol=" + stockAlias + "&interval=1day&type=stock&format=JSON&start_date=2001-01-01%2021:24:00&end_date=2021-03-19%2021:24:00&apikey=6a81f55d739d49c2a19610cd4a98e366");

            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JObject json = JObject.Parse(result);
                var list = JsonParseStocks(json.ToString());
                return list;
            }
        }
        public static List<StockModel> GetStocks(string stockAlias)
        {
            
            TimeZoneInfo cet = TimeZoneInfo.FindSystemTimeZoneById("Europe/Copenhagen");
            DateTimeOffset offset = TimeZoneInfo.ConvertTime(DateTime.Now, cet);
            
            var cache = MemoryCache.Default;
            if (!cache.Contains("StockModel"))
            {
                var expiration = offset.AddDays(1);
                cache.Add("StockModel", Stocks(stockAlias), expiration);
            }
            return cache.Get("StockModel", null) as List<StockModel>;
        }


        }
    }


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomaticStockTrading.Controllers
{
    [Route("api/")]
    public class StockController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        readonly Context Context;
        readonly UserDataService UserDataService;
        readonly StockDataService _stockDataService;
        private IConfiguration _config;
        private readonly ISession session;


        public StockController(Context context, UserDataService userDataService, IHttpContextAccessor httpContextAccessor, StockDataService stockDataService)
        {
            Context = context;
            UserDataService = userDataService;
            _stockDataService = stockDataService;
            this.session = httpContextAccessor.HttpContext.Session;

        }

       
        public IList<OrderModel> getOrders(int id)
        {

            var query = Context.users.Join(
                Context.orders,
                users => users.id,
                orders => orders.user.id,
                (users, orders) => new OrderModel
                {
                    userID = users.id,
                    id = orders.id,
                    stockID = orders.stockID,
                    amount = orders.amount,
                    dateTime = orders.dateTime,
                    price = orders.price
                }).Where(x => x.userID == id).ToList();

            return query;
        }

        [HttpGet("stocktypes/{id}")]
        public IList getOrdersWithDetails(int id)
        {
            var query = (from s in Context.users
                         join cs in Context.orders on s.id equals cs.userID
                         join os in Context.stocktype on cs.stockID equals os.id
                         where s.id == id
                         select new
                         {
                             userID = s.id,
                             id = cs.id,
                             stockID = cs.stockID,
                             amount = cs.amount,
                             dateTime = cs.dateTime,
                             price = cs.price,
                             name = os.name,
                             stock_name = os.stock_name
                         }).ToList();
            return query as IList;
        }


        [HttpGet("stockdata/{name}")]
        public ActionResult GetStockData(string name)
        {
            var myList = _stockDataService.GetSpecificTypeData(name);
            return Json(myList);
        }

        [HttpGet("forecastdata/{name}")]
        public ActionResult GetForecastData(string name)
        {
            var myList = _stockDataService.GetForeCastByStockName(name);
            return Json(myList);
        }

        [HttpGet("stockdata/date/{name}")]
        public ActionResult GetLastDateOfLogging(string name)
        {
            var lastDate = _stockDataService.GetLastDateOfStockData(name);
            return Json(lastDate);
        }
    }
}

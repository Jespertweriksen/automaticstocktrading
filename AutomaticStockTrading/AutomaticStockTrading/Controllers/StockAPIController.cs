using System;
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
        private IConfiguration _config;
        private readonly ISession session;


        public StockController(Context context, UserDataService userDataService, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            UserDataService = userDataService;
            this.session = httpContextAccessor.HttpContext.Session;

        }

        [HttpGet("stocktypes/{id}")]
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



    }

}

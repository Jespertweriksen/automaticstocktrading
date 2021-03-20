using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomaticStockTrading.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {


        // POST api/values
        [HttpPost]
        public ActionResult<IList<Models.StockModel>> PostStocks(string id)
        {
            var list = Tools.GetStocks(id);
            return Ok(list);
        }

        // GET: api/values
        [HttpGet("{id}")]
        public List<Models.StockModel> Get(string id)
        {
            return Tools.GetStocks(id);
        }

    }
}

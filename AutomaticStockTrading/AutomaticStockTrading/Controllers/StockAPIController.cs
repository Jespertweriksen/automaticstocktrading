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
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<IList<Models.StockModel>> PostStocks(string id)
        {
            var list = Tools.GetStocks(id);
            return Ok(list);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/values
        [HttpGet("{id}")]
        public List<Models.StockModel> Get(string id)
        {
            return Tools.GetStocks(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        
        public string PostStocks()
        {
            Console.WriteLine("CLICKED!");
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:5000/api/modelOne");
            string hej = "{'surname':'niklas'}";
            //requestMessage.Headers.Add("Authorization", "key=AAAAG...:APA91bH7U...");
            requestMessage.Content = new StringContent(hej, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.SendAsync(requestMessage).GetAwaiter().GetResult();
            Console.WriteLine(response);

           //var list = Tools.GetStocks(id);
            return "Ok(response)";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutomaticStockTrading.Controllers
{
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        // GET: api/values

        // POST api/values
        [HttpGet("liniarModel")]
        public async Task<ActionResult> PostStocks()
        {
            var Apple = Tools.GetStocks("AAPL");


            //var person = new Person("John Doe", "gardener");
            
            var json = JsonConvert.SerializeObject(Apple);
            Console.WriteLine(json);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://127.0.0.1:5000/api/modelOne";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            
            Console.WriteLine(result);

            return Ok(json);

        }
        

        // GET: api/values
        [HttpGet("{id}")]
        public List<Models.StockModel> Get(string id)
        {
            return Tools.GetStocks(id);
        }


        

        }

    public static class FooModel
    {
        [HttpGet]
        public static async void PostStocks()
        {
            var person = new Person("John Doe", "gardener");
            
            var json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://127.0.0.1:5000/api/modelOne";
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            
            Console.WriteLine(result);

            



        }

       
    }
    public class Person
    {
        public string myname;
        public string myname2;

        public Person(string name, string name2)
        {
            myname = name;
            myname2 = name2;
        }

    }



}

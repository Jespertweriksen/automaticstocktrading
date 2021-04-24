using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    public class YourPagesController : Controller
    {
        // Vi ændre en static var alt efter hvad brugeren vælger
        public static string userSelection = "";
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult StockPage(string id)
        {
            userSelection = id;
            return View();
        }
    }
}

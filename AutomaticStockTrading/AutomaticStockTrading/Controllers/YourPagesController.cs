using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    public class YourPagesController : Controller
    {
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
    }
}

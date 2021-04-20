using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Forside()
        {
            return View("/Views/Home/Forside.cshtml");
        }
        /*public IActionResult Index()
        { 
            return View();
        }*/
        public IActionResult Login()
        {
            return View("/Views/Login/Login.cshtml");
        }
        public IActionResult CreateAccount()
        {
            return View("/Views/Login/CreateAccount.cshtml");
        }
        public IActionResult ForgotPassword()
        {
            return View("/Views/Login/ForgotPassword.cshtml");
        }
        public IActionResult ResetPassword()
        {
            return View("/Views/Login/ResetPassword.cshtml");
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View("/Views/YourPages/Orders.cshtml");
        }
        public IActionResult Portfolio()
        {
            return View("/Views/YourPages/Portfolio.cshtml");
        }
        public IActionResult Settings()
        {
            return View("/Views/YourPages/Settings.cshtml");
        }
    }
}

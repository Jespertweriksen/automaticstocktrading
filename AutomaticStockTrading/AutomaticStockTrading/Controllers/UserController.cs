using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly Context Context;

        public UserController(Context context)
            => Context = context;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var user = Context.users.ToList();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            var user = new UserModel()
            {
                username = "Newuser",
                password = "1234",
                salt = "qwer123",
                surname = "testuser",
                last_name = "testuserlastname",
                age = 2,
                email = "newuseremail@email.dk"
            };

            Context.Add(user);
            Context.SaveChanges();

            return Ok("Succesfully created user");
        }
    }
}

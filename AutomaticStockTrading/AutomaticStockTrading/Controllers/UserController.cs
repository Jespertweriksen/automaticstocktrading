using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        readonly Context Context;
        readonly UserDataService UserDataService;


        public UserController(Context context, UserDataService userDataService)
        { 
            Context = context;
            UserDataService = userDataService;

        }

        [HttpGet("user/{id}")]
        public IActionResult GetUsers(int id)
        {
            var user = UserDataService.GetUser(id);
            return Ok(user);
        }

        //CREATE NEW USER
        [HttpPost("user")]
        public IActionResult createUser(UserModel userDto)
        {
            //string surname, string lastname, int age, string email
            var user = UserDataService.CreateUser(userDto.username, userDto.password, userDto.surname, userDto.last_name, userDto.age, userDto.email);
            return Created(" ", user);
        }
    }
}

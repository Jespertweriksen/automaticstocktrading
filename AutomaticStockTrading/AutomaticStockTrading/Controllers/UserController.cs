using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Controllers
{
    public class UserController : Controller
    {
        readonly Context Context;
        readonly UserDataService UserDataService;
        private IConfiguration _config;
        

        /*
        [Authorize]
        [HttpPost("post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            Console.WriteLine(claim.Count);
            var username = claim[0].Value;
            Console.WriteLine(username);
            return "Welcome to " + username;
        }

        private string GenerateJSONWebToken(UserModel userDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userDto.username),
                new Claim(JwtRegisteredClaimNames.Email, userDto.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Issuer",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        */

        public UserController(Context context, UserDataService userDataService)
        { 
            Context = context;
            UserDataService = userDataService;

        }

        //GETUSER
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            var user = UserDataService.GetUser(id);
            return Ok(user);
        }

        
        //CREATE NEW USER
        [HttpPost]
        [ActionName("Create")]
        public IActionResult createUser(UserModel userDto)
        {
            //string surname, string lastname, int age, string email
            var user = UserDataService.CreateUser(userDto.username, userDto.password, userDto.surname, userDto.last_name, userDto.age, userDto.email);

            if (user)
            {
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                return BadRequest("User creation failed");
            }
        }
        

        //LOGIN
        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login([FromForm] UserModel userDto)
        {
            var user = UserDataService.Login(userDto.email.ToLower(), userDto.password);

            if (user == false)
            {
                return BadRequest("No user found");
            }


            IActionResult response = Unauthorized();
            if (user)
            {
                //var tokenStr = GenerateJSONWebToken(userDto);
                response = Ok(new { id = UserDataService.GetUserIDByUsername(userDto.email), email = userDto.email, /*tokenStr*/ });
            }
            else
            {
                return BadRequest("User not authorized");
                
                
            }
            return View("/Views/Home/Forside.cshtml");
        }

        public IActionResult CreateUserPage()
        {
            return View("/Views/Login/CreateAccount.cshtml");
        }


        public IActionResult ForgotPassword()
        {
            return View("/Views/Login/ForgotPassword.cshtml");
        }

        public IActionResult LoginPage()
        {
            return View("/Views/Login/Login.cshtml");
        }


    }
}

using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;

namespace AutomaticStockTrading.Controllers
{
    public class UserController : Controller
    {
        readonly Context Context;
        readonly UserDataService UserDataService;
        private IConfiguration _config;
        private readonly ISession session;


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

        public UserController(Context context, UserDataService userDataService, IHttpContextAccessor httpContextAccessor)
        { 
            Context = context;
            UserDataService = userDataService;
            this.session = httpContextAccessor.HttpContext.Session;

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
            var wallet = UserDataService.CreateWallet(userDto.username, 0);

            if (user && wallet)
            {
                return View("/Views/Login/Login.cshtml");
            }
            else
            {
                return BadRequest("User creation failed");
            }
        }


        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update([FromForm] UserModel userDto)
        {

            var user = UserDataService.UpdateUser(session.GetInt32("userID"), userDto.username, userDto.surname, userDto.last_name, userDto.age, userDto.email);
          
            if (user)
            {
                if (!string.IsNullOrEmpty(userDto.username))
                {
                    session.SetString("username", Context.users.Find(session.GetInt32("userID")).username);

                }
                if (!string.IsNullOrEmpty(userDto.age.ToString()))
                {
                    session.SetString("age", Context.users.Find(session.GetInt32("userID")).age.ToString(("dd/MM/yyyy")));

                }
                if (!string.IsNullOrEmpty(userDto.surname))
                {
                    session.SetString("surname", Context.users.Find(session.GetInt32("userID")).surname);

                }
                if (!string.IsNullOrEmpty(userDto.last_name))
                {
                    session.SetString("lastname", Context.users.Find(session.GetInt32("userID")).last_name);

                }
                if (!string.IsNullOrEmpty(userDto.email))
                {
                    session.SetString("email", Context.users.Find(session.GetInt32("userID")).email);

                }
                return View("/Views/YourPages/Settings.cshtml");
            }
            else
            {
                return BadRequest("Profile update failed");
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
                return BadRequest();
                //return View("/Views/Shared/Error.cshtml");
            }

            IActionResult response = Unauthorized();
            if (user)
            {
                var userModel = UserDataService.GetUserModelByEmail(userDto.email);
                session.SetString("username", userModel.username);
                session.SetInt32("userID", userModel.id);
                session.SetString("age", userModel.age.ToString(("dd/MM/yyyy")));
                session.SetString("surname", userModel.surname);
                session.SetString("lastname", userModel.last_name);
                session.SetString("email", userModel.email);
                //var tokenStr = GenerateJSONWebToken(userDto);
                response = Ok(new { id = UserDataService.GetUserIDByEmail(userDto.email), email = userDto.email, /*tokenStr*/ });
            }
            else
            {
                return BadRequest("User not authorized");
            }
            return View("/Views/Home/Forside.cshtml");
        }


        [HttpPost]
        [ActionName("ResetPassword")]
        public IActionResult ResetPassword([FromForm] UserModel userDto, string newPassword)
        {
            var user = UserDataService.ChangePassword(userDto.email, userDto.password, newPassword);

            if (user)
            {
                return View("/Views/Yourpages/Settings.cshtml");
            }
            else
            {
                return BadRequest("Error updating password");
            }
            
        }




        [HttpPost]
        [ActionName("AddToBalance")]
        public IActionResult AddToBalance([FromForm] WalletModel wallet)
        {
            var balanceStatus = UserDataService.UpdateBalance(session.GetInt32("userID"), wallet.amount);

            if (balanceStatus)
            {
                return View("/Views/Yourpages/Settings.cshtml");
            }
            else
            {
                return BadRequest("Error updating balance");
            }
        }



        [HttpPost]
        [ActionName("SellStock")]
        public IActionResult SellStock([FromForm] OrderModel orderModel)
        {
            var balanceStatus = UserDataService.SellStock(orderModel.userID, orderModel.id);

            if (balanceStatus)
            {
                UserDataService.UpdateBalance(orderModel.userID, orderModel.amount * orderModel.price);
                return View("/Views/Yourpages/Portfolio.cshtml");
            }
            else
            {
                return BadRequest("Error updating balance");
            }
        }


        [HttpPost]
        [ActionName("SubtractBalance")]
        public IActionResult SubtractBalance([FromForm] WalletModel wallet)
        {
            var balanceStatus = UserDataService.SubtractBalance(session.GetInt32("userID"), wallet.amount);

            if (balanceStatus)
            {
                return View("/Views/Yourpages/Settings.cshtml");
            }
            else
            {
                return BadRequest("Error updating balance");
            }
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

        public IActionResult RecoverPage()
        {
            return View("/Views/Login/ResetPassword.cshtml");
        }

        public IActionResult Logout()
        {
            var keylist = session.Keys;
            foreach (var key in keylist)
            {
                session.Remove(key);
            }
            
            return View("/Views/Login/Login.cshtml");
        }

        [HttpPost]
        [ActionName("PasswordRecovery")]
        public IActionResult PasswordRecovery([FromForm] UserModel userDto)
        {
            //string host = HttpContext.Request.Host.Value;

            var emailBody = "Oh you forgot your password? Too bad... On another note. Request password reset on: info.automaticstocktrading@gmail.com";
            
            var emailSubject = "Password recovery";

                
            UserDataService.SendEmail(emailBody, emailSubject, userDto.email);
            return View("/Views/Login/Login.cshtml");
        }

    }
}

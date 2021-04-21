using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using AutomaticStockTrading.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


namespace AutomaticStockTrading.Controllers
{
    [Route("api/[controller]/")]
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

        [HttpGet("stocktypes")]
        public IActionResult GetStockTypes()
        {
            var stocktypes = UserDataService.stockTypes();
            return Ok(stocktypes);
        }


        [HttpGet("userorders")]
        public IActionResult GetUserOrders()
        {
            var stocktypes = UserDataService.orders();
            return Ok(stocktypes);
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
                return View("/Views/Login/Login.cshtml");
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
                return BadRequest();
                //return View("/Views/Shared/Error.cshtml");
            }

            IActionResult response = Unauthorized();
            if (user)
            {
                var userModel = UserDataService.GetUserModelByEmail(userDto.email);
                session.SetString("username", userModel.username);
                session.SetInt32("userID", userModel.id);
                session.SetInt32("age", userModel.age);
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

        public IActionResult Logout()
        {
            var keylist = session.Keys;
            foreach (var key in keylist)
            {
                session.Remove(key);
            }
            
            return View("/Views/Login/Login.cshtml");
        }



    }
}

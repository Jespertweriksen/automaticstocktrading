using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Services
{
    public class UserDataService
    {
        private readonly Context context;
        private Hashing hashing = new Hashing();
        private UserValidation _userValidation = new UserValidation();

        public UserDataService(Context context)
        {
            this.context = context;
        }

        public bool Login(string email, string password)
        {
            var getUser = context.users.FirstOrDefault(x => x.email.ToLower() == email.ToLower());
            if(getUser is null)
            {
                return false;
            }
            else
            {
                if (getUser.email.ToLower() == email.ToLower() && _userValidation.VerifyPassword(password, getUser.password, getUser.salt))
                {
                    return true;
                }
            }
            return false;
        }

        public UserModel GetUser(int id)
        {
            return context.users.Find(id);
        }

        //CHECK IF AN EMAIL IS AN EMAIL && DOESNT EXISTS IN THE DB
        public bool IsValidEmail(string email)
        {
            
            var emailTrimed = email.Trim();

            if (string.IsNullOrEmpty(emailTrimed)) return false;

            var hasWhitespace = emailTrimed.Contains(" ");
            var indexOfAtSign = emailTrimed.LastIndexOf('@');

            if (indexOfAtSign <= 0 || hasWhitespace) return false;

            var afterAtSign = emailTrimed.Substring(indexOfAtSign + 1);
            var indexOfDotAfterAtSign = afterAtSign.LastIndexOf('.');

            var query = context.users.Where(x => x.email == email).ToList();

            if (query.Count > 0) return false;

            return indexOfDotAfterAtSign > 0 && afterAtSign.Substring(indexOfDotAfterAtSign).Length > 1;
        }

        //CREATE NEW USER
        public bool CreateUser(string username, string password, string surname, string lastname, DateTime age, string email)
        {
            Hashing.HashSalt hashSalt = hashing.PasswordHash(16, password);
            
            var maxId = context.users.Max(x => x.id);
            var usernameQuery = context.users.Where(x => x.username == username).ToList();
            if (usernameQuery.Count > 0) return false;
            var emailQuery = context.users.Where(x => x.email == email).ToList();
            if (emailQuery.Count > 0) return false;

            // TODO: Add username & password check 
            if (!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(surname + "is not correct");
                return false;
            }
            if (!Regex.IsMatch(lastname, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine(lastname + "is not correct");
                return false;
            }
            if (!IsValidEmail(email))
            {
                Console.WriteLine(email + "is not correct");
                return false;
            }
            if (GetAge(age) == 0)
            {
                Console.WriteLine(age + " is 0");
                return false;
            }
            if (password == null)
            {
                Console.WriteLine(password + "is null");
                return false;
            }
            context.users.Add(new UserModel
            { username = username, password = hashSalt.Hash, salt = hashSalt.Salt, age = age, surname = surname, last_name = lastname, email = email });
            context.SaveChanges();
            return true;
            //return ctx.users.Find(maxId + 1);
        }

        //UPDATE USER PROFILE
        public bool UpdateUser(int? id, string username, string surname, string lastname, DateTime age, string email)
        {
            var getUser = context.users.Find(id);
            username ??= getUser.username;
            surname ??= getUser.surname;
            lastname ??= getUser.last_name;
            email ??= getUser.email;

            var userNameCheck = context.users.Where(x => x.username == username).ToList();
            var emailCheck = context.users.Where(x => x.email == email).ToList();

            //if (getUser == null) return false;
            //PASSWORD
            //if (_userValidation.VerifyPassword(password, ctx.users.Find(id).Password, ctx.users.Find(id).Salt))
            //{
            //USERNAME
            if (username != null && Regex.IsMatch(username, @"^[a-zA-Z]+$") && userNameCheck.Count() == 0)
            {
                context.users.Update(context.users.Find(id)).Entity.username = username;
            }

            //SURNAME
            if (surname != null && Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                context.users.Update(context.users.Find(id)).Entity.surname = surname;
            }

            //LASTNAME
            if (lastname != null && Regex.IsMatch(lastname, @"^[a-zA-Z]+$"))
            {
                context.users.Update(context.users.Find(id)).Entity.last_name = lastname;
            }

            //AGE
            if (GetAge(age) != 0)
            {
                context.users.Update(context.users.Find(id)).Entity.age = age.Date;
            }

            //EMAIL
            if (email != null && IsValidEmail(email) && emailCheck.Count() == 0)
            {
                context.users.Update(context.users.Find(id)).Entity.email = email;
            }

            context.SaveChanges();
            return true;
            //}
        }

        //CHANGE PASSWORD
        public bool ChangePassword(/*int id,*/ string username, string oldpassword, string newpassword)
        {
            var getUser = context.users.FirstOrDefault(x => x.username == username);
            if (getUser.Equals(null)) return false;
            if (!_userValidation.VerifyPassword(oldpassword, getUser.password, getUser.salt)) return false;

            Hashing.HashSalt hashSalt = hashing.PasswordHash(16, newpassword);
            context.users.Update(getUser).Entity.password = hashSalt.Hash;
            context.users.Update(getUser).Entity.salt = hashSalt.Salt;
            context.SaveChanges();
            return true;

        }

        //GET USER PROFILE
        public int GetUserIDByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().id;
            return query;
        }

        public UserModel GetUserModelByEmail(string email)
        {
            UserModel model = new UserModel();
            var username = context.users.Where(x => x.email == email).FirstOrDefault().username;
            var surname = context.users.Where(x => x.email == email).FirstOrDefault().surname;
            var lastname = context.users.Where(x => x.email == email).FirstOrDefault().last_name;
            var age = context.users.Where(x => x.email == email).FirstOrDefault().age;
            var id = context.users.Where(x => x.email == email).FirstOrDefault().id;
            model.id = id;
            model.username = username;
            model.surname = surname;
            model.last_name = lastname;
            model.age = age;
            model.email = email;
            return model;
        }
        
        public IList<OrderModel> getOrders(int id)
        {

            var query = context.users.Join(
                context.orders,
                users => users.id,
                orders => orders.user.id,
                (users, orders) => new OrderModel
                {
                    userID = users.id,
                    id = orders.id,
                    stockID = orders.stockID,
                    amount = orders.amount,
                    dateTime = orders.dateTime,
                    price = orders.price
                }).Where(x => x.userID == id).ToList();

            return query;
        }

        public IList<OrderModel> getOrdersWithDetails(int id)
        {
            var query = (from s in context.users
                join cs in context.orders on s.id equals cs.userID
                join os in context.stocktype on cs.stockID equals os.id
                where s.id == id
                select new OrderModel
                {
                    userID = s.id,
                    id = cs.id,
                    stockID = cs.stockID,
                    amount = cs.amount,
                    dateTime = cs.dateTime,
                    price = cs.price,
                    name = os.name,
                    stock_name = os.stock_name
                }).ToList();
            return query;
        }

        public Int32 GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }





        public bool DeleteUser(int id)
        {
            var dbUser = GetUser(id);
            if (dbUser == null)
            {
                return false;
            }
            context.users.Remove(dbUser);
            context.SaveChanges();
            return true;
        }
    }
}

using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using Microsoft.Extensions.Options;
using System;
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
        public bool CreateUser(string username, string password, string surname, string lastname, int age, string email)
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
            if (age == 0)
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

        //GET USER PROFILE
        public int GetUserIDByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().id;
            return query;
        }

        public string GetUsernameByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().username;
            return query;
        }

        public int GetAgeByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().age;
            return query;
        }

        public string GetSurnameByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().surname;
            return query;
        }

        public string GetLastnameByEmail(string email)
        {
            var query = context.users.Where(x => x.email == email).FirstOrDefault().last_name;
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

using AutomaticStockTrading.DataContext;
using AutomaticStockTrading.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Login(string password, string email)
        {
            var getUser = context.users.FirstOrDefault(x => x.email.ToLower() == email.ToLower());
            if (getUser.email.ToLower() == email.ToLower() && _userValidation.VerifyPassword(password, getUser.password, getUser.salt))
            {
                return true;
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
        public UserModel CreateUser(string username, string password, string surname, string lastname, int age, string email)
        {
            Hashing.HashSalt hashSalt = hashing.PasswordHash(16, password);
            var maxId = context.users.Max(x => x.id);

            context.users.Add(new UserModel
            { username = username, password = hashSalt.Hash, salt = hashSalt.Salt, age = age, surname = surname, last_name = lastname, email = email });
            context.SaveChanges();
            return context.users.Find(maxId + 1);
        }

        //GET USER PROFILE
        public int GetUserIDByUsername(string username)
        {
            var query = context.users.Where(x => x.username == username).FirstOrDefault().id;
            return query;
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

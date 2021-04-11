﻿using System;
using System.Security.Cryptography;

namespace AutomaticStockTrading.Services
{
    public class Hashing
    {
        public class HashSalt
        {
            public string Hash { get; set; }
            public string Salt { get; set; }
        }

        public HashSalt PasswordHash(int saltSize, string password)
        {
            var saltBytes = new byte[saltSize];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
    }
}

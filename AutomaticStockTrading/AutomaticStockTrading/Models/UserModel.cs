using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string surname { get; set; }
        public string last_name { get; set; }
        public DateTime age { get; set; }
        public string email { get; set; }
        public List<OrderModel> order { get; set; }
        
        public List<WalletModel> wallet { get; set; }


    }
}

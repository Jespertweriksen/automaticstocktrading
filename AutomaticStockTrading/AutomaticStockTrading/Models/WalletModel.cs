using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class WalletModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public float amount { get; set; }
        public DateTime paymentDate { get; set; }

        public UserModel user { get; set; }
    }
}

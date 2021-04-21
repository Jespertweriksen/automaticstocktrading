using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Models
{
    public class OrderModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int stockID { get; set; }
        public int amount { get; set; }
        public DateTime dateTime { get; set; }
        public int price { get; set; }


        // One order can have one user and stock. One user can have many orders.
        public UserModel user { get; set; }
        public StockTypeModel stockType { get; set; }
    }
}

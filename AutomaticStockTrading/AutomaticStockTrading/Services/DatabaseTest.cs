using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.Services
{
    public class DatabaseTest
    {
        private static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Debug.WriteLine("Connected");
                    Console.WriteLine("Connected");
                }
                else
                {
                    Debug.WriteLine("Not connected");
                    Console.WriteLine("Not connected");
                }
            }
        }


        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=projectinstances.cij3th4yqqes.eu-north-1.rds.amazonaws.com;Port=5432;User Id=jtweruc;Password=Thirdsemesterproject;Database=autostocks;");
        }
    }
}

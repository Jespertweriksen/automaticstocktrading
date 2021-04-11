using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace AutomaticStockTrading.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfiguration(new DBConfig());
        
        public DbSet<UserModel> users { get; set; }
    }
}

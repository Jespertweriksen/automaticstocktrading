using AutomaticStockTrading.ModelConfiguration;
using AutomaticStockTrading.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public DbSet<UserModel> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<UserModel>().ToTable("users");
            modelBuilder.Entity<UserModel>().Property(x => x.id).HasColumnName("id");
            modelBuilder.Entity<UserModel>().Property(x => x.username).HasColumnName("username");
            modelBuilder.Entity<UserModel>().Property(x => x.password).HasColumnName("password");
            modelBuilder.Entity<UserModel>().Property(x => x.salt).HasColumnName("salt");
            modelBuilder.Entity<UserModel>().Property(x => x.surname).HasColumnName("surname");
            modelBuilder.Entity<UserModel>().Property(x => x.last_name).HasColumnName("last_name");
            modelBuilder.Entity<UserModel>().Property(x => x.age).HasColumnName("age");
            modelBuilder.Entity<UserModel>().Property(x => x.email).HasColumnName("email");

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DBConfig());
        }

    }
}

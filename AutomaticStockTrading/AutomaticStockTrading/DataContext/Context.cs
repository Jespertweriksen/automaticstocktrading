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

        public Context()
        {
        }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public DbSet<UserModel> users { get; set; }
        public DbSet<ForecastDataModel> forecast_data { get; set; }
        public DbSet<OrderModel> orders { get; set; }
        public DbSet<StockDataModel> stockdata { get; set; }
        public DbSet<StockTypeModel> stocktype { get; set; }

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


            modelBuilder.Entity<ForecastDataModel>().ToTable("forecast_data");
            modelBuilder.Entity<ForecastDataModel>().Property(x => x.id).HasColumnName("id");
            modelBuilder.Entity<ForecastDataModel>().Property(x => x.close).HasColumnName("close");
            modelBuilder.Entity<ForecastDataModel>().Property(x => x.stock_type_id).HasColumnName("stock_type_id");
            modelBuilder.Entity<ForecastDataModel>().HasOne(x => x.stockType).WithMany(x => x.forecast).HasForeignKey(x => x.stock_type_id);

            modelBuilder.Entity<OrderModel>().ToTable("orders");
            modelBuilder.Entity<OrderModel>().Property(x => x.id).HasColumnName("id");
            modelBuilder.Entity<OrderModel>().Property(x => x.userID).HasColumnName("userID");
            modelBuilder.Entity<OrderModel>().Property(x => x.stockID).HasColumnName("stockID");
            modelBuilder.Entity<OrderModel>().Property(x => x.amount).HasColumnName("amount");
            modelBuilder.Entity<OrderModel>().Property(x => x.dateTime).HasColumnName("date");
            modelBuilder.Entity<OrderModel>().Property(x => x.price).HasColumnName("price");


            modelBuilder.Entity<StockDataModel>().ToTable("stock_data");
            modelBuilder.Entity<StockDataModel>().Property(x => x.id).HasColumnName("id");
            modelBuilder.Entity<StockDataModel>().Property(x => x.datetime).HasColumnName("datetime");
            modelBuilder.Entity<StockDataModel>().Property(x => x.open).HasColumnName("open");
            modelBuilder.Entity<StockDataModel>().Property(x => x.high).HasColumnName("high");
            modelBuilder.Entity<StockDataModel>().Property(x => x.low).HasColumnName("low");
            modelBuilder.Entity<StockDataModel>().Property(x => x.close).HasColumnName("close");
            modelBuilder.Entity<StockDataModel>().Property(x => x.volume).HasColumnName("volume");
            modelBuilder.Entity<StockDataModel>().Property(x => x.stock_type_id).HasColumnName("stock_type_id");
            modelBuilder.Entity<StockDataModel>().HasOne(x => x.stockType).WithMany(x => x.stockData)
                .HasForeignKey(x => x.stock_type_id);



            modelBuilder.Entity<StockTypeModel>().ToTable("stock_type");
            modelBuilder.Entity<StockTypeModel>().Property(x => x.id).HasColumnName("id");
            modelBuilder.Entity<StockTypeModel>().Property(x => x.name).HasColumnName("name");
            modelBuilder.Entity<StockTypeModel>().Property(x => x.stock_name).HasColumnName("stock_name");



               

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DBConfig());
        }

    }
}

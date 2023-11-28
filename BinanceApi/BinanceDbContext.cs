using BinanceApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;

namespace BinanceApi
{
    public class BinanceDbContext:DbContext
    {
        public DbSet<Kline> Klines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-R04PVQ3\\SQLEXPRESS; Database = BinanceDb; Trusted_Connection = true; TrustServerCertificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
             modelBuilder.Entity<Kline>().HasKey(k => k.OpenTime);

            
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader
{
    public class CryptoContext : DbContext
    {
        public DbSet<CryptoCurrency> Student { get; set; }

        public CryptoContext(DbContextOptions<CryptoContext> options) : base(options) { }
        public CryptoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "Donau.hiof.no",
                InitialCatalog = "thomasjg",
                UserID = "thomasjg",
                Password = "wtYSS9wz83"
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CryptoCurrency>().HasData(new CryptoCurrency { Id = "NET", Name = ".NET Coin", Price = 100000, Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1024px-.NET_Logo.svg.png" });

        }
    }
}

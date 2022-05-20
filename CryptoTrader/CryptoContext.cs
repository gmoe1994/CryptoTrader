using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CryptoTrader
{
    public class CryptoContext : DbContext
    {
        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }

        public string DbPath { get; set; }

        public CryptoContext(DbContextOptions<CryptoContext> options) : base(options) { }
        public CryptoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new()
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
            modelBuilder.Entity<CryptoCurrency>().HasData(new CryptoCurrency { Id = "NET", Name = ".NET Coin", Price = 100000, Quantity = 1, Logo_url = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1024px-.NET_Logo.svg.png" });

        }
    }
}

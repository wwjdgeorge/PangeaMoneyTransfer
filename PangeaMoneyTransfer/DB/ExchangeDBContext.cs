using Microsoft.EntityFrameworkCore;
using PangeaMoneyTransfer.DB.Models;

namespace PangeaMoneyTransfer.DB
{
    public class ExchangeDBContext: DbContext
    {
        public ExchangeDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> countries { get; set; }
        public DbSet<Currency> currencys { get; set; }
        public DbSet<CountryFlatRates> countryFlatRates { get; set; } 
    }
   
}

using Microsoft.EntityFrameworkCore;

namespace OfflineChallenge
{
    public class CountryCovidInfoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source= sqlite.db");
        }

        public DbSet<CountryCovidInfo> CountryCovidInfo { get; set; }
    }
}

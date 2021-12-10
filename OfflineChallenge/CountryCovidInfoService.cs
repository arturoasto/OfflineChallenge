using Microsoft.EntityFrameworkCore;

namespace OfflineChallenge
{
    public class CountryCovidInfoService
    {
        private CountryCovidInfoDbContext _dbContext;

        public CountryCovidInfoService(CountryCovidInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CountryCovidInfo>> GetCountryCovidInfoAsync()
        {
            return await _dbContext.CountryCovidInfo.ToListAsync();
        }

        public async Task<CountryCovidInfo> Add(CountryCovidInfo countryCovidInfo)
        {
            _dbContext.CountryCovidInfo.Add(countryCovidInfo);
            await _dbContext.SaveChangesAsync();

            return countryCovidInfo;
        }

        public async Task DeleteAll(List<CountryCovidInfo> countryCovidInfo)
        {
            _dbContext.CountryCovidInfo.RemoveRange(countryCovidInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}

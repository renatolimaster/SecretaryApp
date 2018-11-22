using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class CountryService  : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext, ICongregationRepository repoCong)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> GetCountries()
        {
            var countries = await _dbContext.Country.ToListAsync();

            return countries;
        }

        public async Task<Country> GetCountryAsync(long id)
        {
            var countries = await _dbContext.Country.Where(c => c.Id == id).FirstOrDefaultAsync();

            return countries;
        }
    }
}
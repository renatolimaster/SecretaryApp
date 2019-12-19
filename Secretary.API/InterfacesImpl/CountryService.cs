using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
  public class CountryService : ICountryRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public CountryService(ApplicationDbContext dbContext, ICongregationRepository repoCong)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Country>> GetCountriesAsync()
    {
      var countries = await _dbContext.Country.ToListAsync();

      return countries;
    }
    
    public async Task<Country> GetCountryAsync(long id)
    {
      var countries = await _dbContext.Country.Where(c => c.Id == id).FirstOrDefaultAsync();

      return countries;
    }

    public async Task<Country> GetCountryByNameAsync(string search)
    {
      //var countries = await _dbContext.Country.Where(c => String.Equals(c.NiceName, search, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();

      var countries = await _dbContext.Country.Where(c => c.NiceName.ToLower().Contains(search.ToLower())).FirstOrDefaultAsync();

      return countries;
    }

    public async Task<List<Country>> GetCountriesByNameAsync(string search)
    {
      // var countries = await _dbContext.Country.Where(c => String.Equals(c.NiceName, search, StringComparison.OrdinalIgnoreCase)).ToListAsync();

      var countries = await _dbContext.Country.Where(c => c.NiceName.ToLower().Contains(search.ToLower())).ToListAsync();
      
      return countries;
    }
  }
}
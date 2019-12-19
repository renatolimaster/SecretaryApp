using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Model;

namespace Secretary.API.Interfaces
{
  public interface ICountryRepository
  {
    Task<List<Country>> GetCountriesAsync();
    Task<Country> GetCountryAsync(long id);
    Task<Country> GetCountryByNameAsync(string search);
    Task<List<Country>> GetCountriesByNameAsync(string search);
  }
}
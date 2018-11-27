using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountryAsync(long id);
        Task<Country> GetCountryByNameAsync(string search);
    }
}
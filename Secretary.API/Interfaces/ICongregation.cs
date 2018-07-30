using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface ICongregation
    {
        Task<List<Congregacao>> getAllCongregationsAsync();
        Task<Congregacao> getCongregationAsync(long id);
    }
}
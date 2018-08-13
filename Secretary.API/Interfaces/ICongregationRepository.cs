using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface ICongregationRepository
    {
        Task<List<Congregacao>> getAllCongregationsAsync();
        Task<Congregacao> getCongregationAsync(long id);

        Congregacao getCongregationDefaultAsync();
    }
}
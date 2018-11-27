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
        bool verifyExistCongregationByNumber(string congregationNumber);
        bool verifyExistCongregationByNumberState(string congregationNumber, long stateId);
        void Add(Congregacao congregacao);
        Task<bool> SaveAllAsync(Congregacao congregacao);
    }
}
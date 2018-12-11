using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Model;

namespace Secretary.API.Interfaces
{
    public interface ICongregationRepository
    {
        Task<List<Congregacao>> getAllCongregationsAsync();
        Task<Congregacao> getCongregationAsync(long id);
        Task<Congregacao> getCongregationByUserAsync(long userId);
        Congregacao getCongregationDefaultAsync();
        bool verifyExistCongregationByNumber(string congregationNumber);
        bool verifyExistCongregationByNumberDiffId(Congregacao congregation);
        bool verifyExistCongregationByNumberState(string congregationNumber, long stateId);
        void Add(Congregacao congregacao);
        Task<bool> SaveAllAsync(Congregacao congregacao);

    }
}
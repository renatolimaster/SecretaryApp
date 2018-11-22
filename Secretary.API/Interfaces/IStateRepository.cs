using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IStateRepository
    {
        Task<List<Estado>> GetStates();
        Task<Estado> GetState(long id);
        Task<List<Estado>> GetStatesByCountry(long id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IPioneerRepository
    {
        Task<List<Pioneiro>> getAllPioneersAsync();
        Task<Pioneiro> getPioneerAsync(long id);
    }
}
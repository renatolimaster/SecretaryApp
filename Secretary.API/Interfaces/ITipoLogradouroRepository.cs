using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface ITipoLogradouroRepository
    {
        Task<List<TipoLogradouro>> GetTipos();
        Task<TipoLogradouro> GetTipo(long id);
    }
}
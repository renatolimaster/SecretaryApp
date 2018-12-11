using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
    public class TipoLogradouroService : ITipoLogradouroRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TipoLogradouroService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoLogradouro> GetTipo(long id)
        {
            var tipo = await _dbContext.TipoLogradouro.Where(t => t.Id == id).FirstOrDefaultAsync();

            return tipo;
        }

        public async  Task<List<TipoLogradouro>> GetTipos()
        {
            var tipo = await _dbContext.TipoLogradouro.ToListAsync();

            return tipo;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
    public class PioneerService : IPioneerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PioneerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pioneiro> getPioneerAsync(long id)
        {
            var pioneer = await _dbContext.Pioneiro.Include(p => p.Congregacao).FirstOrDefaultAsync(p => p.Id == id);
            return pioneer;
        }

        public async Task<List<Pioneiro>> getAllPioneersAsync()
        {
            var pioneer = await _dbContext.Pioneiro.Include(p => p.Congregacao).OrderBy(p => p.Id).ToListAsync();
            return pioneer;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
    public class StateService : IStateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICongregationRepository _repoCong;

        public StateService(ApplicationDbContext dbContext, ICongregationRepository repoCong)
        {
            _dbContext = dbContext;
            _repoCong = repoCong;
        }

        public async Task<Estado> GetState(long id)
        {
            var states = await _dbContext.Estado.Include(e => e.Country).Where(e => e.Id == id).FirstOrDefaultAsync();

            return states;
        }

        public async Task<List<Estado>> GetStates()
        {
            var states = await _dbContext.Estado.Include(e => e.Country).ToListAsync();

            return states;
        }

        public async Task<List<Estado>> GetStatesByCountry(long id)
        {
            var states = await _dbContext.Estado.Include(e => e.Country).Where(e => e.Country.Id == id).ToListAsync();

            return states;
        }
    }
}
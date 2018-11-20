using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

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

        public Task<Estado> GetState(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Estado>> GetStates()
        {
            var states = await _dbContext.Estado.Include(e => e.Country).ToListAsync();

            return states;
        }
    }
}
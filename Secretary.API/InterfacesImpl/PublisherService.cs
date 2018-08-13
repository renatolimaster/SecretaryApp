using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class PublisherService : IPublisherRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICongregationRepository _repoCong;

        public PublisherService(ApplicationDbContext dbContext, ICongregationRepository repoCong)
        {
            _dbContext = dbContext;
            _repoCong = repoCong;
        }
        public Task<List<Publicador>> getAllPublishersAsync()
        {
            Console.WriteLine("PublisherService getAllPublishersAsync");

            var cong = _repoCong.getCongregationDefaultAsync();

            var pub = _dbContext.Publicador.AsNoTracking().Where(p => p.CongregacaoId == cong.Id).Include(p => p.Dianteira).Include(p => p.Grupo).Include(p => p.Congregacao).Include(p => p.Pioneiro).ToListAsync();

            return pub;
        }

        public Task<Publicador> getPublisherAsync(long id)
        {
            Console.WriteLine("PublisherService getAllPublishersAsync");

            var pub = _dbContext.Publicador.AsNoTracking().Include(p => p.Dianteira).Include(p => p.Grupo).Include(p => p.Congregacao).Include(p => p.Pioneiro).FirstOrDefaultAsync(p => p.Id == id);

            return pub;
        }
    }
}
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
        public async Task<IEnumerable<Publicador>> getAllPublishersAsync()
        {


            var cong = _repoCong.getCongregationDefaultAsync();

            Console.WriteLine("================= getAllPublishersAsync IN =================");

            Console.WriteLine("Cong: " + cong.Id + " - " + cong.Nome);

            var pub = await _dbContext.Publicador.AsNoTracking().Include(p => p.Dianteira).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Grupo).OrderBy(p => p.Nome).Where(p => p.CongregacaoId == cong.Id).ToListAsync();

            // var pub = await _dbContext.Publicador.AsNoTracking().Include(p => p.Congregacao).Include(p => p.Dianteira).Include(p => p.Pioneiro).OrderBy(p => p.Nome).Where(p => p.CongregacaoId == cong.Id).Where(p => p.Grupo.CongregacaoId == cong.Id).ToListAsync();

            // Console.WriteLine("================= getAllPublishersAsync OUT =================");

            pub.ForEach(element =>
            {
                Console.WriteLine(element.Id + " - " + element.Nome);
            });

            return pub;
        }

        public Task<Publicador> getPublisherAsync(long id)
        {
            Console.WriteLine("================= getAllPublishersAsync =================");

            var pub = _dbContext.Publicador.AsNoTracking().Include(p => p.Dianteira).Include(p => p.Grupo).Include(p => p.Congregacao).Include(p => p.Pioneiro).FirstOrDefaultAsync(p => p.Id == id);

            return pub;
        }
    }
}
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
    public class FieldServiceReportService : IFieldServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICongregationRepository _repoCong;
        public FieldServiceReportService(ApplicationDbContext dbContext, ICongregationRepository repoCong)
        {
            _dbContext = dbContext;
            _repoCong = repoCong;
        }
        public Task<List<ServicoCampo>> getAllFieldServicesAsync()
        {

            // ===============  Delimiter period of year field service ===================== //

            Console.WriteLine("getAllFieldServicesAsync 1");
            DateTime dtaRefIni = new DateTime(2018,07,01);
            DateTime dtaRefFim = new DateTime(2018,07,01);

            var congDefault = _repoCong.getCongregationDefaultAsync();
            
            var serv = _dbContext.ServicoCampo.Include(s => s.Congregacao).Include(s => s.Publicador).Include(s => s.Pioneiro).Where(x => x.Publicador.Congregacao.Equals(congDefault)).Where(s => s.DataEntrega >= dtaRefIni).Where(s => s.DataEntrega <= dtaRefFim).OrderBy(s => s.Publicador.Nome).OrderByDescending(s => s.DataEntrega).ToListAsync();

            Console.WriteLine("getAllFieldServicesAsync 2");
            return serv;
        }

        public Task<ServicoCampo> getFieldServiceAsync(long id)
        {
            Console.WriteLine("getFieldServiceAsync");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = _dbContext.ServicoCampo.AsNoTracking().Where(p => p.CongregacaoId == cong.Id).Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).FirstOrDefaultAsync(p => p.Id == id);

            return serv;
        }

        public async Task<bool> SaveAll()
        {
            // _dbContext.Database.SetCommandTimeout(5);
            var back = await _dbContext.SaveChangesAsync();
            Console.WriteLine("back : " + back);
            return false;
        }
    }
}
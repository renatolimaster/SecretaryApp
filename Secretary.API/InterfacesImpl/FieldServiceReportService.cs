using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Dtos;
using Secretary.API.Helpers;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class FieldServiceReportService : IFieldServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICongregationRepository _repoCong;
        private readonly IPublisherRepository _publisherService;

        public FieldServiceReportService(ApplicationDbContext dbContext, ICongregationRepository repoCong, IPublisherRepository publisherService)
        {
            _dbContext = dbContext;
            _repoCong = repoCong;
            _publisherService = publisherService;
        }
        public async Task<List<ServicoCampo>> getAllFieldServicesAsync()
        {

            // ===============  Delimiter period of year field service ===================== //

            Console.WriteLine("getAllFieldServicesAsync 1");
            // DateTime dtaRefIni = new DateTime(2018, 07, 01);
            // DateTime dtaRefFim = new DateTime(2018, 07, 01);
            DateTime dtaRefIni = DateTime.Now.AddMonths(-1);
            DateTime dtaRefFim = DateTime.Now;
            DateTime initialDate = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dtaRefIni).Date;
            DateTime dateToday = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dtaRefFim).Date;

            var congDefault = _repoCong.getCongregationDefaultAsync();

            var serv = await _dbContext.ServicoCampo.Include(s => s.Congregacao).Include(s => s.Publicador).Include(s => s.Pioneiro).Where(x => x.Publicador.Congregacao.Equals(congDefault)).Where(s => s.DataEntrega >= initialDate).Where(s => s.DataEntrega <= dateToday).OrderBy(s => s.Publicador.Nome).OrderByDescending(s => s.DataEntrega).ToListAsync();

            Console.WriteLine("getAllFieldServicesAsync 2");
            return serv;
        }

        public async Task<ServicoCampo> getFieldServiceAsync(long id)
        {
            Console.WriteLine("getFieldServiceAsync Service");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = await _dbContext.ServicoCampo.AsNoTracking().Where(p => p.CongregacaoId == cong.Id).Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).FirstOrDefaultAsync(p => p.Id == id);

            return serv;
        }

        public Task<ServicoCampo> getSingleOrDefaultAsync(long id)
        {
            Console.WriteLine("getSingleOrDefaultAsync");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = _dbContext.ServicoCampo.AsNoTracking().Where(p => p.CongregacaoId == cong.Id).Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).SingleOrDefaultAsync(p => p.Id == id);

            return serv;
        }

        public Task<ServicoCampo> getSCSingleOrDefaultAsync(long id)
        {
            Console.WriteLine("getSCSingleOrDefaultAsync");

            var serv = _dbContext.ServicoCampo.SingleOrDefaultAsync(p => p.Id == id);

            return serv;
        }


        public async Task<double> getMediaYearlyFieldServiceAsync(long publisherId)
        {
            var dataInicial = DateTime.Now.AddMonths(-12);
            var dataReferencia = DateTime.Now.AddMonths(-1);

            DateTime dataR = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataInicial).Date;
            DateTime dateToday = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataReferencia).Date;


            var dateStartService = _publisherService.getStartFieldService(publisherId);

            var fieldService = this.getFieldServiceByPublisherIdAsync(publisherId);


            if (fieldService != null)
            {
                if (dataR < dateStartService)
                {
                    dataR = dateStartService;
                }


                var mediaH = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.Horas).Value;
                var mediaHb = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.HorasBetel);
                var mediaHc = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.CreditoHoras);

                var media = (mediaH + mediaHb + mediaHc);


                var fst = _dbContext.ServicoCampot.AsNoTracking().Where(s => s.PublicadorId == publisherId).FirstOrDefaultAsync().Result;
                Console.WriteLine("Media3MonthsAsync Update List Count: " + fst.Horas);
                if (fst.Horas > 0)
                {
                    fst.Horas = mediaH;
                    fst.HorasBetel = mediaHb;
                    fst.CreditoHoras = mediaHc;
                    _dbContext.Update(fst);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Update");
                }
                else
                {
                    ServicoCampot sct = new ServicoCampot();
                    sct.PublicadorId = publisherId;
                    sct.Horas = mediaH;
                    sct.HorasBetel = mediaHb;
                    sct.CreditoHoras = mediaHc;
                    _dbContext.Add(sct);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Add");
                }

                return media;
            }

            return 0;
        }

        public async Task<double> getMediaQuarterlyFieldServiceSAsync(long publisherId)
        {
            var dataInicial = DateTime.Now.AddMonths(-3);
            var dataReferencia = DateTime.Now.AddMonths(-1);

            DateTime dataR = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataInicial).Date;
            DateTime dateToday = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataReferencia).Date;


            var dateStartService = _publisherService.getStartFieldService(publisherId);

            var fieldService = this.getFieldServiceByPublisherIdAsync(publisherId);

            if (fieldService != null)
            {

                if (dataR < dateStartService.Date)
                {
                    dataR = dateStartService.Date;
                }

                Console.WriteLine("DateTime ==================== : " + dataR + " - " + dateToday + " - " + dateStartService.Date);

                double mediaH = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Where(s => s.PublicadorId == publisherId).Average(s => s.Horas).Value;
                Console.WriteLine("Media3MonthsAsync Update mediaH: " + mediaH);
                double mediaHb = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Where(s => s.PublicadorId == publisherId).Average(s => s.HorasBetel);
                Console.WriteLine("Media3MonthsAsync Update mediaHb: " + mediaHb);
                double mediaHc = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Where(s => s.PublicadorId == publisherId).Average(s => s.CreditoHoras);
                Console.WriteLine("Media3MonthsAsync Update mediaHc: " + mediaHc);

                double media = (mediaH + mediaHb + mediaHc);

                Console.WriteLine("Media3MonthsAsync Update: " + media);

                var fst = _dbContext.ServicoCampot.AsNoTracking().Where(s => s.PublicadorId == publisherId).FirstOrDefaultAsync().Result;
                Console.WriteLine("Media3MonthsAsync Update List Count: " + fst.Horas);
                if (fst.Horas > 0)
                {
                    fst.Horas = mediaH;
                    fst.HorasBetel = mediaHb;
                    fst.CreditoHoras = mediaHc;
                    _dbContext.Update(fst);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Update");
                }
                else
                {
                    ServicoCampot sct = new ServicoCampot();
                    sct.PublicadorId = publisherId;
                    sct.Horas = mediaH;
                    sct.HorasBetel = mediaHb;
                    sct.CreditoHoras = mediaHc;
                    _dbContext.Add(sct);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Add");
                }

                Console.WriteLine("Media: " + media);
                // await Task.Delay(5000);

                return media;
            }

            return 0;
        }

        public async Task<double> getMediaSemesterFieldServiceAsync(long publisherId)
        {
            var dataInicial = DateTime.Now.AddMonths(-6);
            var dataReferencia = DateTime.Now.AddMonths(-1);

            DateTime dataR = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataInicial).Date;
            DateTime dateToday = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataReferencia).Date;


            var dateStartService = _publisherService.getStartFieldService(publisherId);

            var fieldService = this.getFieldServiceByPublisherIdAsync(publisherId);

            if (fieldService != null)
            {
                if (dataR < dateStartService)
                {
                    dataR = dateStartService;
                }

                var mediaH = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.Horas).Value;
                var mediaHb = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.HorasBetel);
                var mediaHc = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataEntrega >= dataR).Where(s => s.DataEntrega <= dateToday).Average(s => s.CreditoHoras);

                var media = (mediaH + mediaHb + mediaHc);

                var fst = _dbContext.ServicoCampot.AsNoTracking().Where(s => s.PublicadorId == publisherId).FirstOrDefaultAsync().Result;
                Console.WriteLine("Media3MonthsAsync Update List Count: " + fst.Horas);
                if (fst.Horas > 0)
                {
                    fst.Horas = mediaH;
                    fst.HorasBetel = mediaHb;
                    fst.CreditoHoras = mediaHc;
                    _dbContext.Update(fst);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Update");
                }
                else
                {
                    ServicoCampot sct = new ServicoCampot();
                    sct.PublicadorId = publisherId;
                    sct.Horas = mediaH;
                    sct.HorasBetel = mediaHb;
                    sct.CreditoHoras = mediaHc;
                    _dbContext.Add(sct);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Add");
                }

                return media;
            }

            return 0;
        }

        public async Task<bool> SaveAllAsync()
        {
            Console.WriteLine("SaveAllAsync");
            var back = await _dbContext.SaveChangesAsync() > 0;
            return back;
        }

        public Task<ServicoCampo> getFieldServiceByPublisherIdAsync(long publisherId)
        {
            Console.WriteLine("getFieldServiceByPublisherIdAsync");

            var serv = _dbContext.ServicoCampo.OrderByDescending(s => s.Id).FirstOrDefaultAsync(p => p.PublicadorId == publisherId);

            Console.WriteLine("getFieldServiceByPublisherIdAsync: " + serv.Result.Id + " Publ: " + serv.Result.Publicador.Nome);


            return serv;
        }

        public async Task<List<ServicoCampo>> initializeFieldService(DateTime deliveryDate)
        {
            Console.WriteLine("**** initializeFieldServiceAsync ****");
            var i = 0;
            //var y = 0;
            List<ServicoCampo> serv = null;
            var congDefault = _repoCong.getCongregationDefaultAsync();
            deliveryDate = deliveryDate.Date;
            List<Publicador> publishers = _publisherService.getPublisherByCongregation(congDefault.Id);
            var countPublishers = publishers.Count;
            Console.WriteLine("congDefault: " + congDefault.Id + " - " + congDefault.Nome + " - " + countPublishers);
            if (countPublishers > 0)
            {
                foreach (var item in publishers)
                {
                    if (!VerifyExistFieldServiceByPublisher(deliveryDate, item.Id))
                    {
                        Console.WriteLine("congDefault: " + item.Id + " - " + deliveryDate + " - " + item.Nome + " - " + item.PioneiroId);
                        try
                        {
                            ServicoCampo servicoCampo = new ServicoCampo
                            {
                                AnoReferencia = deliveryDate.Year,
                                MesReferencia = deliveryDate.Month,
                                PublicadorId = item.Id,
                                PioneiroId = item.PioneiroId.Value,
                                Livros = 0,
                                FolhetosBrochuras = 0,
                                Horas = 0,
                                Revistas = 0,
                                Revisitas = 0,
                                Estudos = 0,
                                Minutos = 0,
                                DataReferencia = deliveryDate,
                                DataEntrega = deliveryDate,
                                Observacao = "",
                                Publicacoes = 0,
                                CongregacaoId = item.CongregacaoId,
                                CreditoHoras = 0,
                                HorasBetel = 0,
                                VideosMostrados = 0
                            };
                            Console.WriteLine("servicoCampo: " + servicoCampo.Id);
                            _dbContext.Add(servicoCampo);
                            await _dbContext.SaveChangesAsync();

                            //update publisher status, medias
                            var status = "";
                            status = await _publisherService.setPublisherStatusAsync(item.Id);
                            //medias
                            // var media3 = await this.getMediaQuarterlyFieldServiceSAsync(item.Id);
                            // var media6 = await this.getMediaSemesterFieldServiceAsync(item.Id);
                            // var media12 = await this.getMediaYearlyFieldServiceAsync(item.Id);
                            var media3 = await this.getMediaFieldServiceAsync(item.Id, -3);
                            var media6 = await this.getMediaFieldServiceAsync(item.Id, -6);
                            var media12 = await this.getMediaFieldServiceAsync(item.Id, -12);

                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            Console.WriteLine("InitializeFieldService Error");
                        }
                        i++;
                    }
                }
                // GET FIELD SERVICES
                serv = await getFieldServiceByPeriodAsync(deliveryDate, deliveryDate);
            }
            else
            {
                Console.WriteLine("Initialized Error: " + countPublishers + " publishers!");
            }

            if (i == 0)
            {
                Console.WriteLine("All Field Services of \"" + deliveryDate.ToString("MM/yyyy") + "\" already initialized!");
            }
            else
            {
                Console.WriteLine(i + " Field Service(s) of \"" + deliveryDate.ToString("MM/yyyy") + "\" initialized!");

            }


            return serv;
        }

        public bool VerifyExistFieldServiceByPublisher(DateTime deliveryDate, long publisherId)
        {
            return _dbContext.ServicoCampo.AsNoTracking().Any(e => e.DataEntrega == deliveryDate && e.PublicadorId == publisherId);
        }

        public async Task<double> getMediaFieldServiceAsync(long publisherId, int months)
        {
            var dataInicial = DateTime.Now.AddMonths(months);
            var dataReferencia = DateTime.Now.AddMonths(-1);

            DateTime dataR = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataInicial).Date;
            DateTime dateToday = DateTimeDayOfMonthExtensions.FirstDayOfMonth(dataReferencia).Date;


            var dateStartService = _publisherService.getStartFieldService(publisherId);

            var fieldService = this.getFieldServiceByPublisherIdAsync(publisherId);

            if (fieldService != null)
            {
                if (dataR < dateStartService)
                {
                    dataR = dateStartService;
                }

                var mediaH = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataReferencia >= dataR).Where(s => s.DataReferencia <= dateToday).Average(s => s.Horas).Value;
                var mediaHb = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataReferencia >= dataR).Where(s => s.DataReferencia <= dateToday).Average(s => s.HorasBetel);
                var mediaHc = _dbContext.ServicoCampo.AsNoTracking().Where(s => s.PublicadorId == publisherId).Where(s => s.DataReferencia >= dataR).Where(s => s.DataReferencia <= dateToday).Average(s => s.CreditoHoras);

                var media = (mediaH + mediaHb + mediaHc);

                var fst = _dbContext.ServicoCampot.Where(s => s.PublicadorId == publisherId).FirstOrDefaultAsync().Result;
                Console.WriteLine("Media3MonthsAsync Update List Count: " + fst.Horas);
                if (fst.Horas > 0)
                {
                    fst.Horas = mediaH;
                    fst.HorasBetel = mediaHb;
                    fst.CreditoHoras = mediaHc;
                    _dbContext.Update(fst);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Update");
                }
                else
                {
                    ServicoCampot sct = new ServicoCampot();
                    sct.PublicadorId = publisherId;
                    sct.Horas = mediaH;
                    sct.HorasBetel = mediaHb;
                    sct.CreditoHoras = mediaHc;
                    _dbContext.Add(sct);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Media3MonthsAsync Add");
                }

                return media;
            }
            // await Task.Delay(1000);
            return 0;
        }

        public async Task<List<ServicoCampo>> getFieldServiceByPeriodAsync(DateTime fromDate, DateTime toDate)
        {
            Console.WriteLine("getFieldServiceByPeriodAsync Service");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = await _dbContext.ServicoCampo.AsNoTracking().Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).Where(p => p.CongregacaoId == cong.Id).Where(e => e.DataReferencia >= fromDate).Where(e => e.DataReferencia <= toDate).OrderBy(s => s.Publicador.Nome).OrderByDescending(s => s.DataEntrega).ToListAsync();

            return serv;
        }

        public async Task<List<ServicoCampo>> getFieldServicePioneerByPeriodAsync(DateTime fromDate, DateTime toDate, long pioneerId)
        {

            Console.WriteLine("getFieldServicePioneerByPeriodAsync Service");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = await _dbContext.ServicoCampo.AsNoTracking()
            .Include(p => p.Pioneiro)
            .Include(p => p.Publicador)
            .Include(p => p.Congregacao)
            .Include(p => p.Pioneiro)
            .Include(p => p.Publicador.Dianteira)
            .Include(p => p.Publicador.Grupo)
            .Where(p => p.CongregacaoId == cong.Id)
            .Where(e => e.DataReferencia >= fromDate)
            .Where(e => e.DataReferencia <= toDate)
            .OrderBy(s => s.Publicador.Nome)
            .OrderByDescending(p => p.PioneiroId)
            .OrderByDescending(s => s.DataEntrega).ToListAsync();

            if (pioneerId > 0)
            {
                Console.WriteLine("============= 0 =============");
                serv = await _dbContext.ServicoCampo.AsNoTracking()
                .Include(p => p.Publicador)
                .Include(p => p.Congregacao)
                .Include(p => p.Pioneiro)
                .Include(p => p.Publicador.Dianteira)
                .Where(p => p.CongregacaoId == cong.Id)
                .Where(e => e.DataReferencia >= fromDate)
                .Where(e => e.DataReferencia <= toDate)
                .Where(p => p.PioneiroId == pioneerId)
                .OrderBy(s => s.Publicador.Nome)
                .OrderByDescending(p => p.PioneiroId)
                .OrderByDescending(s => s.DataEntrega).ToListAsync();
            }


            return serv;
        }

        public async Task<List<TotalFieldServiceReportDto>> getSumFieldServicePioneerByPeriodAsync(DateTime fromDate, DateTime toDate, long pioneerId)
        {
            Console.WriteLine("////////////// getSumFieldServicePioneerByPeriodAsync /////////////// ");

            Console.WriteLine("////////////// Parameters /////////////// " + fromDate + " - " + toDate + " - " + pioneerId);

            // var congDefault = _repoCong.getCongregationDefaultAsync();

            // Console.WriteLine("////////////// list /////////////// " + congDefault.Nome);

            var list = await _dbContext.ServicoCampo.AsNoTracking().Where(s => s.CongregacaoId == 1).Where(s => s.Horas > 0 || s.Minutos > 0).Where(s => s.DataEntrega == fromDate && s.DataReferencia == toDate).GroupBy(s => s.Pioneiro.Id).Select(
           t => new
           {
               description = t.Key,
               placements = t.Sum(s => s.Publicacoes),
               hours = t.Sum(s => s.Horas),
               hoursBetel = t.Sum(s => s.HorasBetel),
               credits = t.Sum(s => s.CreditoHoras),
               returns = t.Sum(s => s.Revisitas),
               studies = t.Sum(s => s.Estudos)
           }
           ).OrderByDescending(t => t.description).ToListAsync();


            // var list = await _dbContext.ServicoCampo.Where(s => s.CongregacaoId == 1).Where(s => s.Horas > 0 || s.Minutos > 0).Where(s => s.DataEntrega == fromDate && s.DataReferencia == toDate).GroupBy(t => new {t.Pioneiro.Descricao, t.Horas}).
            // Select(t => new
            // {
            //     description = t.Key, 
            //     horas = t.Sum(h => h.Horas)

            // }).ToListAsync();

            Console.WriteLine("////////////// list after /////////////// " + list.Count);

            List<TotalFieldServiceReportDto> sumReport = new List<TotalFieldServiceReportDto>();
            foreach (var item in list)
            {
                Console.WriteLine("Horas ========================== > " + item.description + " - " + item.placements + " - " + item.hours);
                // sumReport.Add(new TotalFieldServiceReportDto { description = item.description, colocations = item.placements.Value, hours = item.hours.Value, betelHours = item.hoursBetel, creditHours = item.credits, studies = item.studies.Value, returns = item.returns.Value });
            }

            return sumReport;
        }

        public async Task<List<ServicoCampo>> getMissingFieldServiceByPeriodAsync(DateTime fromDate, DateTime toDate)
        {
            Console.WriteLine("getMissingFieldServiceByPeriodAsync Service");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = await _dbContext.ServicoCampo.AsNoTracking().Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).Where(p => p.CongregacaoId == cong.Id).Where(g => g.Horas == 0 && g.HorasBetel == 0 && g.CreditoHoras == 0 && g.Minutos == 0).Where(e => e.DataReferencia >= fromDate).Where(e => e.DataReferencia <= toDate).OrderBy(s => s.Publicador.Nome).OrderByDescending(s => s.DataEntrega).ToListAsync();

            return serv;
        }
    }
}
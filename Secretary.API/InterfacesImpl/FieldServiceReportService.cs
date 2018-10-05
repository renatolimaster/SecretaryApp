using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
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
        public Task<List<ServicoCampo>> getAllFieldServicesAsync()
        {

            // ===============  Delimiter period of year field service ===================== //

            Console.WriteLine("getAllFieldServicesAsync 1");
            DateTime dtaRefIni = new DateTime(2018, 07, 01);
            DateTime dtaRefFim = new DateTime(2018, 07, 01);

            var congDefault = _repoCong.getCongregationDefaultAsync();

            var serv = _dbContext.ServicoCampo.Include(s => s.Congregacao).Include(s => s.Publicador).Include(s => s.Pioneiro).Where(x => x.Publicador.Congregacao.Equals(congDefault)).Where(s => s.DataEntrega >= dtaRefIni).Where(s => s.DataEntrega <= dtaRefFim).OrderBy(s => s.Publicador.Nome).OrderByDescending(s => s.DataEntrega).ToListAsync();

            Console.WriteLine("getAllFieldServicesAsync 2");
            return serv;
        }

        public Task<ServicoCampo> getFieldServiceAsync(long id)
        {
            Console.WriteLine("getFieldServiceAsync Service");

            var cong = _repoCong.getCongregationDefaultAsync();
            var serv = _dbContext.ServicoCampo.AsNoTracking().Where(p => p.CongregacaoId == cong.Id).Include(p => p.Pioneiro).Include(p => p.Publicador).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Publicador.Dianteira).FirstOrDefaultAsync(p => p.Id == id);

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

        public async Task<string> initializeFieldService(DateTime deliveryDate)
        {
            var i = 0;
            //var y = 0;
            var msg = "";
            var congDefault = _repoCong.getCongregationDefaultAsync();
            List<Publicador> publishers = _publisherService.getPublisherByCongregation(congDefault.Id);
            var countPublishers = publishers.Count;

            if (countPublishers > 0)
            {
                foreach (var item in publishers)
                {
                    if (!VerifyExistFieldServiceByPublisher(deliveryDate, item.Id))
                    {
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

                            _dbContext.Add(servicoCampo);
                            // await _dbContext.SaveChangesAsync();

                            //update publisher status, medias
                            var status = "";
                            status = await _publisherService.setPublisherStatusAsync(item.Id);
                            //medias
                            var media3 = await this.getMediaQuarterlyFieldServiceSAsync(item.Id);
                            var media6 = await this.getMediaSemesterFieldServiceAsync(item.Id);
                            var media12 = await this.getMediaYearlyFieldServiceAsync(item.Id);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            Console.WriteLine("InitializeFieldService Error");
                            return "Initialize Field Service Error!";
                        }
                        i++;
                    }
                }
            }
            else
            {
                return "Initialized Error: " + countPublishers + " publishers!";
            }

            if (i == 0)
            {
                msg = "All Field Services of \"" + deliveryDate.ToString("MM/yyyy") + "\" already initialized!";
            }
            else
            {
                msg = i + " Field Service(s) of \"" + deliveryDate.ToString("MM/yyyy") + "\" initialized!";
            }


            return msg;
        }

        public bool VerifyExistFieldServiceByPublisher(DateTime deliveryDate, long publisherId)
        {
            return _dbContext.ServicoCampo.AsNoTracking().Any(e => e.DataEntrega == deliveryDate && e.PublicadorId == publisherId);
        }
    }
}
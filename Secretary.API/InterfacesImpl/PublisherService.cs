using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Secretary.API.Data;
using Secretary.API.Helpers;
using Secretary.API.Interfaces;
using Secretary.API.Model;

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
    public async Task<IEnumerable<Publicador>> getAllPublishersAsync(long congregacaoId)
    {

      Console.WriteLine("================= getAllPublishersAsync IN =================");

      Console.WriteLine("Cong: " + congregacaoId);

      var pub = await _dbContext.Publicador.AsNoTracking().Include(p => p.Estado).Include(p => p.Dianteira).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.Grupo).OrderBy(p => p.Nome).Where(p => p.CongregacaoId == congregacaoId).ToListAsync();

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

      var pub = _dbContext.Publicador.AsNoTracking().Include(p => p.Situacao).Include(p => p.Dianteira).Include(p => p.Grupo).Include(p => p.Congregacao).Include(p => p.Pioneiro).Include(p => p.TipoLogradouro).Include(p => p.Country).Include(p => p.Estado).FirstOrDefaultAsync(p => p.Id == id);

      return pub;
    }

    public DateTime getStartFieldService(long publisherId)
    {
      var dateStartFieldService = _dbContext.Publicador.FirstOrDefaultAsync(p => p.Id == publisherId).Result;

      return dateStartFieldService.DataInicioServico.Value;
    }

    public List<Publicador> getPublisherByCongregation(long congregationId)
    {
      try
      {
        var publisher = _dbContext.Publicador.Where(m => m.CongregacaoId == congregationId).OrderBy(m => m.Nome);
        if (publisher == null)
        {
          return null;
        }
        else
        {
          var count = publisher.ToList().Count();
          return publisher.ToList();
        }
      }
      catch
      {
        Console.WriteLine("===== PublisherByCongregation Error ======");
      }

      return null;
    }

    public async Task<string> setPublisherStatusAsync(long publisherId)
    {
      string status = "";
      DateTime dataInicio = DateTimeDayOfMonthExtensions.FirstDayOfMonth(DateTime.Now);
      DateTime dataReferencia = DateTimeDayOfMonthExtensions.FirstDayOfMonth(DateTime.Now).AddMonths(-1);
      var publicadorInstance = this.getPublisherAsync(publisherId).Result;
      DateTime dataInicioServico = publicadorInstance.DataInicioServico.Value;
      LocalDate start = new LocalDate(dataInicioServico.Year, dataInicioServico.Month, dataInicioServico.Day);
      LocalDate end = new LocalDate(dataReferencia.Year, dataReferencia.Month, dataReferencia.Day);

      Console.WriteLine("Start: " + start + "    End: " + end);

      Period period = Period.Between(start, end, PeriodUnits.Months);
      Console.WriteLine("Period: " + period.Months.ToString()); // 16

      if (period.Months > 6)
      {
        Console.WriteLine("diferenca 1: Publ: " + publicadorInstance.Nome + dataReferencia.CompareTo(dataInicioServico) + " = R -> " + dataReferencia + " = R -> " + dataInicioServico);
        dataInicio = DateTimeDayOfMonthExtensions.FirstDayOfMonth(DateTime.Now).AddMonths(-6);
      }
      else
      {
        Console.WriteLine("diferenca 2: Publ: " + publicadorInstance.Nome + dataReferencia.CompareTo(dataInicioServico) + " = R -> " + dataReferencia + " = R -> " + dataInicioServico);
        dataInicio = new DateTime(start.Year, start.Month, start.Day);
      }

      var total = this.getMissingFieldService(publisherId, dataInicio, dataReferencia);

      if (total == 0)
      {
        status = "Regular";
      }
      else if (total >= 1 && total <= 6)
      {
        status = "Irregular";
      }
      else
      {
        status = "Inativo";
      }

      Console.WriteLine("status: " + status);

      List<Publicador> publ = _dbContext.Publicador.Where(p => p.Id == publisherId).ToList();
      try
      {
        if (publ.Count > 0)
        {
          publ[0].SituacaoServicoCampo = status;
          _dbContext.Update(publ[0]);
          await _dbContext.SaveChangesAsync();
        }
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!verifyPublicadorExists(publisherId))
        {
          return "Publisher " + publisherId + " not found!";
        }
        else
        {
          throw;
        }
      }
      Console.WriteLine("DefineStatus Status: " + publicadorInstance.Nome + " Status: " + status);

      return status;
    }

    public int getMissingFieldService(long publisherId, DateTime FromDate, DateTime ToDate)
    {
      Console.WriteLine("**** getMissingFieldService ****");
      Console.WriteLine("FromDate: " + FromDate + " - " + ToDate + " - Pbl: " + publisherId);
      int count = 0;
      count = _dbContext.ServicoCampo.Where(e => e.DataReferencia >= FromDate).Where(e => e.DataReferencia <= ToDate).Where(e => e.Horas == 0 && e.Minutos == 0 && e.HorasBetel == 0 && e.CreditoHoras == 0).Where(e => e.PublicadorId == publisherId).ToList().Count;

      Console.WriteLine("count ----------> " + count);

      return count;
    }

    public bool verifyPublicadorExists(long publisherId)
    {
      return _dbContext.Publicador.Any(e => e.Id == publisherId);
    }
  }
}
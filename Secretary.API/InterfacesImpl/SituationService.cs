using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
  public class SituationService : ISituationRepository
  {
    private readonly ApplicationDbContext _dbContext;
    public SituationService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<Situacao>> getAllSituationAsync(long congregationId)
    {
      Console.WriteLine("================= getAllSituationAsync =================");

      Console.WriteLine("Cong: " + congregationId);

      var sit = await _dbContext.Situacao.AsNoTracking().Where(s => s.CongregacaoId == congregationId).Where(s => s.Descricao != "Descricao").ToListAsync();

      return sit;
    }

    public async Task<Situacao> getSituationAsync(long id, long congregationId)
    {
      Console.WriteLine("================= getAllSituationAsync =================");

      Console.WriteLine("Cong: " + congregationId);

      var sit = await _dbContext.Situacao.AsNoTracking().Where(s => s.CongregacaoId == congregationId).FirstOrDefaultAsync();

      return sit;
    }
  }
}
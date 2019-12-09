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
  public class CongregationService : ICongregationRepository
  {
    private readonly ApplicationDbContext _dbContext;
    public CongregationService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Congregacao>> getAllCongregationsAsync()
    {
      Console.WriteLine("CongregationService getCongregationsAsync");
      ///
      /// PAY ATTENTION - Include has problem with circular reference
      /// add this to the ConfigureServices method of your startup.cs file:
      /// services.AddMvc().AddJsonOptions(options => 
      /// options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      /// in startup.cs 

      var cong = await _dbContext.Congregacao.Include(c => c.Estado).Include(c => c.Estado.Country).Include(c => c.Publicador).OrderBy(c => c.Nome).ToListAsync();

      cong.ForEach(element =>
      {
        Console.WriteLine(element.Id + " - " + element.Nome + " - " + element.Numero);
      });

      return cong;
    }

    public Task<Congregacao> getCongregationAsync(long id)
    {
      var cong = _dbContext.Congregacao.Include(c => c.Estado).Include(c => c.Estado.Country).Include(c => c.Publicador).FirstOrDefaultAsync(c => c.Id == id);

      return cong;
    }

    public Congregacao getCongregationDefaultAsync()
    {
      var cong = _dbContext.Congregacao.Include(c => c.Estado).Include(c => c.Estado.Country).Include(c => c.Publicador).FirstOrDefaultAsync(c => c.Padrao == true).Result;

      return cong;
    }


    public bool verifyExistCongregationByNumber(string congregationNumber)
    {
      Console.WriteLine("Congregation verifyExistCongregationByNumber");
      var back = _dbContext.Congregacao.Where(c => c.Numero == congregationNumber).ToListAsync();
      var count = back.Result.Count() > 0;

      return count;
    }

    public bool verifyExistCongregationByNumberState(string congregationNumber, long stateId)
    {
      Console.WriteLine("Congregation verifyExistCongregationByNumber");
      var back = _dbContext.Congregacao.Where(c => c.Numero == congregationNumber && c.EstadoId == stateId).ToListAsync();
      var count = back.Result.Count > 0;

      return count;
    }

    public async Task<bool> SaveAllAsync(Congregacao congregacao)
    {
      Console.WriteLine("SaveAllAsync");
      var back = await _dbContext.SaveChangesAsync() > 0;
      Console.WriteLine("Congregation SaveAllAsync: " + back);
      return back;
    }

    public void Add(Congregacao congregacao)
    {
      if (congregacao == null)
      {
        throw new ArgumentNullException("congregacao");
      }
      _dbContext.Add(congregacao);
    }

    public Task<Congregacao> getCongregationByUserAsync(long userId)
    {
      var user = _dbContext.Usuario.Where(u => u.Id == userId).FirstOrDefaultAsync().Result;
      Console.WriteLine("user: " + user.Username);
      var congregacao = _dbContext.Congregacao.Where(c => c.Id == user.CongregacaoId).FirstOrDefaultAsync();
      Console.WriteLine("congregacao: " + congregacao.Result.Nome);
      return congregacao;
    }

    public bool verifyExistCongregationByNumberDiffId(Congregacao congregation)
    {
      Console.WriteLine("Congregation verifyExistCongregationByNumberDiffId: " + congregation.Numero + " - " + congregation.Id);
      var back = _dbContext.Congregacao.Where(c => c.Numero == congregation.Numero && c.Id != congregation.Id).ToListAsync();
      Console.WriteLine("verifyExistCongregationByNumberDiffId back: " + back.Result.Count);
      return back.Result.Count > 0;
    }
  }
}
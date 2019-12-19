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
  public class GroupService : IGroupRepository
  {
    private readonly ApplicationDbContext _dbContext;

    public GroupService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Grupo>> getAllGroupsByCongregationAsync(long congregacaoId)
    {
      var groups = await _dbContext.Grupo.Include(c => c.Congregacao).OrderBy(g => g.Local).Where(g => g.CongregacaoId == congregacaoId).ToListAsync();
      return groups;
    }

    public async Task<Grupo> getGroupByCongregationAsync( long groupId, long congregacaoId)
    {
      Console.WriteLine("getGroupByCongregationAsync: " + congregacaoId + " " + groupId);
      var group = await _dbContext.Grupo.Include(c => c.Congregacao).Where(g => g.CongregacaoId == congregacaoId && g.Id == groupId).FirstOrDefaultAsync();
      return group;
    }
  }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Model;

namespace Secretary.API.Interfaces
{
  public interface ISituationRepository
  {
    Task<IEnumerable<Situacao>> getAllSituationAsync(long congregationId);
    Task<Situacao> getSituationAsync(long id, long congregationId);
  }
}
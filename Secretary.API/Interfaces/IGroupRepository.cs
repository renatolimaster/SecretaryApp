using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Model;

namespace Secretary.API.Interfaces
{
    public interface IGroupRepository
    {
    Task<List<Grupo>> getAllGroupsByCongregationAsync(long congregacaoId);
    Task<Grupo> getGroupByCongregationAsync( long groupId, long congregacaoId);
    // Task<Grupo> getGroupByUserAsync(long userId);
    // Grupo getGroupDefaultAsync();
    // bool verifyExistGroupByName(string congregationNumber);
    // bool verifyExistCongregationByNumberState(string congregationNumber, long stateId);
    // void Add(Grupo grupo);
    // Task<bool> SaveAllAsync(Grupo grupo);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publicador>> getAllPublishersAsync();
        Task<Publicador> getPublisherAsync(long id);
    }
}
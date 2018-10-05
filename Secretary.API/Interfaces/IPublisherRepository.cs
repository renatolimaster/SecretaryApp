using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publicador>> getAllPublishersAsync();
        Task<Publicador> getPublisherAsync(long id);
        DateTime getStartFieldService(long publisherId);
        List<Publicador> getPublisherByCongregation(long congregationId);
        Task<string> setPublisherStatusAsync(long publisherId);
        int getMissingFieldService(long publisherId, DateTime FromDate, DateTime ToDate);
        bool verifyPublicadorExists(long publisherId);
    }
}
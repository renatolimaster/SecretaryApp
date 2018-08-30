using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IFieldServiceRepository
    {
        Task<List<ServicoCampo>> getAllFieldServicesAsync();
        Task<ServicoCampo> getFieldServiceAsync(long id);
        Task<bool> SaveAll();
    }
}
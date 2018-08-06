using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IRepository<T> where T: class
    {        

        Task<T> Get(long id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAll();
    }
}
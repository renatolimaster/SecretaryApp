using System.Linq;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        IQueryable<T> GetQueryable(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
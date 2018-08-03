using System.Collections.Generic;
using System.Threading.Tasks;
using Secretary.API.Models;

namespace Secretary.API.Interfaces
{
    public interface IUserRepository
    {
        void AddUser<T>(T entity) where T : class;
        void DeleteUser<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Usuario>> GetUsers();
        Task<Usuario> GetUser(long id);
    }
}
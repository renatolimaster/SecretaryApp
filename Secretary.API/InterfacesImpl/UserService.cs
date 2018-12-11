using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.InterfacesImpl
{
    public class UserService : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {            
            _context = context;

        }

        public void AddUser<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void DeleteUser<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Usuario> GetUser(long id)
        {
            var user = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<Usuario> GetUserInclude(long id)
        {
            var user = await _context.Usuario.AsNoTracking().Include(u => u.Congregacao).Include(u => u.Publicador).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            var user = await _context.Usuario.AsNoTracking().Include(u => u.Congregacao).Include(u => u.Publicador).ToListAsync();

            return user;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
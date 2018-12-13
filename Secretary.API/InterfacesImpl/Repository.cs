using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class Repository<T> : IRepository<T> where T :  class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
 
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
 
 /*
        public async Task<T> Get(long id)
        {
            return await entities.FirstOrDefaultAsync(u => u.Id == id);
        }
 */
        public Task<bool> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            // SaveChange();
            return SaveAll();
        }
 
        public Task<bool> Update(T entity)
        {
            // Console.WriteLine("entity: " + entity);
            if (entity == null)
            {
                Console.WriteLine("entity: null");
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            // SaveChange();
            return SaveAll();
        }
 
        public Task<bool> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            // SaveChange();
            return SaveAll();
        }
        private void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
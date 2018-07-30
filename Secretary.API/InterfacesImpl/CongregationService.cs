using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.InterfacesImpl
{
    public class CongregationService : ICongregation
    {
        private readonly ApplicationDbContext _dbContext;
        public CongregationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Congregacao>> getAllCongregationsAsync()
        {
            Console.WriteLine("CongregationService getCongregationsAsync");
            ///
            /// PAY ATTENTION - Include has problem with circular reference
            /// add this to the ConfigureServices method of your startup.cs file:
            /// services.AddMvc().AddJsonOptions(options => 
            /// options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            /// in startup.cs 

            var cong = _dbContext.Congregacao.Include(c => c.Publicador).ToListAsync();

            return cong;
        }

        public Task<Congregacao> getCongregationAsync(long id)
        {
            var cong = _dbContext.Congregacao.FirstOrDefaultAsync(c => c.Id == id);

            return cong;
        }
    }
}
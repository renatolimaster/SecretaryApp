using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Secretary.API.Controllers
{
    [Route("api/[Controller]")]
    public class CongregationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        private IRepository<Congregacao> _repoCongregation;
        public CongregationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> getCongregationsAsync() {
            Console.WriteLine("getCongregationsAsync");

            ///
            /// PAY ATTENTION - Include has problem with circular reference
            /// add this to the ConfigureServices method of your startup.cs file:
            /// services.AddMvc().AddJsonOptions(options => 
            /// options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            /// in startup.cs 

            var cong = await _dbContext.Congregacao.Include(c => c.Publicador).ToListAsync();
            // await Task.Delay(1000);
            return Ok(cong);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCongregationAsync(int id) {
            Console.WriteLine("getCongregationAsync: " + id);
            var cong = await _dbContext.Congregacao.FirstOrDefaultAsync(g => g.Id == id);
            // await Task.Delay(1000);
            return Ok(cong);
        }

    }
}
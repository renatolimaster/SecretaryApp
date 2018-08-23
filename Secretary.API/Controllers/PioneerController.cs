using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Dtos;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PioneerController : ControllerBase
    {        
        // private readonly IRepository<Pioneiro> _repoPioneiro;
        private readonly IPioneerRepository _repoPioneer;
        private readonly IMapper _mapper;
        public PioneerController(IPioneerRepository repoPioneer, IMapper mapper)
        {
            _mapper = mapper;
            // _repoPioneiro = repoPioneiro;
            _repoPioneer = repoPioneer;

        }

        [HttpGet]
        public async Task<IActionResult> getPioneersAsync()
        {
            Console.WriteLine("getPioneersAsync");

            var pioneers = await _repoPioneer.getAllPioneersAsync();
            var pioneersToReturn = _mapper.Map<IEnumerable<PioneerForDetailDto>>(pioneers);

            return Ok(pioneersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPioneerAsync(long id)
        {
            Console.WriteLine("getPioneerAsync: " + id);
            var pioneer = await _repoPioneer.getPioneerAsync(id);
            var pioneerToReturn = _mapper.Map<PioneerForDetailDto>(pioneer);
            // await Task.Delay(1000);
            return Ok(pioneerToReturn);
        }
    }
}
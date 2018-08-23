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
    public class FieldServiceController : ControllerBase
    {
        private readonly IRepository<ServicoCampo> _repoFieldServiceRepository;
        private readonly IFieldServiceRepository _fieldServiceRepo;
        private readonly ICongregationRepository _congRepo;
        private readonly IMapper _mapper;

        public FieldServiceController(IFieldServiceRepository fieldServiceRepo, IRepository<ServicoCampo> repoFieldServiceRepository, ICongregationRepository congRepo, IMapper mapper)
        {
            _repoFieldServiceRepository = repoFieldServiceRepository;
            _fieldServiceRepo = fieldServiceRepo;
            _congRepo = congRepo;
            _mapper = mapper;
        }


        
        [HttpGet]
        public async Task<IActionResult> getAllFieldServicesAsync()
        {
            Console.WriteLine("getAllFieldServicesAsync");

            var servs = await _fieldServiceRepo.getAllFieldServicesAsync();
            var servsToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(servs);

            return Ok(servsToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> getFieldServiceAsync(long id)
        {
            Console.WriteLine("getFieldServiceAsync: " + id);
            var serv = await _fieldServiceRepo.getFieldServiceAsync(id);
            var servToReturn = _mapper.Map<FieldServiceForListDto>(serv);
            // await Task.Delay(1000);
            return Ok(servToReturn);
        }





    }
}
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
        private readonly IPublisherRepository _pubRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public FieldServiceController(IFieldServiceRepository fieldServiceRepo, IRepository<ServicoCampo> repoFieldServiceRepository, ICongregationRepository congRepo, IPublisherRepository pubRepo, IUserRepository userRepo, IMapper mapper)
        {
            _repoFieldServiceRepository = repoFieldServiceRepository;
            _fieldServiceRepo = fieldServiceRepo;
            _congRepo = congRepo;
            _pubRepo = pubRepo;
            _userRepo = userRepo;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReportAsync(long id, FieldServiceForUpdateDto fieldServiceForUpdateDto)
        {
            Console.WriteLine("UpdateReportAsync: " + id + " - " + fieldServiceForUpdateDto);

            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            // {                
            //     return Unauthorized();
            // }
            Console.WriteLine("publ ****************** 1: " + fieldServiceForUpdateDto.Publicador.Id + " - " + fieldServiceForUpdateDto.Publicador.Nome);

            Console.WriteLine("**************** cong 1 **************************");

            var cong = await _congRepo.getCongregationAsync(fieldServiceForUpdateDto.Congregacao.Id);

            Console.WriteLine("cong 2 : " + cong.Id + " - " + cong.Nome);

            if (cong == null)
            {
                throw new Exception($"Failed on save - congregation code {fieldServiceForUpdateDto.Congregacao.Id} doesn't exist!");
            }

            Console.WriteLine("cong 3 : " + cong.Id + " - " + cong.Nome);

            Console.WriteLine("publ ****************** 1: " + fieldServiceForUpdateDto.Publicador.Id + " - " + fieldServiceForUpdateDto.Publicador.Nome);

            var pub = await _pubRepo.getPublisherAsync(fieldServiceForUpdateDto.Publicador.Id);

            if (pub == null)
            {
                throw new Exception($"Failed on save - publisher code {fieldServiceForUpdateDto.Publicador.Id} doesn't exist!");
            }

            Console.WriteLine("publ ****************** 2: " + pub.Id + " - " + pub.Nome);

            var reportFromRepo = await _fieldServiceRepo.getFieldServiceAsync(id);

            _mapper.Map(fieldServiceForUpdateDto, reportFromRepo);

            Console.WriteLine("fieldServiceForUpdateDto 2: " + reportFromRepo.Id + " - " + reportFromRepo.DataReferencia + " - " + reportFromRepo.CreditoHoras + " - " + reportFromRepo.HorasBetel + " - " + reportFromRepo.Congregacao.Nome + " - " + reportFromRepo.Publicador.Nome);

            if (await _fieldServiceRepo.SaveAll())
                return NoContent();

            throw new Exception($"Updating field service {id} failed on save!");
            // return Ok();

        }



    }
}
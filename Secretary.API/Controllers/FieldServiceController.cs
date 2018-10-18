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
            Console.WriteLine("**** getAllFieldServicesAsync ****");

            var servs = await _fieldServiceRepo.getAllFieldServicesAsync();
            var servsToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(servs);

            return Ok(servsToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> getFieldServiceAsync(long id)
        {
            Console.WriteLine("**** getFieldServiceAsync ****: " + id);
            var serv = await _fieldServiceRepo.getFieldServiceAsync(id);
            var servToReturn = _mapper.Map<FieldServiceForListDto>(serv);
            // await Task.Delay(1000);
            return Ok(servToReturn);
        }

        [HttpGet("initialize/{deliveryDate}")]
        public async Task<IActionResult> initializeFieldServiceAsync(DateTime deliveryDate)
        {
            Console.WriteLine("**** initializeFieldServiceAsync ****: " + deliveryDate);
            var serv = await _fieldServiceRepo.initializeFieldService(deliveryDate.Date);
            Console.WriteLine(serv);
            // await Task.Delay(1000);
            return Ok(serv);
        }

        [HttpGet("byperiod/{fromDate}&{toDate}")]
        public async Task<IActionResult> getFieldServiceByPeriodAsync(DateTime fromDate, DateTime toDate)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date;
            Console.WriteLine("**** getFieldServiceByPeriodAsync ****: " + fromDate + " - " + toDate);
            var serv = await _fieldServiceRepo.getFieldServiceByPeriodAsync(fromDate, toDate);
            var servToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(serv);
            // await Task.Delay(1000);
            return Ok(servToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReportAsync(long id, FieldServiceForUpdateDto fieldServiceForUpdateDto)
        {
            Console.WriteLine("UpdateReportAsync: " + id + " - " + fieldServiceForUpdateDto.CongregacaoId);

            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            // {                
            //     return Unauthorized();
            // }
            // Console.WriteLine("publ ****************** 1: " + fieldServiceForUpdateDto.Publicador.Id);

            Console.WriteLine("**************** cong 1 **************************");

            var cong = await _congRepo.getCongregationAsync(fieldServiceForUpdateDto.CongregacaoId);

            Console.WriteLine("cong 2 : " + cong.Id + " - " + cong.Nome);

            if (cong == null)
            {
                throw new Exception($"Failed on save - congregation code {fieldServiceForUpdateDto.CongregacaoId} doesn't exist!");
            }

            // Console.WriteLine("cong 3 : " + cong.Id + " - " + cong.Nome);

            // Console.WriteLine("publ ****************** 1: " + fieldServiceForUpdateDto.Publicador.Id);

            var pub = await _pubRepo.getPublisherAsync(fieldServiceForUpdateDto.PublicadorId);

            if (pub == null)
            {
                throw new Exception($"Failed on save - publisher code {fieldServiceForUpdateDto.PublicadorId} doesn't exist!");
            }

            // Console.WriteLine("publ ****************** 2: " + pub.Id + " - " + pub.Nome);

            // ServicoCampo reportFromRepo = new ServicoCampo();            

            var reportFromRepo = await _fieldServiceRepo.getSCSingleOrDefaultAsync(id);

            if (Object.Equals(fieldServiceForUpdateDto, reportFromRepo)) {
                throw new Exception("No change amde!");
            }


            // Date: para evitar timezone
            fieldServiceForUpdateDto.DataEntrega = fieldServiceForUpdateDto.DataEntrega.Date;
            fieldServiceForUpdateDto.DataReferencia = fieldServiceForUpdateDto.DataReferencia.Date;
            fieldServiceForUpdateDto.MesReferencia = fieldServiceForUpdateDto.DataReferencia.Month;
            fieldServiceForUpdateDto.AnoReferencia = fieldServiceForUpdateDto.DataReferencia.Year;


            Console.WriteLine("reportFromRepo ----------------------->: " + fieldServiceForUpdateDto.DataEntrega + " - " + fieldServiceForUpdateDto.Horas);

            _mapper.Map(fieldServiceForUpdateDto, reportFromRepo);

            // Console.WriteLine("fieldServiceForUpdateDto 3: " + reportFromRepo.Horas + " - " + reportFromRepo.VideosMostrados + " - " + reportFromRepo.Minutos + " - " +reportFromRepo.HorasBetel + " - " +reportFromRepo.CreditoHoras + " - " + reportFromRepo.Estudos + " - " + reportFromRepo.Revisitas + " - " + reportFromRepo.Publicacoes);

            Console.WriteLine("Save: " + reportFromRepo.Id + " - " + reportFromRepo.PublicadorId);

            if (await _fieldServiceRepo.SaveAllAsync())
            {
                if (fieldServiceForUpdateDto.Horas > 0)
                {
                    // var media = _fieldServiceRepo.getMediaFieldServiceAsync(reportFromRepo.PublicadorId);
                    //update publisher status, medias
                    var status = "";
                    status = await _pubRepo.setPublisherStatusAsync(reportFromRepo.PublicadorId);
                    //medias                    
                    var media3 = await _fieldServiceRepo.getMediaFieldServiceAsync(reportFromRepo.PublicadorId, -3);
                    var media6 = await _fieldServiceRepo.getMediaFieldServiceAsync(reportFromRepo.PublicadorId, -6);
                    var media12 = await _fieldServiceRepo.getMediaFieldServiceAsync(reportFromRepo.PublicadorId, -12);
                    Console.WriteLine("Horas: " + fieldServiceForUpdateDto.Horas + " - status: " + status);
                }
                return NoContent();
            }


            throw new Exception($"Updating field service {id} failed on save!");
            // return Ok();

        }


    }
}
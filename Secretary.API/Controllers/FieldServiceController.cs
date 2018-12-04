using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Dtos;
using Secretary.API.Helpers;
using Secretary.API.Interfaces;
using Secretary.API.Models;

namespace Secretary.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FieldServiceController : ControllerBase
    {
        private readonly IRepository<ServicoCampo> _repo;
        private readonly IFieldServiceRepository _fieldServiceRepo;
        private readonly ICongregationRepository _congRepo;
        private readonly IPublisherRepository _pubRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public FieldServiceController(IFieldServiceRepository fieldServiceRepo, IRepository<ServicoCampo> repo, ICongregationRepository congRepo, IPublisherRepository pubRepo, IUserRepository userRepo, IMapper mapper, IEmailService emailService)
        {
            _emailService = emailService;
            _repo = repo;
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

        [HttpGet("missingfieldservicemail/{referenceDate}")]
        public async Task<IActionResult> missingFieldServiceAsync(DateTime referenceDate)
        {
            Console.WriteLine("**** initializeFieldServiceAsync ****: " + referenceDate);
            var serv = await _fieldServiceRepo.getMissingFieldServiceByPeriodAsync(referenceDate.Date, referenceDate.Date);
            var servToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(serv);
            var publisherName = "";

            if (serv.Count > 0)
            {
                EmailAddress to = new EmailAddress();
                EmailAddress from = new EmailAddress();
                EmailAddress cc = new EmailAddress();
                to.Name = "Renato";
                from.Name = "Renato";
                from.Address = "fsr.vec@gmail.com";
                cc.Name = "Renato";
                cc.Address = "renatolimaster@gmail.com";
                EmailMessage msg = new EmailMessage();

                foreach (var item in serv)
                {                    
                    publisherName = item.Publicador.Nome.Split(' ')[0] + " "  + item.Publicador.Nome.Split(' ')[item.Publicador.Nome.Split(' ').Length - 1];
                    
                    to.Name = publisherName;
                    to.Address = item.Publicador.Email;

                    msg.ToAddresses.Add(to);
                    msg.FromAddresses.Add(from);
                    msg.Cc.Add(cc);
                    
                    msg.Subject = "Field Service Report";
                    msg.Content = "<div class='container'> <div class='row'> <div class='col-xs-12 col-md-12 mt-3'> <h4 class='text-primary'>Congregation's Report</h4><hr></div></div></div>";


                    msg.Content += "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">";
                    msg.Content += "<head>";
                    msg.Content += "<meta content=\"text / html; charset = ISO - 8859 - 1\" http-equiv=\"content - type\">";
                    msg.Content += "<title>Field Service Report</title>";

                    msg.Content += "</head>";

                    msg.Content += "<html>";
                    msg.Content += "<body>";
                    msg.Content += "<table>";
                    msg.Content += "<tbody>";

                    msg.Content += "<tr>";
                    msg.Content += "<td> &nbsp;</td>";
                    msg.Content += "<td> &nbsp;</td>";
                    msg.Content += "</tr>";

                    msg.Content += "<tr>";
                    msg.Content += "<td style = \"width: 60px;\"> &nbsp;</td>";
                    msg.Content += "<td style = \"width: 992px;\"> Hi dear " + to.Name + ",</td>";
                    msg.Content += "</tr>";
                    msg.Content += "<tr>";
                    msg.Content += "<td style = \"width: 60px;\"> &nbsp;</td>";
                    msg.Content += "<td style = \"width: 992px;\"> &nbsp;<br>";
                    msg.Content += "We know that this wicked system has made us more and more busy, but I would like to remind you ";
                    msg.Content += "to send your field service report to fsr.vec@gmail.com as soon as possible, please.<br><br>";
                    msg.Content += "Please remember that we have a deadline to send to Bethel.<br><br>";
                    msg.Content += "May Jehovah continue to bless your efforts for the Kingdom.<br><br><br><br>";
                    msg.Content += "Thank you so much!<br><br><br>";
                    msg.Content += "Your brother and coworker of,<br><br>";
                    msg.Content += "Vit&oacute;ria English Congregation.</td>";
                    msg.Content += "</tr>";
                    msg.Content += "</tbody>";
                    msg.Content += "</table>";
                    msg.Content += "<br>";
                    msg.Content += "</body>";
                    msg.Content += "</html>";

                    _emailService.Send(msg);
                    Console.WriteLine(serv);

                }

            }




            // await Task.Delay(1000);
            return Ok(servToReturn);
        }

        [HttpGet("initialize/{referenceDate}")]
        public async Task<IActionResult> initializeFieldServiceAsync(DateTime referenceDate)
        {
            Console.WriteLine("**** initializeFieldServiceAsync ****: " + referenceDate);                        
            var serv = await _fieldServiceRepo.initializeFieldService(referenceDate.Date);            
            var servToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(serv);            
            Console.WriteLine(serv);
            // await Task.Delay(1000);
            return Ok(servToReturn);
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

        [HttpGet("fieldservicebypublisheridperiod/{fromDate}&{toDate}&{publisherId}")]
        public async Task<IActionResult> getFieldServiceByPublisherIdPeriodAsync(DateTime fromDate, DateTime toDate, long publisherId)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date;
            Console.WriteLine("**** getFieldServiceByPublisherIdPeriodAsync ****: " + fromDate + " - " + toDate + " - " + publisherId);
            var serv = await _fieldServiceRepo.getFieldServiceByPublisherIdPeriodAsync(fromDate, toDate, publisherId);
            var servToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(serv);
            // await Task.Delay(1000);
            return Ok(servToReturn);
        }

        [HttpGet("pioneerfieldservicebyperiod/{fromDate}&{toDate}&{pioneerId}")]
        public async Task<IActionResult> getPioneerFieldServiceByPeriodAsync(DateTime fromDate, DateTime toDate, long pioneerId)
        {
            fromDate = fromDate.Date;
            toDate = toDate.Date;
            Console.WriteLine("**** getPioneerFieldServiceByPeriodAsync ****: " + fromDate + " - " + toDate);
            var serv = await _fieldServiceRepo.getFieldServicePioneerByPeriodAsync(fromDate, toDate, pioneerId);
            var servToReturn = _mapper.Map<IEnumerable<FieldServiceForListDto>>(serv);

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

            ServicoCampo reportFromRepo = _fieldServiceRepo.getFieldServiceAsync(id).Result;

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

            if (Object.Equals(fieldServiceForUpdateDto, reportFromRepo))
            {
                throw new Exception("No change made!");
            }


            // Date: para evitar timezone
            fieldServiceForUpdateDto.Id = id;
            fieldServiceForUpdateDto.DataEntrega = fieldServiceForUpdateDto.DataEntrega.Date;
            fieldServiceForUpdateDto.DataReferencia = fieldServiceForUpdateDto.DataReferencia.Date;
            fieldServiceForUpdateDto.MesReferencia = fieldServiceForUpdateDto.DataReferencia.Month;
            fieldServiceForUpdateDto.AnoReferencia = fieldServiceForUpdateDto.DataReferencia.Year;


            Console.WriteLine("reportFromRepo ----------------------->: " + fieldServiceForUpdateDto.DataEntrega + " - " + fieldServiceForUpdateDto.Horas);

            // _mapper.Map(fieldServiceForUpdateDto, reportFromRepo);

            // Console.WriteLine("fieldServiceForUpdateDto 3: " + reportFromRepo.Horas + " - " + reportFromRepo.VideosMostrados + " - " + reportFromRepo.Minutos + " - " +reportFromRepo.HorasBetel + " - " +reportFromRepo.CreditoHoras + " - " + reportFromRepo.Estudos + " - " + reportFromRepo.Revisitas + " - " + reportFromRepo.Publicacoes);

            Console.WriteLine("Save: " + fieldServiceForUpdateDto.Id + " - " + reportFromRepo.Id + " - " + reportFromRepo.Horas + " - " + reportFromRepo.PioneiroId);

            var servicoCampo = new ServicoCampo();

            _mapper.Map(fieldServiceForUpdateDto, servicoCampo);

            Console.WriteLine("Save: " + fieldServiceForUpdateDto.Id + " - " + reportFromRepo.Id + " - " + reportFromRepo.Horas + " - " + reportFromRepo.PioneiroId);

            
            if (await _repo.Update(servicoCampo))
            {
                Console.WriteLine("Horas: " + servicoCampo.Horas);
                if (servicoCampo.Horas > 0)
                {
                    // var media = _fieldServiceRepo.getMediaFieldServiceAsync(reportFromRepo.PublicadorId);
                    //update publisher status, medias
                    var status = "";
                    status = await _pubRepo.setPublisherStatusAsync(servicoCampo.PublicadorId);
                    //medias                    
                    var media3 = await _fieldServiceRepo.getMediaFieldServiceAsync(servicoCampo.PublicadorId, -3);
                    var media6 = await _fieldServiceRepo.getMediaFieldServiceAsync(servicoCampo.PublicadorId, -6);
                    var media12 = await _fieldServiceRepo.getMediaFieldServiceAsync(servicoCampo.PublicadorId, -12);
                    Console.WriteLine("Horas: " + fieldServiceForUpdateDto.Horas + " - status: " + status);
                    return Ok(reportFromRepo);
                }
            }
             

            // await Task.Delay(1000);
            throw new Exception($"Updating field service {id} failed on save!");
            // return Ok();

        }


    }
}
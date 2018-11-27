using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Secretary.API.Dtos;
using System.Security.Claims;

namespace Secretary.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CongregationController : ControllerBase
    {
        private readonly ICongregationRepository _repoCongregation;
        private readonly IMapper _mapper;
        public CongregationController(ICongregationRepository repoCongregation, IMapper mapper)
        {
            _mapper = mapper;
            _repoCongregation = repoCongregation;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getCongregationsAsync()
        {
            Console.WriteLine("getCongregationsAsync");

            var cong = await _repoCongregation.getAllCongregationsAsync();
            var congToReturn = _mapper.Map<IEnumerable<CongregationForListDto>>(cong);

            return Ok(congToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetCongregation")]
        public async Task<IActionResult> getCongregationAsync(long id)
        {
            Console.WriteLine("getCongregationAsync: " + id);
            var cong = await _repoCongregation.getCongregationAsync(id);
            // await Task.Delay(1000);
            var congToReturn = _mapper.Map<IEnumerable<CongregationForListDto>>(cong);

            return Ok(congToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCongregationAsync(CongregationForCreateDto congregationForCreateDto)
        {
            // Console.WriteLine("CreateCongregationAsync: " + congregationForCreateDto);

            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            // {                
            //     return Unauthorized();
            // }

            var congByNumber = _repoCongregation.verifyExistCongregationByNumber(congregationForCreateDto.Numero);
            Console.WriteLine(congByNumber);
            if (congByNumber)
            {
                throw new Exception($"Failed on save - congregation {congregationForCreateDto.Numero} number already exist!");
            }

            var congByNumberState = _repoCongregation.verifyExistCongregationByNumberState(congregationForCreateDto.Numero, congregationForCreateDto.EstadoId);
            Console.WriteLine(congByNumberState);
            if (congByNumber)
            {
                throw new Exception($"Failed on save - congregation number {congregationForCreateDto.Numero} for state {congregationForCreateDto.EstadoId} already exist!");
            }

            var congregationRepo = new Congregacao();

            // _mapper.Map<Congregacao>(congregationForCreateDto);
            _mapper.Map(congregationForCreateDto, congregationRepo);

            _repoCongregation.Add(congregationRepo);

            if (await _repoCongregation.SaveAllAsync(congregationRepo)){
                Console.WriteLine("creating congregation.");
                // var congToReturn = _mapper.Map<Congregacao>(congregationForCreateDto);
                // return CreatedAtRoute("GetCongregation", new { id = congregationForCreateDto.Id}, congToReturn);
            } else {
                Console.WriteLine("Erro creating congregation.");
            }

            // await Task.Delay(1000);
            // return Ok(congByNumber);

            return BadRequest("Could not create congregation!");

        }


    }
}
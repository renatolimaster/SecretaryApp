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
        [HttpGet("{id}")]
        public async Task<IActionResult> getCongregationAsync(long id)
        {
            Console.WriteLine("getCongregationAsync: " + id);
            var cong = await _repoCongregation.getCongregationAsync(id);
            // await Task.Delay(1000);
            return Ok(cong);
        }


    }
}
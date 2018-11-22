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
    public class EstadoController : ControllerBase
    {
        private readonly ICongregationRepository _repoCongregation;
        private readonly IStateRepository _repoState;
        private readonly IMapper _mapper;
        public EstadoController(ICongregationRepository repoCongregation, IStateRepository repoSate, IMapper mapper)
        {
            _mapper = mapper;
            _repoCongregation = repoCongregation;
            _repoState = repoSate;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getStatesAsync()
        {
            Console.WriteLine("getCongregationsAsync");

            var states = await _repoState.GetStates();
            var statesToReturn = _mapper.Map<IEnumerable<StateForListDto>>(states);

            return Ok(statesToReturn);
        }

        [AllowAnonymous]
        [HttpGet("statesbycountry/{id}")]
        public async Task<IActionResult> GetStatesByCountryAsync(long id)
        {
            Console.WriteLine("statesbycountry");

            var states = await _repoState.GetStatesByCountry(id);
            var statesToReturn = _mapper.Map<IEnumerable<StateForListDto>>(states);

            return Ok(statesToReturn);
        }

    }
}
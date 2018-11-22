using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Dtos;
using Secretary.API.Interfaces;

namespace Secretary.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLogradouroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITipoLogradouroRepository _repoTipo;
        public TipoLogradouroController(ITipoLogradouroRepository repoTipo, IMapper mapper)
        {
            _mapper = mapper;
            _repoTipo = repoTipo;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> getTipoAsync(long id)
        {
            Console.WriteLine("getTipoAsync");

            var tipo = await _repoTipo.GetTipo(id);
            var tipoToReturn = _mapper.Map<TipoLogradouroForListDto>(tipo);

            return Ok(tipoToReturn);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getTiposAsync()
        {
            Console.WriteLine("getTiposAsync");

            var tipos = await _repoTipo.GetTipos();
            var tiposToReturn = _mapper.Map<IEnumerable<TipoLogradouroForListDto>>(tipos);

            return Ok(tiposToReturn);
        }

    }
}
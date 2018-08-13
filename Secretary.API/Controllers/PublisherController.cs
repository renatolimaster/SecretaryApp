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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repoPublisher;
        private readonly IRepository<Publicador> _repoUsuario;
        private readonly ICongregationRepository _congRepo;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository repoPublisher, IRepository<Publicador> repoUsuario, ICongregationRepository congRepo,IMapper mapper)
        {
            _repoPublisher = repoPublisher;
            _repoUsuario = repoUsuario;
            _congRepo = congRepo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getPublishersAsync()
        {
            Console.WriteLine("getPublishersAsync");

            var pubs = await _repoPublisher.getAllPublishersAsync();
            var pubsToReturn = _mapper.Map<IEnumerable<PublisherForListDto>>(pubs);

            return Ok(pubsToReturn);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> getPublisherAsync(long id)
        {
            Console.WriteLine("getPublisherAsync: " + id);
            var pub = await _repoPublisher.getPublisherAsync(id);
            var pubToReturn = _mapper.Map<PublisherForDetailsDto>(pub);
            // await Task.Delay(1000);
            return Ok(pubToReturn);
        }

        
    }
}
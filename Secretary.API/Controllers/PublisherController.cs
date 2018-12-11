using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Dtos;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repoPublisher;
        private readonly ICongregationRepository _congRepo;
        private readonly IUserRepository _repoUsuario;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository repoPublisher, IUserRepository repoUsuario, ICongregationRepository congRepo,IMapper mapper)
        {
            _repoPublisher = repoPublisher;
            _congRepo = congRepo;
            _repoUsuario = repoUsuario;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getPublishersAsync()
        {
            Console.WriteLine("getPublishersAsync");

            var userLoged = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _repoUsuario.GetUser(Convert.ToInt64(userLoged)).Result;

            Console.WriteLine("User: " + user.CongregacaoId);
            
            var pubs = await _repoPublisher.getAllPublishersAsync(user.CongregacaoId.Value);
            var pubsToReturn = _mapper.Map<IEnumerable<PublisherForListDto>>(pubs);

            return Ok(pubsToReturn);
        }

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
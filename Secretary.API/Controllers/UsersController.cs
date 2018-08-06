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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repoUser;
        private readonly IRepository<Usuario> _repoUsuario;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repoUser, IRepository<Usuario> repoUsuario, IMapper mapper)
        {
            _mapper = mapper;
            _repoUsuario = repoUsuario;
            _repoUser = repoUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repoUser.GetUsers();
            
            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _repoUser.GetUserInclude(id);

            var userToReturn = _mapper.Map<UserForDetailsDto>(user);

            return Ok(userToReturn);
        }

    }
}
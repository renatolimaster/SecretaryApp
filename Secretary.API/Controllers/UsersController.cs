using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Interfaces;

namespace Secretary.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repoUser;
        public UsersController(IUserRepository repoUser)
        {
            _repoUser = repoUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() 
        {
            var users = await _repoUser.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = await _repoUser.GetUser(id);
            return Ok(user);
        }

    }
}
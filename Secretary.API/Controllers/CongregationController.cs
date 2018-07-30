using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Secretary.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CongregationController : ControllerBase
    {
        private readonly ICongregation _repoCongregation;
        public CongregationController(ICongregation repoCongregation)
        {
            _repoCongregation = repoCongregation;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> getCongregationsAsync()
        {
            Console.WriteLine("getCongregationsAsync");

            var cong = await _repoCongregation.getAllCongregationsAsync();

            return Ok(cong);
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
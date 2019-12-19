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
  public class CountryController : ControllerBase
  {
    private readonly ICountryRepository _repoCountry;
    private readonly IMapper _mapper;
    public CountryController(ICountryRepository repoCountry, IMapper mapper)
    {
      _mapper = mapper;
      _repoCountry = repoCountry;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> getCountiesAsync()
    {
      Console.WriteLine("getCountiesAsync");

      var countries = await _repoCountry.GetCountriesAsync();
      var countriesToReturn = _mapper.Map<IEnumerable<CountryForListDto>>(countries);

      return Ok(countriesToReturn);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountryAsync(long id)
    {
      Console.WriteLine("GetCountryAsync");

      var country = await _repoCountry.GetCountryAsync(id);
      var countryToReturn = _mapper.Map<CountryForListDto>(country);

      return Ok(countryToReturn);
    }

    [AllowAnonymous]
    [HttpGet("search/{search}")]
    public async Task<IActionResult> GetCountryByNameAsync(string search)
    {
      Console.WriteLine("GetCountryByNameAsync");

      var country = await _repoCountry.GetCountryByNameAsync(search);
      var countryToReturn = _mapper.Map<CountryForListDto>(country);

      return Ok(countryToReturn);
    }

    [AllowAnonymous]
    [HttpGet("searches/{search}")]
    public async Task<IActionResult> GetCountriesByNameAsync(string search)
    {
      Console.WriteLine("GetCountriesByNameAsync");

      var countries = await _repoCountry.GetCountriesByNameAsync(search);
      
      var countriesToReturn = _mapper.Map<IEnumerable<CountryForListDto>>(countries);

      return Ok(countriesToReturn);
    }


  }
}
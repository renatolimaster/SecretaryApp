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
  public class SituationController : ControllerBase
  {
    private readonly ISituationRepository _repoSituation;
    private readonly ICongregationRepository _congRepo;
    private readonly IMapper _mapper;
    public SituationController(ISituationRepository repoSituation, ICongregationRepository congRepo, IMapper mapper)
    {
      _repoSituation = repoSituation;
      _congRepo = congRepo;
      _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet("{id}&{congregationId}")]
    public async Task<IActionResult> getSituationAsync(long id, long congregationId)
    {
      Console.WriteLine("getSituationAsync: " + id);
      var sit = await _repoSituation.getSituationAsync(id, congregationId);
      var sitToReturn = _mapper.Map<SituationForDetailDto>(sit);
      // await Task.Delay(1000);
      return Ok(sitToReturn);
    }

    [AllowAnonymous]
    [HttpGet("{congregationId}")]
    public async Task<IActionResult> getAllSituationAsync(long congregationId)
    {
      Console.WriteLine("getAllSituationAsync: " + congregationId);
      var sit = await _repoSituation.getAllSituationAsync(congregationId);
      var sitToReturn = _mapper.Map<IEnumerable<SituacaoForListDto>>(sit);
      // await Task.Delay(1000);
      return Ok(sitToReturn);
    }

  }
}
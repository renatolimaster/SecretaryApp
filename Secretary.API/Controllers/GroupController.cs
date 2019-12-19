
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Dtos;
using Secretary.API.Helpers;
using Secretary.API.Interfaces;
using Secretary.API.Model;

namespace Secretary.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
    public class GroupController : ControllerBase
    {

    private readonly IGroupRepository _repoGroup;
    private readonly IMapper _mapper;

    public GroupController(IGroupRepository repoGroup, IMapper mapper)
    {
        _mapper = mapper;
        _repoGroup = repoGroup;
    }

    [AllowAnonymous]
    [HttpGet("allgroupscongregation/{congregationId}")]
    public async Task<IActionResult> allGroupsByCongregationAsync(long congregationId)
    {
      Console.WriteLine("getAllGroupsByCongregationAsync");

      var groups = await _repoGroup.getAllGroupsByCongregationAsync(congregationId);
      var groupsToReturn = _mapper.Map<IEnumerable<GroupSimplifiedDto>>(groups);

      return Ok(groupsToReturn);
    }

    [AllowAnonymous]
    [HttpGet("bygroupandcongregation/{groupId}&{congregationId}")]
    public async Task<IActionResult> byGroupAndCongregationAsync(long groupId, long congregationId)
    {
      Console.WriteLine("getGroupByCongregationAsync");

      var group = await _repoGroup.getGroupByCongregationAsync(groupId, congregationId);
      var groupToReturn = _mapper.Map<GroupSimplifiedDto>(group);

      return Ok(groupToReturn);
    }


  }
}
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Secretary.API.Data;
using Secretary.API.Interfaces;
using Secretary.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Secretary.API.Dtos;
using System.Security.Claims;

namespace Secretary.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class CongregationController : ControllerBase
  {
    private readonly IRepository<Congregacao> _repo;
    private readonly ICongregationRepository _repoCongregation;
    private readonly IMapper _mapper;

    public CongregationController(IRepository<Congregacao> repo, ICongregationRepository repoCongregation, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
      _repoCongregation = repoCongregation;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> getCongregationsAsync()
    {
      Console.WriteLine("getCongregationsAsync: " + int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

      var cong = await _repoCongregation.getAllCongregationsAsync();
      var congToReturn = _mapper.Map<IEnumerable<CongregationForListDto>>(cong);

      Console.WriteLine("getCongregationsAsync: " + congToReturn);

      return Ok(congToReturn);
    }

    [AllowAnonymous]
    [HttpGet("{id}", Name = "GetCongregation")]
    public async Task<IActionResult> getCongregationAsync(long id)
    {
      Console.WriteLine("getCongregationAsync: " + int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));

      var congregationStandard = _repoCongregation.getCongregationByUserAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Result;

      Console.WriteLine("Padrao: " + congregationStandard.Id + " - " + congregationStandard.Nome + " - " + congregationStandard.Padrao);


      var cong = await _repoCongregation.getCongregationAsync(id);
      // await Task.Delay(1000);
      var congToReturn = _mapper.Map<CongregationForListDto>(cong);

      return Ok(congToReturn);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCongregationAsync(CongregationForCreateDto congregationForCreateDto)
    {
      Console.WriteLine("CreateCongregationAsync: " + congregationForCreateDto);

      var congByNumber = _repoCongregation.verifyExistCongregationByNumber(congregationForCreateDto.Numero);
      Console.WriteLine(congByNumber);
      if (congByNumber)
      {
        throw new Exception($"Failed on save - congregation {congregationForCreateDto.Numero} number already exist!");
      }

      var congByNumberState = _repoCongregation.verifyExistCongregationByNumberState(congregationForCreateDto.Numero, congregationForCreateDto.EstadoId);
      Console.WriteLine(congByNumberState);
      if (congByNumber)
      {
        throw new Exception($"Failed on save - congregation number {congregationForCreateDto.Numero} for state {congregationForCreateDto.EstadoId} already exist!");
      }

      var congDefault = _repoCongregation.getCongregationDefaultAsync();

      if (congregationForCreateDto.Padrao)
      {
        throw new Exception($"Failed on save congregation number {congregationForCreateDto.Numero} because standard congregation already set!");
      }

      var congregationStandard = _repoCongregation.getCongregationByUserAsync(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)).Result;

      Console.WriteLine("Padrao: " + congregationStandard.Id + " - " + congregationStandard.Nome + " - " + congregationStandard.Padrao);

      var congregationRepo = new Congregacao();

      // _mapper.Map<Congregacao>(congregationForCreateDto);
      _mapper.Map(congregationForCreateDto, congregationRepo);

      congregationRepo.AuditoriaUsuario = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

      _repoCongregation.Add(congregationRepo);

      if (await _repo.Add(congregationRepo))
      {
        Console.WriteLine("creating congregation: " + congregationRepo.Id);
        // var congToReturn = _mapper.Map<Congregacao>(congregationForCreateDto);
        // return CreatedAtRoute("GetCongregation", new { id = congregationForCreateDto.Id}, congToReturn);
        // return NoContent();
        return Ok(congregationRepo);
      }
      else
      {
        Console.WriteLine("Erro creating congregation.");
      }

      // await Task.Delay(1000);
      // return Ok(congByNumber);

      return BadRequest("Could not create congregation!");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCongregationAsync(long id, CongregationForUpdateDto congregationForUpdateDto)
    {
      Console.WriteLine("UpdateCongregationAsync: " + congregationForUpdateDto);

      Congregacao congregationRepo = await _repoCongregation.getCongregationAsync(congregationForUpdateDto.Id);

      if (congregationRepo == null)
      {
        throw new Exception($"Failed on save - congregation code {congregationForUpdateDto.Id} doesn't exist!");
      }

      Console.WriteLine("CongregationRepo 1: " + congregationRepo);
      _mapper.Map(congregationForUpdateDto, congregationRepo);
      Console.WriteLine("CongregationRepo 2: " + congregationRepo);

      var congDiff = _repoCongregation.verifyExistCongregationByNumberDiffId(congregationRepo);

      if (congDiff)
      {
        throw new Exception($"Failed on save! Congregation {congregationForUpdateDto.Numero} number already exist!");
      }

      var congDefault = _repoCongregation.getCongregationDefaultAsync();

      if (congregationForUpdateDto.Padrao)
      {
        if (congDefault.Id != congregationForUpdateDto.Id)
        {
          throw new Exception($"Failed on save! Default congregation already set!");
        }
      }

      if (Object.Equals(congregationForUpdateDto, congregationRepo))
      {
        throw new Exception("No change made!");
      }

      congregationForUpdateDto.AuditoriaUsuario = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

      Console.WriteLine("CongregationRepo 3: " + congregationRepo);
      _mapper.Map(congregationForUpdateDto, congregationRepo);
      Console.WriteLine("CongregationRepo 4: " + congregationRepo);


      if (await _repoCongregation.SaveAllAsync(congregationRepo))
      {
        Console.WriteLine("Update congregation: " + congregationRepo.Id);
        // var congToReturn = _mapper.Map<Congregacao>(congregationForCreateDto);
        // return CreatedAtRoute("GetCongregation", new { id = congregationForCreateDto.Id}, congToReturn);
        // return NoContent();
        Console.WriteLine("SaveAllAsync congregationRepo: " + congregationRepo);
        return Ok(congregationRepo);
      }
      else
      {
        Console.WriteLine("Error updating congregation.");
        return BadRequest("Any changes are made!");
      }

      // await Task.Delay(1000);
      // return BadRequest("Could not update congregation!");

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCongregationAsync(long id)
    {
      Console.WriteLine("DeleteCongregationAsync: " + id);

      Congregacao congregationRepo = await _repoCongregation.getCongregationAsync(id);

      if (congregationRepo == null)
      {
        throw new Exception($"Failed on delete - congregation code {id} doesn't exist!");
      }

      if (congregationRepo.Publicador.Count > 0)
      {
        throw new Exception($"Failed on delete! Congregation has publishers!");
      }

      var congDefault = _repoCongregation.getCongregationDefaultAsync();

      if (congregationRepo.Padrao)
      {
        throw new Exception($"Failed on delete! It is a default congregation!");
      }

      /*

      I will analyze DELETE function after because I will implement logic deletion    


      if (await _repo.Delete(congregationRepo)){
          Console.WriteLine("Delete congregation: " + congregationRepo.Id);
          // var congToReturn = _mapper.Map<Congregacao>(congregationForCreateDto);
          // return CreatedAtRoute("GetCongregation", new { id = congregationForCreateDto.Id}, congToReturn);
          // return NoContent();
          return Ok();
      } else {
          Console.WriteLine("Erro deleting congregation.");
      }

       */

      await Task.Delay(1000);
      return BadRequest("Could not delete congregation!");

    }


  }
}
using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReparationController : ControllerBase
{
    
    private readonly IReparationService _reparationService;

    public ReparationController(IReparationService reparationService)
    {
        _reparationService = reparationService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ReparationDto>>>> GetAll()
    {
        var response = new Response<List<ReparationDto>>
        {
            Data = await _reparationService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ReparationDto>>> Post([FromBody] ReparationDto reparationDto)
    {
        var response = new Response<ReparationDto>()
        {
            Data = await _reparationService.SaveAsync(reparationDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ReparationDto>>> GetById(int id)
    {
        var response = new Response<ReparationDto>();
        
        if (!await _reparationService.ReparationExist(id))
        {
            response.Errors.Add("Reparation Not Found");
            return NotFound(response);
        }
        
        response.Data = await _reparationService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ReparationDto>>> Update(int id, [FromBody] ReparationDto reparationDto)
    {
        var response = new Response<ReparationDto>();
        
        if (!await _reparationService.ReparationExist(reparationDto.Id))
            
        {
            response.Errors.Add("Reparation Not Found");
            return NotFound(response);
        }
        
        response.Data = await _reparationService.UpdateAsync(reparationDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _reparationService.DeleteAsync(id);
        
        return Ok(response);
    }
    
}
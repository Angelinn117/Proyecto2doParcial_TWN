using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApparatusController : ControllerBase
{
    private readonly IApparatusService _apparatusService;

    public ApparatusController(IApparatusService apparatusService)
    {
        _apparatusService = apparatusService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ApparatusDto>>>> GetAll()
    {
        var response = new Response<List<ApparatusDto>>
        {
            Data = await _apparatusService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ApparatusDto>>> Post([FromBody] ApparatusDto apparatusDto)
    {
        var response = new Response<ApparatusDto>()
        {
            Data = await _apparatusService.SaveAsync(apparatusDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ApparatusDto>>> GetById(int id)
    {
        var response = new Response<ApparatusDto>();
        
        if (!await _apparatusService.ApparatusExist(id))
        {
            response.Errors.Add("Apparatus Not Found");
            return NotFound(response);
        }
        
        response.Data = await _apparatusService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ApparatusDto>>> Update(int id, [FromBody] ApparatusDto apparatusDto)
    {
        var response = new Response<ApparatusDto>();
        
        if (!await _apparatusService.ApparatusExist(apparatusDto.Id))
            
        {
            response.Errors.Add("Apparatus Not Found");
            return NotFound(response);
        }
        
        response.Data = await _apparatusService.UpdateAsync(apparatusDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _apparatusService.DeleteAsync(id);
        
        return Ok(response);
    }
}

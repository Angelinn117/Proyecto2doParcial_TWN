using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarrantyController : ControllerBase
{
    
    private readonly IWarrantyService _warrantyService;

    public WarrantyController(IWarrantyService warrantyService)
    {
        _warrantyService = warrantyService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<WarrantyDto>>>> GetAll()
    {
        var response = new Response<List<WarrantyDto>>
        {
            Data = await _warrantyService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<WarrantyDto>>> Post([FromBody] WarrantyDto warrantyDto)
    {
        var response = new Response<WarrantyDto>()
        {
            Data = await _warrantyService.SaveAsync(warrantyDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<WarrantyDto>>> GetById(int id)
    {
        var response = new Response<WarrantyDto>();
        
        if (!await _warrantyService.WarrantyExist(id))
        {
            response.Errors.Add("Warranty Not Found");
            return NotFound(response);
        }
        
        response.Data = await _warrantyService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<WarrantyDto>>> Update(int id, [FromBody] WarrantyDto warrantyDto)
    {
        var response = new Response<WarrantyDto>();
        
        if (!await _warrantyService.WarrantyExist(warrantyDto.Id))
            
        {
            response.Errors.Add("Warranty Not Found");
            return NotFound(response);
        }
        
        response.Data = await _warrantyService.UpdateAsync(warrantyDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _warrantyService.DeleteAsync(id);
        
        return Ok(response);
    }
    
}
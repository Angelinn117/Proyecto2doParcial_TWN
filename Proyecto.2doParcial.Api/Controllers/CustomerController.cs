using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<CustomerDto>>>> GetAll()
    {
        var response = new Response<List<CustomerDto>>
        {
            Data = await _customerService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<CustomerDto>>> Post([FromBody] CustomerDto customerDto)
    {
        var response = new Response<CustomerDto>()
        {
            Data = await _customerService.SaveAsync(customerDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CustomerDto>>> GetById(int id)
    {
        var response = new Response<CustomerDto>();
        
        if (!await _customerService.CustomerExist(id))
        {
            response.Errors.Add("Customer Not Found");
            return NotFound(response);
        }
        
        response.Data = await _customerService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CustomerDto>>> Update(int id, [FromBody] CustomerDto customerDto)
    {
        var response = new Response<CustomerDto>();
        
        if (!await _customerService.CustomerExist(customerDto.Id))
            
        {
            response.Errors.Add("Customer Not Found");
            return NotFound(response);
        }
        
        response.Data = await _customerService.UpdateAsync(customerDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _customerService.DeleteAsync(id);
        
        return Ok(response);
    }
    
}
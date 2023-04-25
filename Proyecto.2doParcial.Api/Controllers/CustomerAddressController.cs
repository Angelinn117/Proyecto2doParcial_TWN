using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerAddressController : ControllerBase
{
    
    private readonly ICustomerAddressService _customerAddressService;

    public CustomerAddressController(ICustomerAddressService customerAddressService)
    {
        _customerAddressService = customerAddressService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<CustomerAddressDto>>>> GetAll()
    {
        var response = new Response<List<CustomerAddressDto>>
        {
            Data = await _customerAddressService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<CustomerAddressDto>>> Post([FromBody] CustomerAddressDto customerAddressDto)
    {
        var response = new Response<CustomerAddressDto>()
        {
            Data = await _customerAddressService.SaveAsync(customerAddressDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CustomerAddressDto>>> GetById(int id)
    {
        var response = new Response<CustomerAddressDto>();
        
        if (!await _customerAddressService.CustomerAddressExist(id))
        {
            response.Errors.Add("Customer address Not Found");
            return NotFound(response);
        }
        
        response.Data = await _customerAddressService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<CustomerAddressDto>>> Update(int id, [FromBody] CustomerAddressDto customerAddressDto)
    {
        var response = new Response<CustomerAddressDto>();
        
        if (!await _customerAddressService.CustomerAddressExist(customerAddressDto.Id))
            
        {
            response.Errors.Add("Customer address Not Found");
            return NotFound(response);
        }
        
        response.Data = await _customerAddressService.UpdateAsync(customerAddressDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _customerAddressService.DeleteAsync(id);
        
        return Ok(response);
    }
    
}
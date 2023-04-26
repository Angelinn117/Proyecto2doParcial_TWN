using Microsoft.AspNetCore.Mvc;
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;
using Proyecto._2doParcial.Core.Http;

namespace Proyecto._2doParcial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userService.GetAllAsync()
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>()
        {
            Data = await _userService.SaveAsync(userDto)
        };

        return Created($"/api/[controller]/{response.Data.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id)
    {
        var response = new Response<UserDto>();
        
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
        
        response.Data = await _userService.GetById(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> Update(int id, [FromBody] UserDto userDto)
    {
        var response = new Response<UserDto>();
        
        if (!await _userService.UserExist(userDto.Id))
            
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
        
        response.Data = await _userService.UpdateAsync(userDto);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _userService.DeleteAsync(id);
        
        return Ok(response);
    }
}
using Proyecto._2doParcial.Repositories.Interfaces;
using Proyecto._2doParcial.Services.Interfaces;
using Proyecto._2doParcial.Core.Dto;
using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> SaveAsync(UserDto userDto)
    {
        var user = new User
        {
            nombreUsuario = userDto.nombreUsuario,
            contraseñaUsuario = userDto.contraseñaUsuario,
            nombreCompleto = userDto.nombreCompleto,

            CreatedBy = "",
            CreateDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
            
        };

        user = await _userRepository.SaveAsync(user);
        user.Id = user.Id;

        return userDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto userDto)
    {
        var user = await _userRepository.GetById(userDto.Id);

        if (user == null)
            throw new Exception("User Not Found");


        user.nombreUsuario = userDto.nombreUsuario;
        user.contraseñaUsuario = userDto.contraseñaUsuario;
        user.nombreCompleto = userDto.nombreCompleto;
        
        user.UpdatedBy = "";
        user.UpdateDate = DateTime.Now;

        await _userRepository.UpdateAsync(user);

        return userDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var usersDto =
            users.Select(c => new UserDto(c)).ToList();
        return usersDto;
        
    }

    public async Task<bool> UserExist(int id)
    {
        var user = await _userRepository.GetById(id);
        return (user != null);
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
            throw new Exception("User Not Found");
        var userDto = new UserDto(user);
        return userDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
    
}
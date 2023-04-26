using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface IUserService
{
    
    //Método para guardar usuarios.
    Task<UserDto> SaveAsync(UserDto user);
    
    //Método para actualizar los usuarios.
    Task<UserDto> UpdateAsync(UserDto user);
    
    //Método para retornar una lista de usuarios.
    Task<List<UserDto>> GetAllAsync();
    
    //Método para retornar el id de los usuarios que borrara.
    Task<bool> UserExist (int id);
    
    //Método para obtener un usuario por id.
    Task<UserDto> GetById(int id);
    
    //Método para borrar usuarios.
    Task<bool> DeleteAsync(int id);
    
}
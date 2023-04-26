using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface IUserRepository
{
    
    //Método para guardar usuarios.
    Task<User> SaveAsync(User user);
    
    //Método para actualizar los usuarios.
    Task<User> UpdateAsync(User user);
    
    //Método para retornar una lista de usuarios.
    Task<List<User>> GetAllAsync();
    
    //Método para retornar el id de los usuarios que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener un usuario por id.
    Task<User> GetById(int id);
    
}
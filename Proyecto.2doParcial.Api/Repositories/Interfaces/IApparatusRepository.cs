using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface IApparatusRepository
{
    
    //Método para guardar aparatos.
    Task<Apparatus> SaveAsync(Apparatus apparatus);
    
    //Método para actualizar los aparatos.
    Task<Apparatus> UpdateAsync(Apparatus apparatus);
    
    //Método para retornar una lista de aparatos.
    Task<List<Apparatus>> GetAllAsync();
    
    //Método para retornar el id de los aparatos que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener un aparato por id.
    Task<Apparatus> GetById(int id);
    
}
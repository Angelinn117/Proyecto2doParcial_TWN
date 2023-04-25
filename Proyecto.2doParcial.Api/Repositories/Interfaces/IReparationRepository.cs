using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface IReparationRepository
{
    
    //Método para guardar reparaciones.
    Task<Reparation> SaveAsync(Reparation reparation);
    
    //Método para actualizar las reparaciones.
    Task<Reparation> UpdateAsync(Reparation reparation);
    
    //Método para retornar una lista de reparaciones.
    Task<List<Reparation>> GetAllAsync();
    
    //Método para retornar el id de las reparaciones que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una reparación por id.
    Task<Reparation> GetById(int id);
    
}
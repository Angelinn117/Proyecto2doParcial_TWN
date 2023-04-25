using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface IReparationService
{
    
    //Método para guardar reparaciones.
    Task<ReparationDto> SaveAsync(ReparationDto reparation);
    
    //Método para actualizar las reparaciones.
    Task<ReparationDto> UpdateAsync(ReparationDto reparation);
    
    //Método para retornar una lista de reparaciones.
    Task<List<ReparationDto>> GetAllAsync();
    
    //Método para retornar el id de las reparaciones que borrará.
    Task<bool> ReparationExist (int id);
    
    //Método para obtener una reparación por id.
    Task<ReparationDto> GetById(int id);
    
    //Método para borrar reparaciones.
    Task<bool> DeleteAsync(int id);
    
}
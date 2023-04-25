using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface IApparatusService
{
    
    //Método para guardar aparatos.
    Task<ApparatusDto> SaveAsync(ApparatusDto apparatus);
    
    //Método para actualizar los aparatos.
    Task<ApparatusDto> UpdateAsync(ApparatusDto apparatus);
    
    //Método para retornar una lista de aparatos.
    Task<List<ApparatusDto>> GetAllAsync();
    
    //Método para retornar el id de los aparatos que borrara.
    Task<bool> ApparatusExist (int id);
    
    //Método para obtener un aparatos por id.
    Task<ApparatusDto> GetById(int id);
    
    //Método para borrar aparatos.
    Task<bool> DeleteAsync(int id);
    
}
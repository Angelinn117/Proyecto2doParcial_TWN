using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface IApparatusService
{
    
    //metodo para guardar aparatos.
    Task<ApparatusDto> SaveAsync(ApparatusDto apparatus);
    
    //metodo para actualizar los aparatos.
    Task<ApparatusDto> UpdateAsync(ApparatusDto apparatus);
    
    //Metodo para retornar una lista de aparatos.
    Task<List<ApparatusDto>> GetAllAsync();
    
    //Metodo para retornar el id de los aparatos que borrara.
    Task<bool> ApparatusExist (int id);
    
    //Metodo para obtener un aparatos por id.
    Task<ApparatusDto> GetById(int id);
    
    //Metodo para borrar aparatos.
    Task<bool> DeleteAsync(int id);
    
}
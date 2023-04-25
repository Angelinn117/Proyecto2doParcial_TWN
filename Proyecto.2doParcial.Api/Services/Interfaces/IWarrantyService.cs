using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface IWarrantyService
{
    
    //Método para guardar garantías.
    Task<WarrantyDto> SaveAsync(WarrantyDto warranty);
    
    //Método para actualizar las garantías.
    Task<WarrantyDto> UpdateAsync(WarrantyDto warranty);
    
    //Método para retornar una lista de garantías.
    Task<List<WarrantyDto>> GetAllAsync();
    
    //Método para retornar el id de las garantías que borrara.
    Task<bool> WarrantyExist (int id);
    
    //Método para obtener una garantía por id.
    Task<WarrantyDto> GetById(int id);
    
    //Método para borrar garantías.
    Task<bool> DeleteAsync(int id);
    
}
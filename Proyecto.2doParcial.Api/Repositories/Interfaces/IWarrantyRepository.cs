using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface IWarrantyRepository
{
    
    //Método para guardar garantías.
    Task<Warranty> SaveAsync(Warranty warranty);
    
    //Método para actualizar las garantías.
    Task<Warranty> UpdateAsync(Warranty warranty);
    
    //Método para retornar una lista de garantías.
    Task<List<Warranty>> GetAllAsync();
    
    //Método para retornar el id de las garantías que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una garantía por id.
    Task<Warranty> GetById(int id);
    
}
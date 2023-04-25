using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface ICustomerService
{
    
    //Método para guardar clientes.
    Task<CustomerDto> SaveAsync(CustomerDto customer);
    
    //Método para actualizar los clientes.
    Task<CustomerDto> UpdateAsync(CustomerDto customer);
    
    //Método para retornar una lista de clientes.
    Task<List<CustomerDto>> GetAllAsync();
    
    //Método para retornar el id de los clientes que borrara.
    Task<bool> CustomerExist (int id);
    
    //Método para obtener un cliente por id.
    Task<CustomerDto> GetById(int id);
    
    //Método para borrar aparatos.
    Task<bool> DeleteAsync(int id);

    
}
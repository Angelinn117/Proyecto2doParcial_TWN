using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface ICustomerAddressRepository
{
    //Método para guardar direcciones de clientes.
    Task<CustomerAddress> SaveAsync(CustomerAddress customerAddress);
    
    //Método para actualizar las direcciones de clientes.
    Task<CustomerAddress> UpdateAsync(CustomerAddress customerAddress);
    
    //Método para retornar una lista de direcciones de clientes.
    Task<List<CustomerAddress>> GetAllAsync();
    
    //Método para retornar el id de las direcciones de clientes que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener una direccione de cliente por id.
    Task<CustomerAddress> GetById(int id);
}
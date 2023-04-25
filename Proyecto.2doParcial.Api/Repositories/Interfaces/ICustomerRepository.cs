using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Repositories.Interfaces;

public interface ICustomerRepository
{
    //Método para guardar clientes.
    Task<Customer> SaveAsync(Customer customer);
    
    //Método para actualizar los clientes.
    Task<Customer> UpdateAsync(Customer customer);
    
    //Método para retornar una lista de clientes.
    Task<List<Customer>> GetAllAsync();
    
    //Método para retornar el id de los clientes que borrara.
    Task<bool> DeleteAsync(int id);
    
    //Método para obtener un cliente por id.
    Task<Customer> GetById(int id);
    
}
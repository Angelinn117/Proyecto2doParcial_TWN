using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface ICustomerAddressService
{
    //Método para guardar direcciones de clientes.
    Task<CustomerAddressDto> SaveAsync(CustomerAddressDto customerAddress);
    
    //Método para actualizar las direcciones de clientes.
    Task<CustomerAddressDto> UpdateAsync(CustomerAddressDto customerAddress);
    
    //Método para retornar una lista de direcciones de clientes.
    Task<List<CustomerAddressDto>> GetAllAsync();
    
    //Método para retornar el id de las direcciones de clientes que borrara.
    Task<bool> CustomerAddressExist (int id);
    
    //Método para obtener una direccion de cliente por id.
    Task<CustomerAddressDto> GetById(int id);
    
    //Método para borrar direcciones de clientes.
    Task<bool> DeleteAsync(int id);
}
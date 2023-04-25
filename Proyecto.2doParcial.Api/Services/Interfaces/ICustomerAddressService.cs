using Proyecto._2doParcial.Core.Dto;

namespace Proyecto._2doParcial.Services.Interfaces;

public interface ICustomerAddressService
{
    //metodo para guardar direcciones de clientes.
    Task<CustomerAddressDto> SaveAsync(CustomerAddressDto customerAddress);
    
    //metodo para actualizar las direcciones de clientes.
    Task<CustomerAddressDto> UpdateAsync(CustomerAddressDto customerAddress);
    
    //Metodo para retornar una lista de direcciones de clientes.
    Task<List<CustomerAddressDto>> GetAllAsync();
    
    //Metodo para retornar el id de las direcciones de clientes que borrara.
    Task<bool> CustomerAddressExist (int id);
    
    //Metodo para obtener una direccion de cliente por id.
    Task<CustomerAddressDto> GetById(int id);
    
    //Metodo para borrar direcciones de clientes.
    Task<bool> DeleteAsync(int id);
}
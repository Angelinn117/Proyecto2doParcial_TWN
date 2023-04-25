using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Core.Dto;

public class CustomerDto : DtoBase
{
    public int FK_idDireccionCliente { get; set; }
    public string nombre { get; set; }
    public string telefono { get; set; }
    
    public CustomerDto()
    {

    }
    
    public CustomerDto(Customer customer)
    {

        FK_idDireccionCliente = customer.FK_idDireccionCliente;
        nombre = customer.nombre;
        telefono = customer.telefono;
        Id = customer.Id;
        

    }
    
    
}
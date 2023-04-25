using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Core.Dto;

public class CustomerAddressDto : DtoBase
{
    public string calle { get; set; }
    public string colonia { get; set; }
    public string numeroExterior { get; set; }
    public string numeroInterior { get; set; }
    
    public CustomerAddressDto()
    {

    }

    public CustomerAddressDto(CustomerAddress customerAddress)
    {
        
        calle = customerAddress.calle;
        colonia = customerAddress.colonia;
        numeroExterior = customerAddress.numeroExterior;
        numeroInterior = customerAddress.numeroInterior;
        Id = customerAddress.Id;
        
    }

}
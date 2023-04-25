using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Core.Dto;

public class WarrantyDto : DtoBase
{
    public int FK_idAparato { get; set; }
    public int FK_idReparacion { get; set; }
    public bool aplicacionGarantia { get; set; }
    
    public WarrantyDto()
    {

    }
    
    public WarrantyDto(Warranty warranty)
    {

        FK_idAparato = warranty.FK_idAparato;
        FK_idReparacion = warranty.FK_idReparacion;
        aplicacionGarantia = warranty.aplicacionGarantia;
        Id = warranty.Id;
        
    }
    
}
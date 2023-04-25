using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Core.Dto;

public class ReparationDto : DtoBase
{
    
    public int FK_idAparato { get; set; }
    public int FK_idUsuario { get; set; }
    public string descripcionReparacion { get; set; }
    public DateTime fecha { get; set; }
    
    public ReparationDto()
    {

    }
    
    public ReparationDto(Reparation reparation)
    {

        FK_idAparato = reparation.FK_idAparato;
        FK_idUsuario = reparation.FK_idUsuario;
        descripcionReparacion = reparation.descripcionReparacion;
        fecha = reparation.fecha;
        Id = reparation.Id;

    }
    
}
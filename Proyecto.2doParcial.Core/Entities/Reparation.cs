namespace Proyecto._2doParcial.Core.Entities;

public class Reparation : EntityBase
{
    public int FK_idAparato { get; set; }
    public int FK_idUsuario { get; set; }
    public string descripcionReparacion { get; set; }
    public DateTime fecha { get; set; }
}
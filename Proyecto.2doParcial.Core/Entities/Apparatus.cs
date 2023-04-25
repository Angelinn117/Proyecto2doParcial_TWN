namespace Proyecto._2doParcial.Core.Entities;

public class Apparatus : EntityBase
{
    
    public int FK_idCliente { get; set; }
    public DateTime fechaRecepcion { get; set; }
    public string tipoAparato { get; set; }
    public string marca { get; set; }
    public string descripcionProblematica { get; set; }
    public string descripcionAdicional { get; set; }
    public string ubicacionEstante { get; set; }
    
}
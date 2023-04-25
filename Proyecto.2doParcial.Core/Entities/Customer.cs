using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto._2doParcial.Core.Entities;

public class Customer : EntityBase
{
    public int FK_idDireccionCliente { get; set; }
    public string nombre { get; set; }
    public string telefono { get; set; }
    
}
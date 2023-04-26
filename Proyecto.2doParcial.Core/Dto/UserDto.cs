using Proyecto._2doParcial.Core.Entities;

namespace Proyecto._2doParcial.Core.Dto;

public class UserDto : DtoBase
{
    public string nombreUsuario { get; set; }
    public string contraseñaUsuario { get; set; }
    public string nombreCompleto { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(User user)
    {

        nombreUsuario = user.nombreUsuario;
        contraseñaUsuario = user.contraseñaUsuario;
        nombreCompleto = user.nombreCompleto;
        Id = user.Id;

    }
    
}
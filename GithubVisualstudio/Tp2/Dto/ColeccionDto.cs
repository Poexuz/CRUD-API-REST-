namespace Tp2.Dto;
using Tp2.Models;
public class ColeccionDto
{
    public string? UsuarioNombre {get;set;}
    public string? JuegoNombre {get;set;}

    // Constructor vacío para permitir la creación de objetos sin parámetros.
    public ColeccionDto(){}
    
    // Constructor recibe un objeto Usuario y un objeto Juego obtener sus nombres.
    public ColeccionDto(Usuario usuario, Juego juego){
        UsuarioNombre = usuario.Nombre;
        JuegoNombre = juego.Nombre;
    }
}

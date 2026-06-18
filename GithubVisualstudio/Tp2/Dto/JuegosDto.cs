namespace Tp2.Dto;
using Tp2.Models;
public class JuegosDto
{
    public string? Nombre {get;set;}
    public string? Descripcion {get;set;}
    // Constructor vacío para permitir la creación de objetos sin parámetros.
    public JuegosDto(Juego juego)
    {
        Nombre = juego.Nombre;
        Descripcion = juego.Descripcion;
    }
}
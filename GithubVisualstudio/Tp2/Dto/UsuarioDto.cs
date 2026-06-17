namespace Tp2.Dto;
using Tp2.Models;
public class UsuarioDto
{
    public string? Nombre {get;set;}
    public int Saldo {get;set;}
    public List<Juego>? ListaJuegos {get;set;}
}
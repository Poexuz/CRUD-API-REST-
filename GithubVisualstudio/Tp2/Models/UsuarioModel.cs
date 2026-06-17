namespace Tp2.Models;
public class Usuarios
{
    public int Id {get;set;}
    public string? Nombre {get;set;}
    public string? Mail {get;set;}
    public int Saldo {get;set;}
    public List<juegos>? ListaJuegos {get;set;}
}
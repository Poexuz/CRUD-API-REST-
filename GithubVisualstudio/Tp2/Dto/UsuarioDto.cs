namespace Tp2.Dto;
using Tp2.Models;
public class UsuarioDto
{
    public string? Nombre {get;set;}
    public string? Mail {get;set;}
    public UsuarioDto(Usuario usuario)
    {
        Nombre = usuario.Nombre;
        Mail = usuario.Mail;
    }

}
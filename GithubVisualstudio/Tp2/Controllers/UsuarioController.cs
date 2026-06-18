using Microsoft.AspNetCore.Mvc;
using Tp2.Service;
using Tp2.Models;
namespace Tp2.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _Service;
    public UsuarioController(){
        _Service = new UsuarioService();
    }
    
    [HttpGet]
    public IActionResult ObtenerUsuarios(){
        return Ok(_Service.ObtenerUsuarios());
    }

    [HttpPost]
    public IActionResult CrearUsuario([FromBody] Usuario nuevoUsuario)
    {
        _Service.CrearUsuario(nuevoUsuario);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult ModificarUsuario(int id, [FromBody] Usuario usuarioActualizado)
    {
        usuarioActualizado.Id = id;
        _Service.UpdateUsuario(usuarioActualizado);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        _Service.DeleteUsuario(id);
        return Ok();
    }
    
}

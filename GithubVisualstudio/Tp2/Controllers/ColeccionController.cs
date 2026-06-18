namespace Tp2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Tp2.Service;
using Tp2.Models;

[ApiController]
[Route("[controller]")]
public class ColeccionController : ControllerBase
{
    private readonly ColeccionService _Service;
    
    public ColeccionController(){
        _Service = new ColeccionService();
    }
    
    [HttpPost]
    public IActionResult CrearColeccionUsuario([FromBody] Coleccion nuevaColeccion)
    {
        _Service.CrearColeccion(nuevaColeccion);
        return Ok();
    }

    // Obtener la coleccion completa de juegos y usuarios.
    [HttpGet]
    public IActionResult ObtenerColeccion(){
        return Ok(_Service.ObtenerColeccion());
    }

    // Obtener la coleccion de un usuario especifico.
    [HttpGet("Usuario/{usuarioId}")]
    public IActionResult ObtenerColeccionUsuario([FromRoute] int usuarioId)
    {
        var coleccionUsuario = _Service.ObtenerColeccionUsuario(usuarioId);
        return Ok(coleccionUsuario);
    }

    // Obtener la coleccion de un juego especifico.
    [HttpGet("Juego/{juegoId}")]
    public IActionResult ObtenerColeccionJuego([FromRoute] int juegoId)
    {
        var coleccionJuego = _Service.ObtenerColeccionJuego(juegoId);
        return Ok(coleccionJuego);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarColeccion([FromBody] Coleccion coleccionActualizada)
    {
        _Service.UpdateColeccion(coleccionActualizada);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarColeccion([FromRoute] int id)
    {
        _Service.DeleteColeccion(id);
        return Ok();
    }

}
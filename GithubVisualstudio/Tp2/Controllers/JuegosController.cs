using Microsoft.AspNetCore.Mvc;
using Tp2.Service;
using Tp2.Models;
namespace Tp2.Controllers;

[ApiController]
[Route("[controller]")]
public class JuegoController : ControllerBase
{
private readonly JuegoService _Service;
    
    public JuegoController(){
        _Service = new JuegoService();
    }
    
    [HttpGet]
    public IActionResult ObtenerJuegos(){
        return Ok(_Service.ObtenerJuegos());
    }

    [HttpPost]
    public IActionResult CrearJuego([FromBody] Juego nuevoJuego)
    {
        _Service.CrearJuego(nuevoJuego);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult ModificarJuego(int id, [FromBody] Juego juegoActualizado)
    {
        juegoActualizado.Id = id;
        _Service.UpdateJuego(juegoActualizado);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarJuego(int id)
    {
        _Service.DeleteJuego(id);
        return Ok();
    }


    

}
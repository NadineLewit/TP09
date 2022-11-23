using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers;
[ApiController]
[Route("[controller]")]
public class PeliculaController : ControllerBase
{
    
    [HttpGet]
    public ActionResult Get()
    {
        List<Pelicula> lista = BD.ObtenerPeliculas();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id){

    if(id < 1){
        return BadRequest();
    }

    Pelicula p = BD.VerInfoPelicula(id);

    if(p == null){
        return NotFound();
    }

    return Ok(p);
   }


   [HttpPost]
    public IActionResult Post(Pelicula p){
        if(p.Nombre == null || p.Nombre == ""){
            return BadRequest();
        }
        
        BD.AgregarPelicula(p);
        return Ok();
    }

    [HttpDelete("{id}")]
   public IActionResult Delete(int id){
    if(id < 1){
        return BadRequest();
    }
    Pelicula p = BD.VerInfoPelicula(id);

    if(p == null) {
        return NotFound();
    }

    BD.EliminarReseñas(id);
    BD.EliminarPelicula(id);
    return Ok();
   }
} 
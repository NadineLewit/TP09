using Microsoft.AspNetCore.Mvc;
using TP09.Models;

namespace TP09.Controllers;
[ApiController]
[Route("[controller]")]
public class PeliculaController : ControllerBase
{
    // 1
    [HttpGet]
    public ActionResult Get()
    {
        List<Pelicula> lista = BD.ObtenerPeliculas();
        return Ok(lista);
    }

    //2
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

    //3
   [HttpPost]
    public IActionResult Post(Pelicula p){
        if(p.Nombre == null || p.Nombre == ""){
            return BadRequest();
        }
        
        BD.AgregarPelicula(p);
        return Ok();
    }

    //4
    [HttpPut]
    public IActionResult Put(int id, string nombre){
        
        
        if(id < 1){
            return BadRequest();   
        }

        Pelicula p = BD.VerInfoPelicula(id);

        if(p == null){
            return NotFound();
        }
        
        BD.ModificarPelicula(id,nombre);
        return Ok();
    }


    //5
    [HttpPatch("(id)")]
    public IActionResult Patch(int id, Pelicula peliNueva)
    {
        if(id < 1)
        {
            return BadRequest();
        }
        Pelicula peliVieja = BD.VerInfoPelicula(id);
        if(peliNueva.Nombre != null && peliNueva.Nombre != peliVieja.Nombre)
        {
            peliVieja.Nombre = peliNueva.Nombre;
        }
        if(peliNueva.Foto != null && peliNueva.Foto != peliVieja.Foto)
        {
            peliVieja.Foto = peliNueva.Foto;
        }
        if(peliNueva.Descripcion != null && peliNueva.Descripcion != peliVieja.Descripcion)
        {
            peliVieja.Descripcion = peliNueva.Descripcion;
        }
        if(peliNueva.Estrellas != null && peliNueva.Estrellas != peliVieja.Estrellas)
        {
            peliVieja.Estrellas = peliNueva.Estrellas;
        }
        if(peliNueva.FkCategoria != null && peliNueva.FkCategoria != peliVieja.FkCategoria)
        {
            peliVieja.FkCategoria = peliNueva.FkCategoria;
        }
        if(peliNueva.NombreCategoria != null && peliNueva.NombreCategoria != peliVieja.NombreCategoria)
        {
            peliVieja.NombreCategoria = peliNueva.NombreCategoria;
        }
        BD.PutPelicula(id, peliVieja);
        return Ok();
    }

    //6
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
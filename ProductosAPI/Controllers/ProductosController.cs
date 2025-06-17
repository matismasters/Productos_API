using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private static List<Producto> productos = new List<Producto>()
    {
        new Producto { Id = 1, Nombre = "Teclado", Precio = 50.0M },
        new Producto { Id = 2, Nombre = "Mouse", Precio = 25.0M }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> Get()
    {
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public ActionResult<Producto> Get(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    [HttpPost]
    public ActionResult Post(Producto nuevoProducto)
    {
        productos.Add(nuevoProducto);
        return CreatedAtAction(nameof(Get), new { id = nuevoProducto.Id }, nuevoProducto);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
            return NotFound();

        productos.Remove(producto);
        return NoContent();
    }
}
using ComoHacerAPIs.Core.Entities;
using ComoHacerAPIs.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComoHacerAPIs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ComoHacerAPIsContext _context;

        public ProductosController(ComoHacerAPIsContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Producto>>> GetProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if(producto == null)
            {
                return NotFound("No se encontro ningun producto con el id: " + id);
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody]Producto p) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El modelo no coincide con un producto");
            }
            Producto producto = new Producto
            {
                nombre = p.nombre,
                descripcion = p.descripcion
            };
            await _context.AddAsync(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut]
        public async Task<ActionResult<Producto>> PutProducto([FromBody]Producto p)
        {
            var producto = await _context.Productos.FindAsync(p.id);

            if (producto == null)
            {
                return NotFound("No se encontro ningun producto con el id: " + p.id);
            }

            producto.nombre = p.nombre;
            producto.descripcion = p.descripcion;

            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound("No se encontro ningun producto con el id: " + id);
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok("Se elimino correctamente");
        }


    }
}
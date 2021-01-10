using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComoHacerAPIs.Core.Entities;
using ComoHacerAPIs.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComoHacerAPIs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly ComoHacerAPIsContext _context;
        public VendedoresController(ComoHacerAPIsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Vendedor>>> GetVendedores()
        {
            var vendedores = await _context.Vendedor.ToListAsync();
            return Ok(vendedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound("No se encontro el vendedor con id: " + id);
            }
            return vendedor;
        }

        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor([FromBody]Vendedor v)
        {
            Vendedor vendedor = new Vendedor
            {
                nombre = v.nombre,
                apellido = v.apellido,
                edad = v.edad
            };
            await _context.AddAsync(vendedor);
            await _context.SaveChangesAsync();
            return Ok(vendedor);
        }

        [HttpPut]
        public async Task<ActionResult<Vendedor>> PutVendedor([FromBody] Vendedor v)
        {
            var vendedor = await _context.Vendedor.FindAsync(v.id);
            if (vendedor == null)
            {
                return NotFound("No se encontro el vendedor con id: " + v.id);
            }
            vendedor.nombre = v.nombre;
            vendedor.apellido = v.apellido;
            vendedor.edad = v.edad;

            await _context.SaveChangesAsync();
            return Ok(vendedor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendedor>> DeleteVendedor(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound("No se encontro el vendedor con id: " + id);
            }
            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
            return Ok("Se elimino correctamente");
        }

    }
}
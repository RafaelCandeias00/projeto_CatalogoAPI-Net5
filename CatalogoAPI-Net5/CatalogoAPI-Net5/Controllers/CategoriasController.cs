using CatalogoAPI_Net5.Context;
using CatalogoAPI_Net5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoAPI_Net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get([FromRoute] int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
    }
}

using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(AppDbContext context, ILogger<CategoriasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
                var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
                return Ok(categorias);

        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound($"Categoria com ID {id} não encontrada.");

            return Ok(categoria);
        }
        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasProduto()
        {
            var categorias = await _context.Categorias
                .Include(p => p.Produtos)
                .Where(c => c.CategoriaId <= 5)
                .AsNoTracking()
                .ToListAsync();

            return Ok(categorias);
        }
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
                return BadRequest("ID da URL difere do corpo da requisição.");

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Categorias.Any(c => c.CategoriaId == id))
                    return NotFound($"Categoria com ID {id} não encontrada.");
                else
                    throw;
            }

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound($"Categoria com ID {id} não encontrada.");

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

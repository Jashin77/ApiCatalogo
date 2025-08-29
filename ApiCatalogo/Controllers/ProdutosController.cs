using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(AppDbContext context, ILogger<ProdutosController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto is null)
                return NotFound($"Produto com ID {id} não encontrado.");

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.ProdutoId)
                return BadRequest("ID da URL difere do corpo da requisição.");

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Produtos.Any(p => p.ProdutoId == id))
                    return NotFound($"Produto com ID {id} não encontrado.");
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto is null)
                return NotFound($"Produto com ID {id} não encontrado.");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

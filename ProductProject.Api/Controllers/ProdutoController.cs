using Microsoft.AspNetCore.Mvc;
using ProductProject.Application.Dtos.ProdutoDtos;
using ProductProject.Application.Interfaces;

namespace ProductProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController(IProdutoInterface produtoService) : ControllerBase
    {
        private readonly IProdutoInterface _produtoService = produtoService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisualizarProdutoDto>>> ListarTodos()
        {
            var produtos = await _produtoService.ListarProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido"); 
            var produtos = await _produtoService.ObterProdutoPorIdAsync(id);
            if (produtos is null) return NotFound();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<VisualizarProdutoDto>> CriarProduto([FromBody] CriarProdutoDto dto)
        {
            var produto = await _produtoService.NovoProdutoAsync(dto);
            return CreatedAtAction(nameof(ListarPorId), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido");
            var produto = await _produtoService.AtualizarProdutoAsync(id, dto);
            if (produto == null) return NotFound(); 
            return NoContent();
        }
    }
}

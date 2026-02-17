using Microsoft.AspNetCore.Mvc;
using ProductProject.Application.Dtos.ProdutoDtos;
using ProductProject.Application.Interfaces;
using ProductProject.Application.Services;
using ProductProject.Domain.Interfaces;

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
            var produtos = await _produtoService.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido");
            var produtos = await _produtoService.ObterProdutoPorId(id);
            if (produtos is null) return NotFound();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<VisualizarProdutoDto>> CriarProduto([FromBody] CriarProdutoDto dto)
        {
            var produto = await _produtoService.NovoProdutoAsync(dto);

            return CreatedAtAction(nameof(ListarPorId), new { id = produto.Id }, produto);
        }
    }
}

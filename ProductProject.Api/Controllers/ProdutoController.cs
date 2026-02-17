using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Application.Dtos;
using ProductProject.Domain.Interfaces;

namespace ProductProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface request;

        public ProdutoController(IProdutoInterface _request)
        {
            request = _request;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisualizarProdutoDto>>> ListarTodos()
        {
            var produtos = await request.ListarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id Inválido");
            var produtos = await request.ObterProdutoPorId(id);
            if (produtos is null) return NotFound();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<VisualizarProdutoDto>> CriarProduto([FromBody] CriarProdutoDto dto)
        {
            var produto = await request.NovoProdutoAsync(dto);

            return CreatedAtAction(nameof(ListarPorId), new { id = produto.Id }, produto);
        }
    }
}

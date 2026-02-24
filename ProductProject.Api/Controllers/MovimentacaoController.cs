using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Application.Dtos.MovimentacaoDtos;
using ProductProject.Application.Interfaces;

namespace ProductProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController(IMovimentacaoInterface movimentacaoService) : ControllerBase
    {
        private readonly IMovimentacaoInterface _movimentacaoService = movimentacaoService;

        [HttpPost]
        public async Task<ActionResult<VisualizarMovimentacaoDto>> CriarMovimentacao([FromBody] CriarMovimentacaoDto dto)
        {
            return await _movimentacaoService.NovaMovimentacaoAsync(dto);
        }
    }
}

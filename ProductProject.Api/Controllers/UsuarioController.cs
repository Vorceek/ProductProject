using Microsoft.AspNetCore.Mvc;
using ProductProject.Application.Dtos.UsuarioDtos;
using ProductProject.Application.Interfaces;

namespace ProductProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioInterface usuarioService) : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioService = usuarioService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisualizarUsuarioDto>>> ListarTodos()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido"); 
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<VisualizarUsuarioDto>> CriarUsuario([FromBody] CriarUsuarioDto dto)
        {
            var usuario = await _usuarioService.NovoUsuarioAsync(dto);
            return CreatedAtAction(nameof(ListarPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(Guid id, [FromBody] AtualizarUsuarioDto dto)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido"); 
            var usuario = await _usuarioService.AtualizarUsuarioAsync(id, dto);
            if (usuario == null) return NotFound();
            return NoContent();
        }
    }
}

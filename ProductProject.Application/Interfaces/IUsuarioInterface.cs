using ProductProject.Application.Dtos.UsuarioDtos;

namespace ProductProject.Application.Interfaces
{
    public interface IUsuarioInterface
    {
        Task<VisualizarUsuarioDto> NovoUsuarioAsync(CriarUsuarioDto dto);
        Task<IEnumerable<VisualizarUsuarioDto>> ListarUsuarios();
        Task<VisualizarUsuarioDto?> ObterUsuarioPorId(Guid id);
    }
}

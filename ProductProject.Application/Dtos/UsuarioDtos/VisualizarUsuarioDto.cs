namespace ProductProject.Application.Dtos.UsuarioDtos
{
    public class VisualizarUsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}

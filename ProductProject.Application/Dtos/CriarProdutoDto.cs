using ProductProject.Entities;

namespace ProductProject.Application.Dtos
{
    public class CriarProdutoDto
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Guid CriadoPorId { get; set; }
    }
}

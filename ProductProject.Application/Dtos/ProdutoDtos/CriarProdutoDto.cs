namespace ProductProject.Application.Dtos.ProdutoDtos
{
    public class CriarProdutoDto
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Guid CriadoPorId { get; set; }
    }
}

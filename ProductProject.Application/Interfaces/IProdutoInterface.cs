using ProductProject.Application.Dtos.ProdutoDtos;

namespace ProductProject.Application.Interfaces
{
    public interface IProdutoInterface
    {
        Task<VisualizarProdutoDto> NovoProdutoAsync(CriarProdutoDto dto);
        Task<IEnumerable<VisualizarProdutoDto>> ListarProdutos();
        Task<VisualizarProdutoDto?> ObterProdutoPorId(Guid id);
    }
}

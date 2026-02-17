using ProductProject.Application.Dtos.ProdutoDtos;

namespace ProductProject.Application.Interfaces
{
    public interface IProdutoInterface
    {
        Task<VisualizarProdutoDto> NovoProdutoAsync(CriarProdutoDto dto);
        Task<IEnumerable<VisualizarProdutoDto>> ListarProdutosAsync();
        Task<VisualizarProdutoDto?> ObterProdutoPorIdAsync(Guid id);
        Task<VisualizarProdutoDto?> AtualizarProdutoAsync(Guid id, AtualizarProdutoDto dto);
    }
}

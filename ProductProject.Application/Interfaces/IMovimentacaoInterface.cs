using ProductProject.Application.Dtos.MovimentacaoDtos;

namespace ProductProject.Application.Interfaces
{
    public interface IMovimentacaoInterface
    {
        Task<VisualizarMovimentacaoDto> NovaMovimentacaoAsync(CriarMovimentacaoDto dto);
    }
}

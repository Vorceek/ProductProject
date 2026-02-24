using ProductProject.Application.Dtos.MovimentacaoDtos;
using ProductProject.Application.Interfaces;
using ProductProject.Domain.Entidades;
using ProductProject.Infrastructure.Data;

namespace ProductProject.Application.Services
{
    public class MovimentacaoService(AppDbContext context) : IMovimentacaoInterface
    {
        private readonly AppDbContext _context = context;

        public async Task<VisualizarMovimentacaoDto> NovaMovimentacaoAsync(CriarMovimentacaoDto dto)
        {
            var movimentacao = new Movimentacao
            {
                ProdutoId = dto.ProdutoId,
                UsuarioId = dto.UsuarioId,
                Quantidade = dto.Quantidade,
                Tipo = dto.Tipo,
                Observacao = dto.Observacao
            };

            _context.Add(movimentacao);
            await _context.SaveChangesAsync();

            return new VisualizarMovimentacaoDto
            {
                Id = movimentacao.Id,
                ProdutoId = movimentacao.ProdutoId,
                UsuarioId = movimentacao.UsuarioId,
                Quantidade = movimentacao.Quantidade,
                Tipo = movimentacao.Tipo,
                Observacao = movimentacao.Observacao
            };
        }
    }
}

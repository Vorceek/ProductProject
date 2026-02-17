using Microsoft.EntityFrameworkCore;
using ProductProject.Application.Dtos.ProdutoDtos;
using ProductProject.Domain.Interfaces;
using ProductProject.Entities;
using ProductProject.Infrastructure.Data;

namespace ProductProject.Application.Services
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisualizarProdutoDto>> ListarProdutos()
        {
            return await _context.Produtos
                .Select(p => new VisualizarProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Quantidade = p.Quantidade,
                    CriadoPorId = p.CriadoPorId,
                })
                .ToListAsync();
        }

        public async Task<VisualizarProdutoDto?> ObterProdutoPorId(Guid id)
        {
            return await _context.Produtos
                .Select(p => new VisualizarProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Quantidade = p.Quantidade,
                    CriadoPorId = p.CriadoPorId,
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<VisualizarProdutoDto> NovoProdutoAsync(CriarProdutoDto dto)
        {
            var produto = new Produto 
            { 
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Quantidade = dto.Quantidade,
                CriadoPorId = dto.CriadoPorId,
                CriadoEm = DateTime.Now
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return new VisualizarProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                CriadoPorId = produto.CriadoPorId
            };
        }
    }
}

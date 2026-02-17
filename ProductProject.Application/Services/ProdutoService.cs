using Microsoft.EntityFrameworkCore;
using ProductProject.Application.Dtos.ProdutoDtos;
using ProductProject.Application.Interfaces;
using ProductProject.Entities;
using ProductProject.Infrastructure.Data;

namespace ProductProject.Application.Services
{
    public class ProdutoService(AppDbContext context) : IProdutoInterface
    {
        private readonly AppDbContext _context = context;

        public async Task<VisualizarProdutoDto> NovoProdutoAsync(CriarProdutoDto dto)
        {

            var produtoExiste = await _context.Usuarios
                .AnyAsync(u => u.Id == dto.CriadoPorId);

            if (!produtoExiste)
                throw new Exception("Usuário não encontrado.");

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

        public async Task<IEnumerable<VisualizarProdutoDto>> ListarProdutosAsync()
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

        public async Task<VisualizarProdutoDto?> ObterProdutoPorIdAsync(Guid id)
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

        public async Task<VisualizarProdutoDto?> AtualizarProdutoAsync(Guid id, AtualizarProdutoDto dto)
        {
            var produto = await _context.Produtos
                .FindAsync(id);

            if (produto == null) return null;

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Quantidade = dto.Quantidade;
            produto.ModificadoEm = DateTime.UtcNow;
            produto.ModificadoPorId = dto.ModificadoPorId;

            await _context.SaveChangesAsync();

            return new VisualizarProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Quantidade = dto.Quantidade,
                Descricao = produto.Descricao,
                CriadoPorId = produto.CriadoPorId,
                ModificadoPorId = produto.ModificadoPorId,
                ModificadoEm = produto.ModificadoEm
            };
        }
    }
}

using ProductProject.Application.Dtos;
using ProductProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Domain.Interfaces
{
    public interface IProdutoInterface
    {
        Task<VisualizarProdutoDto> NovoProdutoAsync(CriarProdutoDto dto);
        Task<IEnumerable<VisualizarProdutoDto>> ListarProdutos();
        Task<VisualizarProdutoDto?> ObterProdutoPorId(Guid id);
    }
}

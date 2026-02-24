using ProductProject.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Application.Dtos.MovimentacaoDtos
{
    public class VisualizarMovimentacaoDto
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Tipos Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public string Observacao { get; set; } = string.Empty;
    }
}

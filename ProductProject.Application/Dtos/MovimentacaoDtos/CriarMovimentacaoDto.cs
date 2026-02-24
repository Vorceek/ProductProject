using ProductProject.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Application.Dtos.MovimentacaoDtos
{
    public class CriarMovimentacaoDto
    {
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Tipos Tipo { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}

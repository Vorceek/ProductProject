using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Application.Dtos.ProdutoDtos
{
    public class AtualizarProdutoDto
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Guid? ModificadoPorId { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}

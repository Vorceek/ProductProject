using ProductProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Application.Dtos
{
    public class VisualizarProdutoDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public required Guid CriadoPorId { get; set; }
        public Usuario CriadoPor { get; set; } = null!;

        public DateTime? ModificadoEm { get; set; }
        public Guid? ModificadoPorId { get; set; }
        public Usuario? ModificadoPor { get; set; }
    }
}

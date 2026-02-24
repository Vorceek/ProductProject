using System.Data.SqlTypes;

namespace ProductProject.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }

        public int Quantidade { get; set; }
        public int? QuantidadeMinima { get; set; }

        public string? codigoSKU { get; set; }
        public decimal Preco { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public required Guid CriadoPorId { get; set; }
        public Usuario CriadoPor { get; set; } = null!;

        public DateTime? ModificadoEm { get; set; }
        public Guid? ModificadoPorId { get; set; }
        public Usuario? ModificadoPor { get; set; }

        public bool Ativo { get; set; } = true;
    }
}

namespace ProductProject.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public required Guid CriadoPorId { get; set; }
        public Usuario CriadoPor { get; set; } = null!;

        public DateTime? ModificadoEm { get; set; }
        public Guid? ModificadoPorId { get; set; }
        public Usuario? ModificadoPor { get; set; }
    }
}

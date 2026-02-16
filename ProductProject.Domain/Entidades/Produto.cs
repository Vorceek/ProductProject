namespace ProductProject.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public required Usuario CriadoPor { get; set; }
        public DateTime? ModificadoEm { get; set; }
        public Usuario? ModificadoPor { get; set; }
    }
}

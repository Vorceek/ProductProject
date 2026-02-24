namespace ProductProject.Domain.Entidades
{
    public enum Tipos
    {
        Entrada,
        Saida
    }

    public class Movimentacao
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Tipos Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}

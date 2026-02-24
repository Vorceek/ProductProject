using Microsoft.EntityFrameworkCore;
using ProductProject.Domain.Entidades;
using ProductProject.Entities;

namespace ProductProject.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
    }
}

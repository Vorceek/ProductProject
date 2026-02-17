using Microsoft.EntityFrameworkCore;
using ProductProject.Application.Dtos.UsuarioDtos;
using ProductProject.Application.Interfaces;
using ProductProject.Entities;
using ProductProject.Infrastructure.Data;

namespace ProductProject.Application.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VisualizarUsuarioDto>> ListarUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new VisualizarUsuarioDto
                {
                    Nome = u.Nome,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<VisualizarUsuarioDto> NovoUsuarioAsync(CriarUsuarioDto dto)
        {
            var novoUsuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return new VisualizarUsuarioDto
            {
                Id = novoUsuario.Id,
                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email
            };
        }

        public async Task<VisualizarUsuarioDto?> ObterUsuarioPorId(Guid id)
        {
            return await _context.Usuarios
                .Select(u => new VisualizarUsuarioDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                })
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductProject.Application.Interfaces;
using ProductProject.Application.Services;
using ProductProject.Domain.Interfaces;
using ProductProject.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona serviços ao container
builder.Services.AddControllers();

// Adiciona o Swagger (Precisa do pacote Swashbuckle instalado)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("ProductProject.Infrastructure")
    )
);

builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

var app = builder.Build();

// 2. Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
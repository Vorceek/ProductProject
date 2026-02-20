# ProductProject API

API REST desenvolvida com **ASP.NET Core**, aplicando conceitos de **Clean Architecture**, **Entity Framework Core** e **SQL Server**.

O projeto foi estruturado com separação clara de responsabilidades entre camadas, visando organização, escalabilidade e boas práticas de desenvolvimento backend.

---

## Arquitetura

Estrutura em camadas do projeto:

```text
ProductProject
├── ProductProject.Api             # Controllers e configuração da aplicação (Web/API)
├── ProductProject.Application     # DTOs, Interfaces e casos de uso (regras de aplicação)
├── ProductProject.Domain          # Entidades e regras de negócio (núcleo)
└── ProductProject.Infrastructure  # Persistência e integrações (EF Core, DbContext)
```

---

## Responsabilidade de cada camada

### Api
- Controllers
- Configuração de DI
- Endpoints HTTP

### Application
- DTOs (Create, Update, Read)
- Interfaces (contratos)
- Orquestração de casos de uso (regras de aplicação)

### Domain
- Entidades
- Regras de negócio puras

### Infrastructure
- DbContext
- Migrations (se estiverem aqui)
- Implementações de repositórios/serviços
- Persistência com Entity Framework Core

---

## 🛠 Tecnologias Utilizadas

- .NET (ASP.NET Core Web API)
- C#
- Entity Framework Core
- SQL Server
- Dependency Injection nativa do .NET
- Swagger

---

## Funcionalidades Implementadas

### Usuários
- Criar usuário
- Listar usuários
- Buscar por Id
- Atualizar usuário
- Remover usuário

### Produtos
- Criar produto
- Listar produtos
- Buscar por Id
- Atualizar produto
- Remover produto

---

## Padrões e Conceitos Aplicados

- Injeção de Dependência
- Separação de Camadas
- DTO Pattern
- Async/Await
- Scoped Services
- Uso de `readonly` para dependências

---

## Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/Vorceek/ProductProject.git
```

2. Configure a string de conexão no `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProductProjectDb;Trusted_Connection=True;"
}
```

3. Execute as migrations:

```bash
dotnet ef database update
```

4. Rode a aplicação:

```bash
dotnet run
```

5. Acesse o Swagger:

```text
https://localhost:{porta}/swagger
```

---

## Objetivo do Projeto

Este projeto foi desenvolvido com foco em:

- Evoluir habilidades em backend
- Aplicar arquitetura em camadas
- Construir uma base sólida para projetos maiores
- Criar um repositório com estrutura profissional

---

## Próximos Passos (Melhorias Futuras)

- Implementar validações com FluentValidation
- Adicionar autenticação com JWT
- Implementar testes unitários
- Adicionar logs estruturados
- Implementar paginação nas consultas

---

## Autor

Desenvolvido por Vinícius  
https://github.com/Vorceek

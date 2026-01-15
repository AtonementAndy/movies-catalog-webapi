# 🎬 Movies Catalog Web API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-11-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Uma Web API RESTful para gerenciamento de catálogo de filmes, construída com ASP.NET Core 8, implementando padrões modernos de arquitetura e boas práticas de desenvolvimento.

## 🚀 Tecnologias e Padrões

### Stack Principal
- **ASP.NET Core 8.0** - Framework web moderno e performático
- **C# 11** - Linguagem com recursos avançados
- **Dapper 2.1.35** - Micro ORM de alta performance
- **SQL Server** - Banco de dados relacional

### Arquitetura e Padrões
- **Clean Architecture** - Separação de responsabilidades em 3 camadas
- **CQRS (Command Query Responsibility Segregation)** - Separação de leitura e escrita
- **MediatR 11.1.0** - Implementação do padrão Mediator
- **Repository Pattern** - Abstração da camada de dados
- **Factory Pattern** - Gerenciamento de conexões com banco de dados
- **AutoMapper 12.0.1** - Mapeamento objeto-objeto
- **Dependency Injection** - Inversão de controle nativa do .NET

### Recursos Adicionais
- **Swagger/OpenAPI** - Documentação interativa da API
- **Exception Middleware** - Tratamento centralizado de erros
- **DTOs** - Objetos de transferência de dados imutáveis

## 📁 Estrutura do Projeto

```
CatalogoFilmesApp/
├── API/                          # Camada de Apresentação
│   ├── Controllers/              # Endpoints da API
│   ├── Middleware/               # Middlewares customizados
│   └── Errors/                   # Tratamento de erros
│
├── Application/                  # Camada de Aplicação
│   ├── Commands/                 # Comandos CQRS (Write)
│   ├── CommandsHandler/          # Handlers de comandos
│   ├── Queries/                  # Queries CQRS (Read)
│   └── QueriesHandler/           # Handlers de queries
│
├── Domain/                       # Camada de Domínio
│   ├── Models/                   # Entidades de domínio
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Interfaces/               # Contratos e abstrações
│   └── Mapping/                  # Perfis do AutoMapper
│
└── Infrastructure/               # Camada de Infraestrutura
    ├── Repositories/             # Implementação dos repositórios
    └── Service/                  # Serviços de infraestrutura
        └── DbConnectionFactory   # Factory de conexões
```

## 🎯 Funcionalidades

- ✅ **Criar filme** - Adicionar novos filmes ao catálogo
- ✅ **Listar filmes** - Consultar todos os filmes cadastrados
- ✅ **Buscar filme por ID** - Obter detalhes de um filme específico
- ✅ **Atualizar filme** - Modificar informações de filmes existentes
- ✅ **Remover filme** - Excluir filmes do catálogo
- ✅ **Tratamento de erros** - Respostas padronizadas e informativas
- ✅ **Documentação Swagger** - Interface interativa para testes

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express ou superior)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/) com C# extension
- [Git](https://git-scm.com/)

## 🚀 Como Executar

### 1. Clone o repositório
```bash
git clone https://github.com/AtonementAndy/movies-catalog-webapi.git
cd movies-catalog-webapi
```

### 2. Configure o banco de dados

Atualize a string de conexão no `appsettings.json` se necessário:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FilmesDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Crie o banco de dados

Execute o script SQL para criar a estrutura do banco:

```sql
CREATE DATABASE FilmesDb;
GO

USE FilmesDb;
GO

CREATE TABLE Filmes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(200) NOT NULL,
    Diretor NVARCHAR(100) NOT NULL,
    AnoLancamento INT NOT NULL,
    Genero NVARCHAR(50) NOT NULL,
    Duracao INT NOT NULL,
    DataCriacao DATETIME DEFAULT GETDATE()
);
```

### 4. Restaure as dependências
```bash
cd CatalogoFilmesApp
dotnet restore
```

### 5. Execute a aplicação
```bash
dotnet run
```

A API estará disponível em:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`
- **Swagger:** `https://localhost:5001` (página inicial)

## 📚 Documentação da API

Após executar o projeto, acesse o Swagger UI para visualizar e testar todos os endpoints:

```
https://localhost:5001
```

### Exemplos de Endpoints

#### Criar um novo filme
```http
POST /api/filmes
Content-Type: application/json

{
  "titulo": "Matrix",
  "diretor": "Lana Wachowski",
  "anoLancamento": 1999,
  "genero": "Ficção Científica",
  "duracao": 136
}
```

#### Listar todos os filmes
```http
GET /api/filmes
```

#### Buscar filme por ID
```http
GET /api/filmes/1
```

#### Atualizar filme
```http
PUT /api/filmes/1
Content-Type: application/json

{
  "id": 1,
  "titulo": "Matrix Reloaded",
  "diretor": "Lana Wachowski",
  "anoLancamento": 2003,
  "genero": "Ficção Científica",
  "duracao": 138
}
```

#### Deletar filme
```http
DELETE /api/filmes/1
```

## 🏗️ Arquitetura

### Fluxo de Requisição

```
Controller → MediatR → Command/Query Handler → Repository → Database
                                              ↓
                                          AutoMapper
                                              ↓
                                             DTO
```

### Camadas

**API Layer (Apresentação)**
- Recebe requisições HTTP
- Valida entrada
- Envia comandos/queries via MediatR
- Retorna respostas formatadas

**Application Layer (Aplicação)**
- Implementa casos de uso
- Orquestra fluxo de negócio
- Handlers do MediatR (CQRS)

**Domain Layer (Domínio)**
- Entidades de negócio
- Interfaces e contratos
- Regras de domínio

**Infrastructure Layer (Infraestrutura)**
- Acesso a dados (Dapper)
- Implementação de repositórios
- Serviços externos

## 🧪 Testes

```bash
# Em desenvolvimento
dotnet test
```

## 📦 Pacotes Utilizados

```xml
<PackageReference Include="Dapper" Version="2.1.35" />
<PackageReference Include="MediatR" Version="11.1.0" />
<PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="11.1.0" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
<PackageReference Include="Microsoft.Data.SqlClient" Version="5.2.2" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
<PackageReference Include="OneOf" Version="3.0.271" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

## 🎓 Aprendizados e Objetivos

Este projeto foi desenvolvido com o objetivo de:

- ✅ Dominar o padrão **CQRS** com MediatR
- ✅ Implementar **Clean Architecture** em APIs .NET
- ✅ Utilizar **Dapper** como alternativa ao Entity Framework
- ✅ Aplicar **Design Patterns** (Repository, Factory, Mediator)
- ✅ Praticar **Dependency Injection** e **Inversion of Control**
- ✅ Criar APIs RESTful seguindo boas práticas
- ✅ Documentar APIs com Swagger/OpenAPI

## 🔄 Próximas Implementações

- [ ] Autenticação e Autorização (JWT)
- [ ] Paginação e filtros avançados
- [ ] Logging estruturado (Serilog)
- [ ] Testes unitários e de integração
- [ ] Cache com Redis
- [ ] Rate Limiting
- [ ] Docker e Docker Compose
- [ ] CI/CD pipeline

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer um Fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abrir um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👤 Autor

**Anderson (AtonementAndy)**

- GitHub: [@AtonementAndy](https://github.com/AtonementAndy)
- LinkedIn: [Andre Santos](https://www.linkedin.com/in/andre-saantos/)

---

⭐ Se este projeto foi útil para você, considere dar uma estrela!

**Feito com ❤️ e C#**

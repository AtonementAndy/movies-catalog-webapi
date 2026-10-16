# 🎬 Movies Catalog Web API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-11-239120?logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

A RESTful Web API for managing a movie catalog, built with ASP.NET Core 8, implementing modern architectural patterns and development best practices.

## 🚀 Technologies and Patterns

### Main Stack
- **ASP.NET Core 8.0** - Modern and high-performance web framework
- **C# 11** - Language with advanced features
- **Dapper 2.1.35** - High-performance Micro ORM
- **SQL Server** - Relational database

### Architecture and Patterns
- **Clean Architecture** - Separation of concerns into 3 layers
- **CQRS (Command Query Responsibility Segregation)** - Separation of reads and writes
- **MediatR 11.1.0** - Mediator pattern implementation
- **Repository Pattern** - Data layer abstraction
- **Factory Pattern** - Database connection management
- **AutoMapper 12.0.1** - Object-to-object mapping
- **Dependency Injection** - Native .NET Inversion of Control

### Additional Features
- **Swagger/OpenAPI** - Interactive API documentation
- **Exception Middleware** - Centralized error handling
- **DTOs** - Immutable data transfer objects

## 📁 Project Structure

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

## 🎯 Features

- ✅ **Create movie** - Add new movies to the catalog
- ✅ **List movies** - Query all registered movies
- ✅ **Get movie by ID** - Retrieve details of a specific movie
- ✅ **Update movie** - Modify existing movie information
- ✅ **Remove movie** - Delete movies from the catalog
- ✅ **Error handling** - Standardized and informative responses
- ✅ **Swagger documentation** - Interactive interface for testing

## 🛠️ Prerequisites

Before you begin, make sure you have installed:

- [NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express, or higher)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with C# extension
- [Git](https://git-scm.com/)

## 🚀 How to Run

### 1. Clone the repository
```bash

git clone https://github.com/AtonementAndy/movies-catalog-webapi.git

cd movies-catalog-webapi
```

```bash
git clone https://github.com/AtonementAndy/movies-catalog-webapi.git

cd movies-catalog-webapi
```

### 2. Configure the database

Update the connection string in appsettings.json if necessary:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FilmesDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Create the database

Run the SQL script to create the database structure:

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

### 4. Restore dependencies
```bash
cd CatalogoFilmesApp
dotnet restore
```

### 5. Run the application
```bash
dotnet run
```

The API will be available at:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`
- **Swagger:** `https://localhost:5001` (página inicial)

## 📚 API Documentation

After running the project, access the Swagger UI to view and test all endpoints:

```
https://localhost:5001
```

### Endpoint Examples

#### Create a new movie
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

#### List all movies
```http
GET /api/filmes
```

#### Get movie by ID
```http
GET /api/filmes/1
```

#### Update movie
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

#### Delete movie
```http
DELETE /api/filmes/1
```

## 🏗️ Architecture

### Request Flow

```
Controller → MediatR → Command/Query Handler → Repository → Database
                                              ↓
                                          AutoMapper
                                              ↓
                                             DTO
```

### Layers

**API Layer (Presentation)**
  - Receives HTTP requests
  - Validates input
  - Dispatches commands/queries via MediatR
  - Returns formatted responses

**Application Layer**
  - Implements use cases
  - Orchestrates business flow
  - MediatR handlers (CQRS)

**Domain Layer**

  - Business entities
  - Interfaces and contracts
  - Domain rules

**Infrastructure Layer**
  - Data access (Dapper)
  - Repository implementations
  - External services

## 🧪 Tests

```bash
# Em desenvolvimento
dotnet test
```

## 📦 Packages Used

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

## 🎓 Learnings and Objectives

This project was developed with the objective of:

- ✅ Mastering the CQRS pattern with MediatR
- ✅ Implementing Clean Architecture in .NET APIs
- ✅ Using Dapper as an alternative to Entity Framework
- ✅ Applying Design Patterns (Repository, Factory, Mediator)
- ✅ Practicing **Dependency Injection** and **Inversion of Control**
- ✅ Creating RESTful APIs following best practices
- ✅ Documenting APIs with Swagger/OpenAPI

## 🔄 Upcoming Implementations

- [ ] Authentication and Authorization (JWT)
- [ ] Pagination and advanced filters
- [ ] Structured logging (Serilog)
- [ ] Unit and integration tests
- [ ] Caching with Redis
- [ ] Rate Limiting
- [ ] Docker and Docker Compose
- [ ] CI/CD pipeline
      
## 🤝 Contributing

Contribuições são bem-vindas! Sinta-se à vontade para:

Fork the project

1. Create your feature branch (`git checkout -b feature/MyFeature`)
2. Commit your changes (`git commit -m 'Add some feature'`)
3. Push to the branch (`git push origin feature/MyFeature`)
4. Open a Pull Request

## 📄 Licence

This project is licensed under the MIT License. See the LICENSE file for details.

## 👤 Author

**Andre (AtonementAndy)**

- GitHub: [@AtonementAndy](https://github.com/AtonementAndy)
- LinkedIn: [Andre Santos](https://www.linkedin.com/in/andre-saantos/)

---

⭐ If this project was useful to you, please consider giving it a star!

**Made with ❤️ and C#**

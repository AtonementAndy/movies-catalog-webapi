# Projeto Catalogo de Filmes WebAPI (ASPNET Core)

### Em que consiste este projeto?

Estou criando este projeto, para explorar as tecnologias mais usadas em criação de API em ASPNET Core, para ir ganhando conhecimento e melhorar minhas habilidades.

1. Projeto criado, adicionando o projeto
  * [realease/primeiro-commit](https://github.com/AtonementAndy/catalogo-filmes-api/tree/028490677b89dfd103531ba902809ea3e6bbf14a).

Neste primeiro commit adicionei a base do projeto. Adicionando alguns pacotes:
Dapper (2.1.35)

2. Adicionado, DTO, Service, Interfaces e controllers
  * [realease/primeira-atualização](https://github.com/AtonementAndy/catalogo-filmes-api/tree/ae3256c749d9fdb219a694c832a157c61bde9cf7).

No segundo commit foi implementado uma estrutura de DDD(Domain Driven Design)(um pouco), DTO, IDbConnectionFactory(Fábrica), Interfaces, Service e Controller.

3. Adicionando Mediator, CQRS, Sql Server, modificação da Controller
  * [release/Atualização-e-implementação](https://github.com/AtonementAndy/catalogo-filmes-api/commit/ebde551e2462aebcef7b180034496a49b58dbcde#diff-0d29d3ac444b99ef8becb21d94ba335a9d81d769311e31de79b9ec39c83a5c57)

Nesse commit, implementei AutoMapper, Mediator com padrão CQRS, modificação da Controller e gravar no banco de dados Sql Server. 
Pacotes: 
Microsoft.Data.SqlClient (5.2.2), MediatR (11.1.0), MediatR.Extensions.Microsoft.DependencyInjection (11.1.0), AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)

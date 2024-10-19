# WebAPI Movie Catalog Project (ASPNET Core)

### What does this project consist of?

I am creating this project to explore the most used technologies in API creation in ASPNET Core, to gain knowledge and improve my skills.

1. Project created, adding the project
  * [first-commit](https://github.com/AtonementAndy/catalogo-filmes-api/tree/028490677b89dfd103531ba902809ea3e6bbf14a).

In this first commit I added the base of the project. Adding some packages:
Dapper (2.1.35)

2. Added DTO, Service, Interfaces and controllers
  * [first-update](https://github.com/AtonementAndy/catalogo-filmes-api/tree/ae3256c749d9fdb219a694c832a157c61bde9cf7).

In the second commit, a DDD (Domain Driven Design) structure (a little), DTO, IDbConnectionFactory (Factory), Interfaces, Service and Controller were implemented.

3. Adding Mediator, CQRS, Sql Server, Controller modification
  * [update-and-implementation](https://github.com/AtonementAndy/catalogo-filmes-api/commit/ebde551e2462aebcef7b180034496a49b58dbcde#diff-0d29d3ac444b99ef8becb21d94ba335a9d81d769311e31de79b9ec39c83a5c57)

In this commit, I implemented AutoMapper, Mediator with CQRS pattern, modification of the Controller and writing to the Sql Server database.
Packages: 
Microsoft.Data.SqlClient (5.2.2), MediatR (11.1.0), MediatR.Extensions.Microsoft.DependencyInjection (11.1.0), AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)

4. Adding improvements and more DTOs
 * [Refatoring model e dtos](https://github.com/AtonementAndy/catalogo-filmes-api/commit/f5c44226d8ebfd33e02a4a365966ddb80b166b6a)

I added model encapsulation improvements, creating methods, and more Dtos. I believe that this way, the model is inaccessible externally and the dtos became "immutable", changing from class to "record" and using the "init" keyword.

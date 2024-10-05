using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace CatalogoFilmesApp.Infrastructure.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory = default!;

        public FilmesRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<Filme>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Filmes";
            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                var filme = await connection.QueryAsync<Filme>(sql);

                return filme.ToList();
            }
        }

        public async Task<Filme> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Titulo, Descricao, Autor, Ativo FROM Filmes WHERE Id = @Id";
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var filme = await connection.QuerySingleOrDefaultAsync<Filme>(sql, new { Id = id });
                return filme;
            }
        }

        public async Task<Filme> AddAsync(Filme filme)
        {
            const string sql = "INSERT INTO Filmes (Titulo, Descricao, Autor, Ativo) VALUES (@Titulo, @Descricao, @Autor, @Ativo); SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleAsync<Filme>(sql, filme);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var parameter = new { id };

            const string sql = "UPDATE Filmes SET Ativo = 0 WHERE Id = @id";
            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameter);
            }
        }

        public async Task UpdateAsync(Filme filme)
        {
            var parameter = new
            {
                filme.Id,
                filme.Titulo,
                filme.Descricao,
                filme.Autor,
                filme.Ativo
            };

            const string sql = "UPDATE Filmes SET Titulo = @Titulo, Descricao = @Descricao, Autor = @Autor, Ativo = @Ativo WHERE Id = @id";

            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                await connection.ExecuteAsync(sql, parameter);
            }
        }
    }
}

using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Dapper;
using System.Security.AccessControl;

namespace CatalogoFilmesApp.Infrastructure.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly ILogger<FilmesRepository> _logger;
        private readonly IDbConnectionFactory _dbConnectionFactory = default!;

        public FilmesRepository(ILogger<FilmesRepository> logger, IDbConnectionFactory dbConnectionFactory)
        {
            _logger = logger;
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<Filme>> GetAllAsync()
        {
            _logger.LogInformation("Buscando todos os filmes na classe Serviço FilmeRepository.");

            const string sql = "SELECT * FROM Filmes";
            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                var filme = await connection.QueryAsync<Filme>(sql);

                return filme.ToList();
            }
        }

        public async Task<Filme> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Buscando filme por Id {id} na classe Serviço FilmeRepository");

            const string query = "SELECT Id, Titulo, Descricao, DataCadastro, Autor, Ativo FROM Filmes WHERE Id = @Id";
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var filme = await connection.QuerySingleOrDefaultAsync<Filme>(query, new { Id = id });

                return filme;
            }
        }

        public async Task<Filme> AddAsync(Filme filme)
        {
            _logger.LogInformation("Criando um novo filme na classe de Serviço FilmeRepository.");

            const string query = "INSERT INTO Filmes (Titulo, Descricao, DataCadastro, Autor, Ativo) VALUES (@Titulo, @Descricao, @DataCadastro, @Autor, @Ativo); SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleAsync<Filme>(query, filme);
            }
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Deletando um filme na classe de Serviço FilmeRepository.");

            var parameter = new { id };

            const string query = "UPDATE Filmes SET Ativo = 0 WHERE Id = @id";
            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }

        public async Task UpdateAsync(Filme filme)
        {
            _logger.LogInformation("Atualizando um filme na classe de Serviço FilmeRepository.");

            var parameter = new
            {
                filme.Id,
                filme.Titulo,
                filme.Descricao,
                filme.DataCadastro,
                filme.Autor,
                filme.Ativo
            };

            const string query = "UPDATE Filmes SET Titulo = @Titulo, Descricao = @Descricao, Autor = @Autor, DataCadastro = @DataCadastro, Ativo = @Ativo WHERE Id = @id";

            using(var connection = _dbConnectionFactory.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }
    }
}


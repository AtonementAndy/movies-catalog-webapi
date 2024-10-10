using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Dapper;

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
            using var connection = _dbConnectionFactory.CreateConnection();
            var filme = await connection.QueryAsync<Filme>(sql);

            return filme.ToList();
        }

        public async Task<Filme> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser um valor positivo.", nameof(id));

            _logger.LogInformation($"Buscando filme por Id {id} na classe Serviço FilmeRepository");
            const string query = "SELECT Id, Titulo, Descricao, DataCadastro, Autor, Ativo FROM Filmes WHERE Id = @Id";

            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                var filme = await connection.QuerySingleOrDefaultAsync<Filme>(query, new { Id = id });

                if (filme is null)
                {
                    _logger.LogWarning($"Filme com Id {id} não encontrado.");
                    throw new KeyNotFoundException($"Filme com Id {id} não encontrado.");
                }

                return filme;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar filme por Id");
                throw;
            }
        }

        public async Task<Filme> AddAsync(FilmesDto filmesDto)
        {
            if (filmesDto is null)
                throw new ArgumentNullException(nameof(filmesDto), "Filme não pode ser nulo.");

            _logger.LogInformation("Criando um novo filme na classe de Serviço FilmeRepository.");
            const string query = "INSERT INTO Filmes (Titulo, Descricao, DataCadastro, Autor, Ativo) VALUES (@Titulo, @Descricao, @DataCadastro, @Autor, @Ativo); SELECT CAST(SCOPE_IDENTITY() as int);";                

            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                var id = await connection.QuerySingleAsync<int>(query, filmesDto);

                return new Filme
                (
                    id, 
                    filmesDto.Titulo, 
                    filmesDto.Descricao, 
                    filmesDto.Autor, 
                    filmesDto.DataCadastro, 
                    filmesDto.Ativo
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar filme.");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser um valor positivo.", nameof(id));

            _logger.LogInformation("Deletando um filme na classe de Serviço FilmeRepository.");
            var parameter = new { id };
            const string query = "UPDATE Filmes SET Ativo = 0 WHERE Id = @id";

            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                await connection.ExecuteAsync(query, parameter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar filme.");
                throw;
            }
        }

        public async Task UpdateAsync(int id, FilmesDto filmeDto)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser um valor positivo.", nameof(id));

            if (filmeDto is null)
                throw new ArgumentNullException(nameof(filmeDto), "Filme não pode ser nulo.");

            _logger.LogInformation("Atualizando um filme .");
            const string query = "UPDATE Filmes SET Titulo = @Titulo, Descricao = @Descricao, Autor = @Autor, DataCadastro = @DataCadastro, Ativo = @Ativo WHERE Id = @Id";

            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                var affectedRows = await connection.ExecuteAsync(query, new { filmeDto.Titulo, filmeDto.Descricao, filmeDto.Autor, filmeDto.DataCadastro, filmeDto.Ativo, Id = id });

                if (affectedRows == 0)
                    _logger.LogWarning($"Nenhum filme encontrado com Id {id} para atualização.");
                else
                    _logger.LogInformation($"Filme com Id {id} atualizado com sucesso.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar filme com Id {Id}.", id);
                throw;
            }
        }
    }
}


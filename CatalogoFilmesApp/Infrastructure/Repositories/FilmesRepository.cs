using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Dapper;

namespace CatalogoFilmesApp.Infrastructure.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private readonly ILogger<FilmesRepository> _logger;
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public FilmesRepository(ILogger<FilmesRepository> logger, IDbConnectionFactory dbConnectionFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbConnectionFactory = dbConnectionFactory ?? throw new ArgumentNullException(nameof(dbConnectionFactory));
        }

        public async Task<IEnumerable<FilmesDto>> GetAllAsync()
        {
            _logger.LogInformation("Buscando todos os filmes.");
            const string sql = "SELECT * FROM Filmes WHERE Ativo = 1";
            using var connection = _dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<FilmesDto>(sql);
        }

        public async Task<FilmesDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ter um valor positivo.", nameof(id));

            _logger.LogInformation($"Buscando filme por Id {id}.");
            const string query = "SELECT * FROM Filmes WHERE Id = @Id AND Ativo = 1";

            using var connection = _dbConnectionFactory.CreateConnection();
            var filme = await connection.QuerySingleOrDefaultAsync<FilmesDto>(query, new { Id = id });

            if (filme is null)
            {
                _logger.LogWarning($"Filme com Id {id} não encontrado.");
                throw new KeyNotFoundException($"Filme com Id {id} não encontrado.");
            }

            return filme;
        }

        public async Task<FilmesDto> AddAsync(CriarFilmeDto criarFilmeDto)
        {
            if (criarFilmeDto is null)
                throw new ArgumentNullException(nameof(criarFilmeDto), "Dados do filme não podem ser nulos.");

            _logger.LogInformation("Criando um novo filme.");
            const string query = @"
                INSERT INTO Filmes (Titulo, Descricao, Autor, DataCadastro, Ativo) 
                VALUES (@Titulo, @Descricao, @Autor, @DataCadastro, @Ativo);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            var parameters = new
            {
                criarFilmeDto.Titulo,
                criarFilmeDto.Descricao,
                criarFilmeDto.Autor,
                DataCadastro = DateTime.UtcNow,
                Ativo = true
            };

            using var connection = _dbConnectionFactory.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(query, parameters);

            return new FilmesDto 
            { 
                Id = id, 
                Titulo = criarFilmeDto.Titulo, 
                Descricao = criarFilmeDto.Descricao, 
                Autor = criarFilmeDto.Autor, 
                DataCadastro = DateTime.UtcNow, 
                Ativo = true 
            };
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser um valor positivo.", nameof(id));

            _logger.LogInformation($"Desativando filme com Id {id}.");
            const string query = "UPDATE Filmes SET Ativo = 0 WHERE Id = @Id";

            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                var linhasAfetadas = await connection.ExecuteAsync(query, new { Id = id });

                if (linhasAfetadas == 0)
                    _logger.LogWarning($"Nenhum filme encontrado com Id {id} para desativação.");
                else
                    _logger.LogInformation($"Filme com Id {id} desativado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao desativar filme com Id {id}.");
                throw;
            }
        }

        public async Task UpdateAsync(int id, AtualizarFilmeDto atualizarFilmeDto)
        {
            if (id <= 0)
                throw new ArgumentException("Id deve ser um valor positivo.", nameof(id));
                
            var filme = await GetByIdAsync(id);
            if (filme is null)
                throw new KeyNotFoundException($"Filme com Id {id} não encontrado.");

            _logger.LogInformation($"Atualizando filme com Id {id}.");
            const string query = @"
                UPDATE Filmes SET 
                    Titulo = @Titulo, 
                    Descricao = @Descricao, 
                    Autor = @Autor, 
                    DataCadastro = @DataCadastro, 
                    Ativo = @Ativo 
                WHERE Id = @Id";

            try
            {
                var connection = _dbConnectionFactory.CreateConnection();
                var linhasAfetadas = await connection.ExecuteAsync(query, 
                    new {
                        atualizarFilmeDto.Titulo,
                        atualizarFilmeDto.Descricao,
                        atualizarFilmeDto.Autor,
                        DataCadastro = DateTime.UtcNow,
                        Ativo = true,
                        Id = id
                    });

                if (linhasAfetadas == 0)
                    _logger.LogWarning($"Nenhum filme encontrado com Id {id} para atualização.");
                else
                    _logger.LogInformation($"Filme com Id {id} atualizado com sucesso.");    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar filme.");
                throw;
            };
        }
    }
}

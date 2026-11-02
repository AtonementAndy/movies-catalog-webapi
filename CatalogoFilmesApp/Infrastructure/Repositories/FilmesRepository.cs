using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Dapper;

namespace CatalogoFilmesApp.Infrastructure.Repositories
{
    public class FilmesRepository(
        ILogger<FilmesRepository>
        logger, IDbConnectionFactory dbConnectionFactory) : IFilmesRepository
    {
        public async Task<IEnumerable<Filme>> GetAllAsync()
        {
            logger.LogInformation("Buscando todos os filmes.");
            const string sql = "SELECT * FROM Filmes WHERE Ativo = 1";
            using var connection = dbConnectionFactory.CreateConnection();
            return await connection.QueryAsync<Filme>(sql);
        }

        public async Task<Filme> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id é obrigatório.", nameof(id));

            logger.LogInformation($"Buscando filme por Id {id}.");
            const string query = "SELECT * FROM Filmes WHERE Id = @Id AND Ativo = 1";

            using var connection = dbConnectionFactory.CreateConnection();
            var filme = await connection.QuerySingleOrDefaultAsync<Filme>(query, new { Id = id });

            if (filme is null)
            {
                logger.LogWarning($"Filme com Id {id} não encontrado.");
                throw new KeyNotFoundException($"Filme com Id {id} não encontrado.");
            }

            return filme;
        }

        public async Task<Filme> AddAsync(Filme filme)
        {
            if (filme is null)
                throw new ArgumentNullException(nameof(filme), "Dados do filme não podem ser nulos.");

            logger.LogInformation("Criando um novo filme.");
            const string query = @"
                INSERT INTO Filmes (Titulo, Descricao, Autor, DataCadastro, Ativo) 
                VALUES (@Titulo, @Descricao, @Autor, @DataCadastro, @Ativo);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            try
            {
                using var connection = dbConnectionFactory.CreateConnection();
                var id = await connection.QuerySingleAsync<Guid>(query, filme);

                return new Filme(
                    filme.Titulo,
                    filme.Descricao,
                    filme.Autor
                );

            }
            catch (Exception ex)
            {
                logger.LogError($"Ocorreu um erro ao cadastrar o filme {filme.Titulo}.", ex.Message);
                throw;
                //return Results.Conflict(new { Error = ex.Message });
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id é obrigatório.", nameof(id));

            logger.LogInformation($"Desativando filme com Id {id}.");
            const string query = "UPDATE Filmes SET Ativo = 0 WHERE Id = @Id";

            try
            {
                using var connection = dbConnectionFactory.CreateConnection();
                var linhasAfetadas = await connection.ExecuteAsync(query, new { Id = id });

                if (linhasAfetadas == 0)
                    logger.LogWarning($"Nenhum filme encontrado com Id {id} para desativação.");
                else
                    logger.LogInformation($"Filme com Id {id} desativado com sucesso.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Erro ao desativar filme com Id {id}.");
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, Filme filme)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id é obrigatório.", nameof(id));

            //var filme = await GetByIdAsync(id) ?? throw new KeyNotFoundException($"Filme com Id {id} não encontrado.");

            logger.LogInformation($"Atualizando filme com Id {id}.");
            const string query = @"
                UPDATE Filmes SET 
                    Titulo = @Titulo, 
                    Descricao = @Descricao, 
                    Autor = @Autor, 
                    DataCadastro = @DataCadastro, 
                    Ativo = @Ativo 
                WHERE Id = @Id";

            var parameters = new
            {
                filme.Titulo,
                filme.Descricao,
                filme.Autor,
                DataCadastro = DateTime.UtcNow,
                Ativo = true,
                Id = id
            };

            try
            {
                var connection = dbConnectionFactory.CreateConnection();
                var linhasAfetadas = await connection.ExecuteAsync(query, parameters);

                if (linhasAfetadas == 0)
                    logger.LogWarning($"Nenhum filme encontrado com Id {id} para atualização.");
                else
                    logger.LogInformation($"Filme com Id {id} atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao atualizar filme.");
                throw;
            }
            ;
        }
    }
}

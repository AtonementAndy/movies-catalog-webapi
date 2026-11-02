using CatalogoFilmesApp.Application.DTOs;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task<FilmesDto> GetByIdAsync(Guid id);
        Task<IEnumerable<FilmesDto>> GetAllAsync();
        Task<FilmesDto> AddAsync(CriarFilmeDto criarFilmeDto);
        Task UpdateAsync(Guid id, AtualizarFilmeDto atualizarFilmeDto);
        //Task UpdatePatchAsync(Filme filme);
        Task DeleteAsync(Guid id);
    }
}

using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Models;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task<FilmesDto> GetByIdAsync(int id);
        Task<IEnumerable<FilmesDto>> GetAllAsync();
        Task<FilmesDto> AddAsync(CriarFilmeDto criarFilmeDto);
        Task UpdateAsync(int id, AtualizarFilmeDto atualizarFilmeDto);
        //Task UpdatePatchAsync(Filme filme);
        Task DeleteAsync(int id);
    }
}

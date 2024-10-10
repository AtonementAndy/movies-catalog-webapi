using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Models;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task<Filme> GetByIdAsync(int id);
        Task<List<Filme>> GetAllAsync();
        Task<Filme> AddAsync(FilmesDto filmeDto);
        Task UpdateAsync(int id, FilmesDto filmeDto);
        //Task UpdatePatchAsync(Filme filme);
        Task DeleteAsync(int id);
    }
}

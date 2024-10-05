using CatalogoFilmesApp.Domain.Models;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task<Filme> GetByIdAsync(int id);
        Task<List<Filme>> GetAllAsync();
        Task<Filme> AddAsync(Filme filme);
        Task UpdateAsync(Filme filme);
        Task DeleteAsync(int id);
    }
}

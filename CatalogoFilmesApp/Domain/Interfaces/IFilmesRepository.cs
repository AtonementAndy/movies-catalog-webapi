using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Domain.Models;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IFilmesRepository
    {
        Task<Filme> GetByIdAsync(Guid id);
        Task<IEnumerable<Filme>> GetAllAsync();
        Task<Filme> AddAsync(Filme criarFilmeDto);
        Task UpdateAsync(Guid id, Filme atualizarFilmeDto);
        //Task UpdatePatchAsync(Filme filme);
        Task DeleteAsync(Guid id);
    }
}

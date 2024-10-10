using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class DeleteFilmeCommand(int id) : IRequest<FilmesDto>
    {
        public int Id { get; set; } = id;
    }
}

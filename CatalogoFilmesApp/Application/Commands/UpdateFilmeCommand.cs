using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class UpdateFilmeCommand : IRequest<FilmesDto>
    {
        public FilmesDto FilmesDto { get; set; }
    }
}

using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class DeleteFilmeCommand : IRequest<FilmesDto>
    {
        public int Id { get; set; }

        public DeleteFilmeCommand(int id)
        {
            Id = id;
        }
    }
}

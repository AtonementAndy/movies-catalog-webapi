using CatalogoFilmesApp.Application.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Queries
{
    public class GetFilmeByIdQuery(Guid id) : IRequest<FilmesDto>
    {
        public Guid Id { get; set; } = id;
    }
}

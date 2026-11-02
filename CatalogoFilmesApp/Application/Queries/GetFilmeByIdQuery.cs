using CatalogoFilmesApp.Application.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Queries
{
    public class GetFilmeByIdQuery(int id) : IRequest<FilmesDto>
    {
        public int Id { get; set; } = id;
    }
}

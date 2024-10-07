using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Queries
{
    public class GetFilmeByIdQuery : IRequest<FilmesDto>
    {
        public int Id { get; set; }

        public GetFilmeByIdQuery(int id)
        {
            Id = id;
        }
    }
}

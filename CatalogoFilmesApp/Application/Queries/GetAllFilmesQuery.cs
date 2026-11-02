using CatalogoFilmesApp.Application.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Queries
{
    public class GetAllFilmesQuery : IRequest<List<FilmesDto>>
    {

    }
}

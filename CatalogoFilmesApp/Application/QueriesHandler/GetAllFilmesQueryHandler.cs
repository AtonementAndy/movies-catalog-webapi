using AutoMapper;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Application.Queries;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.QueriesHandler
{
    public class GetAllFilmesQueryHandler(
        IFilmesRepository filmesRepository, 
        ILogger<GetAllFilmesQueryHandler> logger) : IRequestHandler<GetAllFilmesQuery, List<FilmesDto>>
    {
        public async Task<List<FilmesDto>> Handle(GetAllFilmesQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Buscando todos os filmes via CQRS.");

            var filmes = await filmesRepository.GetAllAsync();
            return [.. filmes];
        }
    }
}

using AutoMapper;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Application.Queries;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.QueriesHandler
{
    public class GetFilmeByIdQueryHandler(
        IFilmesRepository filmesRepository, 
        ILogger<GetFilmeByIdQueryHandler> logger) : IRequestHandler<GetFilmeByIdQuery, FilmesDto>
    {
        public async Task<FilmesDto> Handle(GetFilmeByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Buscando filme por Id via CQRS.");

            var filme = await filmesRepository.GetByIdAsync(request.Id);
            return filme;
        }
    }
}

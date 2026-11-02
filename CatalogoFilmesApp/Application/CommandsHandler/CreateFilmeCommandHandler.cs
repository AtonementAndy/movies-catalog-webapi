using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class CreateFilmeCommandHandler(
        IFilmesRepository filmesRepository,
        ILogger<CreateFilmeCommandHandler> logger) : IRequestHandler<CreateFilmeCommand, FilmesDto>
    {
        public async Task<FilmesDto> Handle(CreateFilmeCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cadastrando um novo filme: {request.CriarFilmeDto.Titulo}");

            var filme = await filmesRepository.AddAsync(request.CriarFilmeDto);
            return filme;
        }
    }
}

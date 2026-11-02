using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class DeleteFilmeCommandHandler(
        IFilmesRepository filmesRepository,
        ILogger<DeleteFilmeCommandHandler> logger) : IRequestHandler<DeleteFilmeCommand, FilmesDto>
    {

        public async Task<FilmesDto> Handle(DeleteFilmeCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deletando um filme via CQRS.");

            var filme = await filmesRepository.GetByIdAsync(request.Id);
            await filmesRepository.DeleteAsync(filme.Id);
            return filme;
        }
    }
}

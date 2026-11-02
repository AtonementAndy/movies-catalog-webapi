using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class CreateFilmeCommandHandler(
        IFilmesRepository filmesRepository,
        IMapper mapper,
        ILogger<CreateFilmeCommandHandler> logger) : IRequestHandler<CreateFilmeCommand, FilmesDto>
    {
        public async Task<FilmesDto> Handle(CreateFilmeCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Cadastrando um novo filme: {request.CriarFilmeDto.Titulo}");

            var filmeMapped = mapper.Map<Filme>(request.CriarFilmeDto);

            var filme = await filmesRepository.AddAsync(filmeMapped);
            return mapper.Map<FilmesDto>(filme);
        }
    }
}

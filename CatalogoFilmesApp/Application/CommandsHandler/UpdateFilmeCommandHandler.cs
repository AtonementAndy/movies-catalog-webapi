using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Application.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class UpdateFilmeCommandHandler(
        IFilmesRepository filmesRepository, 
        IMapper mapper, 
        ILogger<UpdateFilmeCommandHandler> logger) : IRequestHandler<UpdateFilmeCommand, AtualizarFilmeDto>
    {
        public async Task<AtualizarFilmeDto> Handle(UpdateFilmeCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Atualizando filme {request.AtualizarFilmeDto.Titulo}.");

            var filme = mapper.Map<Filme>(request.AtualizarFilmeDto);
            await filmesRepository.UpdateAsync(filme.Id, request.AtualizarFilmeDto);
            return mapper.Map<AtualizarFilmeDto>(filme);
        }
    }
}

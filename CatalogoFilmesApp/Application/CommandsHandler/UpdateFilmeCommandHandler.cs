using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class UpdateFilmeCommandHandler : IRequestHandler<UpdateFilmeCommand, FilmesDto>
    {
        private readonly IFilmesRepository _filmesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFilmeCommandHandler> _logger;

        public UpdateFilmeCommandHandler(IFilmesRepository filmesRepository, IMapper mapper, ILogger<UpdateFilmeCommandHandler> logger)
        {
            _filmesRepository = filmesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FilmesDto> Handle(UpdateFilmeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Atualizando filme {request.FilmesDto.Titulo}.");

            var filme = _mapper.Map<Filme>(request.FilmesDto);
            await _filmesRepository.UpdateAsync(filme);
            return _mapper.Map<FilmesDto>(filme);
        }
    }
}

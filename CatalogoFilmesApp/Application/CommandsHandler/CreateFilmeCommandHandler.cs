using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class CreateFilmeCommandHandler : IRequestHandler<CreateFilmeCommand, FilmesDto>
    {
        private readonly IFilmesRepository _filmesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFilmeCommandHandler> _logger;

        public CreateFilmeCommandHandler(IFilmesRepository filmesRepository, IMapper mapper, ILogger<CreateFilmeCommandHandler> logger)
        {
            _filmesRepository = filmesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FilmesDto> Handle(CreateFilmeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Cadastrando um novo filme: {request.FilmesDto.Titulo}");

            var filme = _mapper.Map<Filme>(request.FilmesDto);
            await _filmesRepository.AddAsync(filme);
            return _mapper.Map<FilmesDto>(filme);
        }
    }
}

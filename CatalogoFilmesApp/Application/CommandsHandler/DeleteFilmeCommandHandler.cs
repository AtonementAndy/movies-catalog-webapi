using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class DeleteFilmeCommandHandler : IRequestHandler<DeleteFilmeCommand, FilmesDto>
    {
        private readonly IFilmesRepository _filmesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteFilmeCommandHandler> _logger;

        public DeleteFilmeCommandHandler(IFilmesRepository filmesRepository, IMapper mapper, ILogger<DeleteFilmeCommandHandler> logger)
        {
            _filmesRepository = filmesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FilmesDto> Handle(DeleteFilmeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deletando um filme via CQRS.");

            var filme = await _filmesRepository.GetByIdAsync(request.Id);
            await _filmesRepository.DeleteAsync(filme.Id);
            return _mapper.Map<FilmesDto>(filme);
        }
    }
}

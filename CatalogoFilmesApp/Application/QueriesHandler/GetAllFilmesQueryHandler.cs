using AutoMapper;
using CatalogoFilmesApp.Application.Queries;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.QueriesHandler
{
    public class GetAllFilmesQueryHandler : IRequestHandler<GetAllFilmesQuery, List<FilmesDto>>
    {
        private readonly IFilmesRepository _filmesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllFilmesQueryHandler> _logger;

        public GetAllFilmesQueryHandler(IFilmesRepository filmesRepository, IMapper mapper, ILogger<GetAllFilmesQueryHandler> logger)
        {
            _filmesRepository = filmesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<FilmesDto>> Handle(GetAllFilmesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando todos os filmes via CQRS.");

            var filmes = await _filmesRepository.GetAllAsync();
            return _mapper.Map<List<FilmesDto>>(filmes);
        }
    }
}

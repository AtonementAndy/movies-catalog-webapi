using AutoMapper;
using CatalogoFilmesApp.Application.Queries;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using MediatR;

namespace CatalogoFilmesApp.Application.QueriesHandler
{
    public class GetFilmeByIdQueryHandler : IRequestHandler<GetFilmeByIdQuery, FilmesDto>
    {
        private readonly IFilmesRepository _filmesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFilmeByIdQueryHandler> _logger;

        public GetFilmeByIdQueryHandler(IFilmesRepository filmesRepository, IMapper mapper, ILogger<GetFilmeByIdQueryHandler> logger)
        {
            _filmesRepository = filmesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FilmesDto> Handle(GetFilmeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Buscando filme por Id via CQRS.");

            var filme = await _filmesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<FilmesDto>(filme);
        }
    }
}

﻿using AutoMapper;
using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using MediatR;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class UpdateFilmeCommandHandler : IRequestHandler<UpdateFilmeCommand, AtualizarFilmeDto>
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

        public async Task<AtualizarFilmeDto> Handle(UpdateFilmeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Atualizando filme {request.AtualizarFilmeDto.Titulo}.");

            var filme = _mapper.Map<Filme>(request.AtualizarFilmeDto);
            await _filmesRepository.UpdateAsync(filme.Id, request.AtualizarFilmeDto);
            return _mapper.Map<AtualizarFilmeDto>(filme);
        }
    }
}

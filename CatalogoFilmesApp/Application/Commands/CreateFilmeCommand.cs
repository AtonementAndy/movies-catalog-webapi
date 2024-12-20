﻿using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class CreateFilmeCommand : IRequest<FilmesDto>
    {
        public CriarFilmeDto CriarFilmeDto { get; set; } = default!;
    }
}

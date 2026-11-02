using CatalogoFilmesApp.Application.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class UpdateFilmeCommand : IRequest<AtualizarFilmeDto>
    {
        public AtualizarFilmeDto AtualizarFilmeDto { get; set; } = new();
    }
}

using CatalogoFilmesApp.Domain.DTOs;
using MediatR;

namespace CatalogoFilmesApp.Application.Commands
{
    public class UpdateFilmeCommand : IRequest<AtualizarFilmeDto>
    {
        public AtualizarFilmeDto AtualizarFilmeDto { get; set; } = default!;
    }
}

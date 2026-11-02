using CatalogoFilmesApp.Application.DTOs;
using FluentValidation;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class DeleteFilmeValidator : AbstractValidator<ExcluirFilmeDto>
    {
        public DeleteFilmeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do filme a ser excluído é obrigatório.");
        }
    }
}
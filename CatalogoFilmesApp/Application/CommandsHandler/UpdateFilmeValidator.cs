using CatalogoFilmesApp.Application.DTOs;
using FluentValidation;

namespace CatalogoFilmesApp.Application.CommandsHandler
{
    public class UpdateFilmeValidator : AbstractValidator<AtualizarFilmeDto>
    {
        public UpdateFilmeValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título do filme é obrigatório.")
                .MaximumLength(100).WithMessage("O título do filme não pode exceder 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição do filme é obrigatória.")
                .MaximumLength(200).WithMessage("A descrição do filme não pode exceder 200 caracteres.");

            RuleFor(x => x.Autor)
                .NotEmpty().WithMessage("O autor do filme é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do autor não pode exceder 150 caracteres.");
        }
    }
}
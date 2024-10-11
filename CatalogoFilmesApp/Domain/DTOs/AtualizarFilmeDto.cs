using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmesApp.Domain.DTOs
{
    public record AtualizarFilmeDto
    {
        [StringLength(200, ErrorMessage = "O título não pode exceder 200 caracteres.")]
        public string? Titulo { get; init; }

        [StringLength(1000, ErrorMessage = "A descrição não pode exceder 1000 caracteres.")]
        public string? Descricao { get; init; }

        [StringLength(100, ErrorMessage = "O autor não pode exceder 100 caracteres.")]
        public string? Autor { get; init; }
    }
}
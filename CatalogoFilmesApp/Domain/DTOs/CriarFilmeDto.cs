using System.ComponentModel.DataAnnotations;

namespace CatalogoFilmesApp.Domain.DTOs
{
    public record CriarFilmeDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título não pode exceder 200 caracteres.")]
        public string Titulo { get; init; } = string.Empty;

        [StringLength(1000, ErrorMessage = "A descrição não pode exceder 1000 caracteres.")]
        public string Descricao { get; init; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O autor não pode exceder 100 caracteres.")]
        public string Autor { get; init; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoFilmesApp.Domain.Models
{
    public class Filme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Titulo { get; set; }

        [Required]
        [StringLength(255)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength (100)]
        public string? Autor { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}

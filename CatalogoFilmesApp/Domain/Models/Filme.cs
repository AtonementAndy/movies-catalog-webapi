using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoFilmesApp.Domain.Models
{
    public class Filme
    {
        public Filme() { }

        public Filme(int id, string titulo, string descricao, string autor, DateTime dataCadastro, bool ativo)
        {
            if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("Titulo é obrigatório.");
            if (dataCadastro > DateTime.Now) throw new ArgumentException("Data de cadastro não pode ser no futuro.");
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public string Titulo { get; init; } = string.Empty;

        [Required]
        public string Descricao { get; init; } = string.Empty;

        [Required]
        public string Autor { get; init; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; init; }

        [Required]
        public bool Ativo { get; init; }
    }
}

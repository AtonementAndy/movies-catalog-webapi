using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoFilmesApp.Domain.Models
{
    public class Filme
    {
        protected Filme() { }

        public Filme(string titulo, string descricao, string autor)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título é obrigatório.", nameof(titulo));

            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            DataCadastro = DateTime.UtcNow;
            Ativo = true;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Titulo { get; private set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Descricao { get; private set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Autor { get; private set; } = string.Empty;

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; private set; }

        public void Desativar() => Ativo = false;

        public void Atualizar(string titulo, string descricao, string autor)
        {
            if (!string.IsNullOrWhiteSpace(titulo))
                Titulo = titulo;

            Descricao = descricao;
            Autor = autor;
        }
    }
}

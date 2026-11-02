namespace CatalogoFilmesApp.Domain.Models
{
    public class Filme
    {
        protected Filme() { }

        public Filme(string titulo, string descricao, string autor)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título é obrigatório.", nameof(titulo));

            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            DataCadastro = DateTime.UtcNow;
            Ativo = true;
        }

        public Guid Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
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

namespace CatalogoFilmesApp.Domain.DTOs
{
    
    public record FilmesDto()
    {

        public FilmesDto(int id, string titulo, string descricao, string autor, DateTime dataCadastro, bool ativo) : this()
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Autor = autor;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public int Id { get; init; }
        public string Titulo { get; init; } = string.Empty;
        public string Descricao { get; init; } = string.Empty;
        public string Autor { get; init; } = string.Empty;
        public DateTime DataCadastro { get; init; }
        public bool Ativo { get; init; }
    }
}

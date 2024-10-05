namespace CatalogoFilmesApp.Domain.DTOs
{
    public class FilmesDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Autor { get; set; }
        public bool Ativo { get; set; }
    }
}

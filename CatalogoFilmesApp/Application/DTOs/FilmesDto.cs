namespace CatalogoFilmesApp.Application.DTOs
{
    
    public record FilmesDto(
        Guid Id,
        string Titulo,
        string Descricao,
        string Autor,
        DateTime DataCadastro,
        bool Ativo
    );
}

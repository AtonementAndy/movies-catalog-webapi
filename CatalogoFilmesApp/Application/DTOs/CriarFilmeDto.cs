namespace CatalogoFilmesApp.Application.DTOs
{
    public record CriarFilmeDto(
        string Titulo,
        string Descricao,
        string Autor
    );
}
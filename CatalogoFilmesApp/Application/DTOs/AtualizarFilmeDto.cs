namespace CatalogoFilmesApp.Application.DTOs
{
    public record AtualizarFilmeDto(
        string Titulo,
        string Descricao,
        string Autor
    );
}
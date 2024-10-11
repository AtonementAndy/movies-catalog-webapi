using AutoMapper;
using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Models;

namespace CatalogoFilmesApp.Domain.Mapping
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, FilmesDto>().ReverseMap();
            CreateMap<CriarFilmeDto, Filme>().ReverseMap();
            CreateMap<AtualizarFilmeDto, Filme>().ReverseMap();
        }
    }
}

using CatalogoFilmesApp.Domain.DTOs;
using CatalogoFilmesApp.Domain.Interfaces;
using CatalogoFilmesApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CatalogoFilmesApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmesRepository _filmeRepository;

        public FilmesController(IFilmesRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Filme>> GetAll()
        {
            var filme = await _filmeRepository.GetAllAsync();
            return Ok(filme);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);

            if (filme is null)
                NotFound();

            return Ok(filme);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> CreateFilme([FromBody]  FilmesDto filmeDto)
        {
            if (filmeDto is not null)
            {
                var filme = new Filme
                {
                    Id = filmeDto.Id,
                    Titulo = filmeDto.Titulo,
                    Descricao = filmeDto.Descricao,
                    Autor = filmeDto.Autor,
                    Ativo = filmeDto.Ativo
                };

                await _filmeRepository.AddAsync(filme);
                return CreatedAtAction(nameof(CreateFilme), new { id = filme.Id }, filme);
            }
            
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Filme>> DeleteFilme(int id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);

            if (filme is null)
                NotFound();

            await _filmeRepository.DeleteAsync(filme.Id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Filme>> UpdateFilme(int id, FilmesDto filmeDto)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);

            if (filme is null)
                NotFound();

            filme.Titulo = filmeDto.Titulo;
            filme.Descricao = filmeDto.Descricao;
            filme.Autor = filmeDto.Autor;
            filme.Ativo = filmeDto.Ativo;

            await _filmeRepository.UpdateAsync(filme);

            return NoContent();
        }
    }
}

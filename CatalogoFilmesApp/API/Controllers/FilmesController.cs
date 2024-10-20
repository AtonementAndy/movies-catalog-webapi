﻿using CatalogoFilmesApp.Application.Commands;
using CatalogoFilmesApp.Application.Queries;
using CatalogoFilmesApp.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoFilmesApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilmesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filmes = await _mediator.Send(new GetAllFilmesQuery());
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var filme = await _mediator.Send(new GetFilmeByIdQuery(id));
            return Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> PostFilme([FromBody] CriarFilmeDto criarFilmeDto)
        {
            var filme = await _mediator.Send(new CreateFilmeCommand { CriarFilmeDto = criarFilmeDto });
            return CreatedAtAction(nameof(PostFilme), new { id = filme.Id }, filme);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFilme(AtualizarFilmeDto atualizarFilmeDto)
        {
            await _mediator.Send(new UpdateFilmeCommand { AtualizarFilmeDto = atualizarFilmeDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            if (id == 0)
                return NotFound();

            await _mediator.Send(new DeleteFilmeCommand(id));
            return NoContent();
        }
    }
}

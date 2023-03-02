using System.Net.NetworkInformation;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        
        public FilmeController(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionaFilme([FromBody]FilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _dataContext.Add(filme);
            await _dataContext.SaveChangesAsync();
            return Created($"/Filme/{filme.Id}", filme);
        }

        [HttpGet]
        public IActionResult GetFilmes([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            return Ok(_dataContext.Filmes.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme(Guid id)
        {
            var filme = await _dataContext.Filmes.FirstOrDefaultAsync(f => f.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaFilme(Guid id, [FromBody]UpdateFilmeDto dto)
        {
            var filme = await _dataContext.Filmes.FirstOrDefaultAsync(f => f.Id == id);

            if (filme == null) return NotFound();
            //filme.Duracao = dto.Duracao;
            //filme.Genero = dto.Genero;
            //filme.Titulo = dto.Titulo;
            //_dataContext.Filmes.Update(filme);
            //_dataContext.SaveChanges();
            //Utilizando AutoMapper:
            _mapper.Map(dto, filme);
            _dataContext.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizaFilmeParcial(Guid id, JsonPatchDocument<UpdateFilmeDto> patch)
        {
             var filme = _dataContext.Filmes.FirstOrDefault(f => f.Id == id);
             if (filme == null) return NotFound();

             var filmeAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

             patch.ApplyTo(filmeAtualizar, ModelState);

             if (!TryValidateModel(filmeAtualizar))
             {
                 return ValidationProblem(ModelState);
             }

             _mapper.Map(filmeAtualizar, filme);
             await _dataContext.SaveChangesAsync();
             return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFilme(Guid id)
        {
            var filme = await _dataContext.Filmes.FirstOrDefaultAsync(f => f.Id == id);

            if (filme == null) return NotFound();

            _dataContext.Remove(filme);
            _dataContext.SaveChanges();
            return NoContent();
        }
    }
}

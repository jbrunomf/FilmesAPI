using System.Net.NetworkInformation;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> _filmes = new();

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody]Filme filme)
        {
            _filmes.Add(filme);

            return Created($"/Filme/{filme.Id}", filme);
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            return _filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilme(Guid id)
        {
            var filme = _filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            return Ok(filme);

        }
    }
}

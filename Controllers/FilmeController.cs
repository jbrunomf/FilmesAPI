using System.Net.NetworkInformation;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private DataContext _dataContext;

        public FilmeController(DataContext context)
        {
            _dataContext = context;
        }


        [HttpPost]
        public async Task<IActionResult> AdicionaFilme([FromBody]Filme filme)
        {
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
    }
}

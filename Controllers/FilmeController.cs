using System.Net.NetworkInformation;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTO;
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
        private IMapper _mapper;
        
        public FilmeController(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }


        [HttpPost]
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
    }
}

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
        public void AdicionaFilme([FromBody]Filme filme)
        {
            _filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            return _filmes;
        }
    }
}

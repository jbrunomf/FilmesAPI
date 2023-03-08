using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : Controller
{
    private DataContext _context;
    private IMapper _mapper;

    public SessaoController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaSessao([FromBody] CreateSessaoDto createSessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(createSessaoDto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaSessaoporId), new { Id = sessao.Id }, sessao);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult RecuperaSessaoporId(Guid id)
    {
        var sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);
        if (sessao != null) return Ok(sessao);
        return NotFound();
    }

    [HttpGet]
    public IActionResult RecuperaSessao()
    {
        if (_context.Sessoes.Any()) return Ok(_mapper.Map<ICollection<Sessao>, ICollection<ReadSessaoDto>>(_context.Sessoes.ToList()));
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaSessao(Guid id)
    {
        var sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);

        if (sessao == null) return NotFound("Sessão não encontrada.");
        _context.Sessoes.Remove(sessao);
        _context.SaveChanges();
        return NoContent();

    }
}
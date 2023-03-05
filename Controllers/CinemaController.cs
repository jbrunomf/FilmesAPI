using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route(("[controller]"))]
public class CinemaController : ControllerBase
{
    private DataContext _context;
    private IMapper _mapper;


    public CinemaController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemasPorId), new { cinema.Id }, cinemaDto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemasPorId([FromRoute] Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

        if (cinema != null) return Ok(cinema);
        return NotFound();
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperarCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpPut]
    public IActionResult AtualizaCinema(Guid id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }
    
    
}

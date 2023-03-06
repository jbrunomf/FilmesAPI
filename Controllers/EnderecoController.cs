using System.Data;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.DTO;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")] 
public class EnderecoController : ControllerBase
{
    private DataContext _context;
    private IMapper _mapper;

    public EnderecoController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto dto)
    {
        Endereco endereco = _mapper.Map<Endereco>(dto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEndercosPorId), new { Id = endereco.Id }, endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperaEndercos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEndercosPorId(Guid id)
    {
        Endereco? endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null) return NotFound();
        return Ok(_mapper.Map<ReadEnderecoDto>(endereco));
    }
} 
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesAPI.DTO;

public class ReadCinemaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
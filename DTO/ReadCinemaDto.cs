using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DTO;

public class ReadCinemaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
}
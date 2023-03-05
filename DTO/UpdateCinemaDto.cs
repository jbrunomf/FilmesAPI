using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DTO;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; }
}
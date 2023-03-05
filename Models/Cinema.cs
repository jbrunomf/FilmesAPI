using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; }
}
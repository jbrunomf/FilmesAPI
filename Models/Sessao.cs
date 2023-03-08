using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Sessao
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    
    public Guid? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required] 
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "{0} deve ter até 100 caracteres.")]
    public string Logradouro { get; set; }
    
    [Required]
    public int Numero { get; set; }

    public virtual Cinema Cinema { get; set; }
}
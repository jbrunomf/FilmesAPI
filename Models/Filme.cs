using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesAPI.Models;

public class Filme
{
    public Filme()
    {
            
    }

    public Filme(string titulo, string genero, int duracao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Genero = genero;
        Duracao = duracao;
    }

    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O {0} deve até {1} caracteres.")]
    public string Genero { get; set; }

    [Required]
    [Range(10, 300, ErrorMessage = "A {0} deve ter entre {1} e {2} minutos.")]
    public int Duracao { get; set; }
    
    public virtual ICollection<Sessao> Sessoes { get; set; } 
}
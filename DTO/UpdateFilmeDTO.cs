using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DTO
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O {0} deve até {1} caracteres.")]
        public string Genero { get; set; }

        [Required]
        [Range(10, 300, ErrorMessage = "A {0} deve ter entre {1} e {2} minutos.")]
        public int Duracao { get; set; }
    }
}

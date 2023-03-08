namespace FilmesAPI.DTO;

public class ReadSessaoDto
{
    public Guid Id { get; set; }
    public Guid FilmeId { get; set; }
    public Guid? CinemaId { get; set; }
}
using AutoMapper;
using FilmesAPI.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDTO, Filme>();
        }
    }
}

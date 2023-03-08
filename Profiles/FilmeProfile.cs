using AutoMapper;
using FilmesAPI.DTO;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<FilmeDTO, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>()
                .ForMember(dto => dto.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));
        }
    }
}

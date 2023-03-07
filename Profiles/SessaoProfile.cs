using AutoMapper;
using FilmesAPI.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class SessaoProfile: Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
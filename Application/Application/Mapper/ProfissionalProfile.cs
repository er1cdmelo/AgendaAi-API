using Application.Data.Entities;
using Application.Infra.DTO;
using Application.ViewModels;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class ProfissionalProfile : Profile
    {
        public ProfissionalProfile()
        {
            CreateMap<Profissional, ProfissionalTO>();
            CreateMap<ProfissionalTO, Profissional>();
            CreateMap<Profissional, ProfissionalVM>();
            CreateMap<ProfissionalVM, Profissional>();
        }
    }
}

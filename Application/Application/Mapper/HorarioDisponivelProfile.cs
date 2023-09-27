using Application.Domain.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class HorarioDisponivelProfile : Profile
    {
        public HorarioDisponivelProfile()
        {
            CreateMap<HorarioDisponivel, HorarioDisponivelTO>();
            CreateMap<HorarioDisponivelTO, HorarioDisponivel>();
        }
    }
}

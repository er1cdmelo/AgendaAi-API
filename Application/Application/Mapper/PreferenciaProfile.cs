using Application.Domain.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Data.Mapper
{
    public class PreferenciaProfile : Profile
    {
        public PreferenciaProfile()
        {
            CreateMap<Preferencia, PreferenciaTO>();
            CreateMap<PreferenciaTO, Preferencia>();
        }
    }
}

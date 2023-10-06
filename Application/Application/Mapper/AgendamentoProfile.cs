using Application.Infra.DTO;
using Application.Domain.Entities;
using AutoMapper;
using Application.Application.Global;

namespace Application.Application.Data.Mapper
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, AgendamentoTO>()
                .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => ((Enums.StatusAgendamento)src.Status).ToString()))
                .ForMember(dest => dest.ClienteTO,
                opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.ProfissionalTO,
                opt => opt.MapFrom(src => src.Profissional));
            CreateMap<AgendamentoTO, Agendamento>()
                .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => (int)Enum.Parse(typeof(Enums.StatusAgendamento), src.Status)));
        }
    }
}

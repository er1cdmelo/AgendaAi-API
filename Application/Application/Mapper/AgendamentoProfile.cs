using Application.Infra.DTO;
using Application.Domain.Entities;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, AgendamentoTO>();
            CreateMap<AgendamentoTO, Agendamento>();
        }
    }
}

using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Presentation.ViewModels;
using AutoMapper;

namespace Application.Application.Mapper
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<Servico, ServicoTO>();
            CreateMap<ServicoTO, Servico>();
        }
    }
}

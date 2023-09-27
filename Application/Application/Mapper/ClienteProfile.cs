using Application.Domain.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteTO>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf));
                //.ForMember(dest => dest.DtNascimento, opt => opt.MapFrom(src => src.DtNascimento))
                //.ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                //.ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
        }
    }
}

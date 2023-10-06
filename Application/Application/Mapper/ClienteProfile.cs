using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Presentation.ViewModels;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteTO>();
            CreateMap<ClienteTO, Cliente>();
            CreateMap<UsuarioClienteVM, Cliente>();
            CreateMap<ClienteVM, Cliente>();
        }
    }
}

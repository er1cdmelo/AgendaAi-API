using Application.Domain.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Data.Mapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioTO>();
            CreateMap<UsuarioTO, Usuario>();
        }
    }
}

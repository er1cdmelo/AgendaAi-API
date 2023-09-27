using Application.Data.Entities;
using Application.Infra.DTO;
using AutoMapper;

namespace Application.Application.Data.Mapper
{
    public class UserTokenProfile : Profile
    {
        public UserTokenProfile()
        {
            CreateMap<UserToken, UserTokenTO>();
            CreateMap<UserTokenTO, UserToken>();
        }
    }
}

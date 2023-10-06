using Application.Data.Repositories;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;
using AutoMapper;

namespace Application.Application.AppServices
{
    public class TokenAppServices
    {
        private readonly TokenRepository _repository;
        private readonly IMapper _mapper;
        public TokenAppServices(TokenRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UserTokenTO GetByCode(TokenLoginRequest code)
        {
            var token = _repository.GetTokenByCode(code);
            return _mapper.Map<UserTokenTO>(token);
        }

        public UserTokenTO UpdateToken(string refreshToken)
        {
            UserTokenTO token = _repository.UpdateToken(refreshToken);
            return token;
        }

        public UserTokenTO CreateToken(Usuario usuario)
        {
            UserTokenTO token = _repository.CreateToken(usuario);
            return token;
        }
    }
}

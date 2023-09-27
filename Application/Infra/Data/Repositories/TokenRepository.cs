using Application.Configuration.Utils;
using Application.Data.Entities;
using Application.Domain.Entities;
using Application.Infra.DTO;
using Application.Models.Requests;
using AutoMapper;
using System.Configuration;

namespace Application.Data.Repositories
{
    public class TokenRepository
    {
        private readonly AgendaContext _context;
        private readonly TokenManager _tokenManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public TokenRepository(AgendaContext context, TokenManager tokenManager, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _tokenManager = tokenManager;
            _configuration = configuration;
            _mapper = mapper;
        }
        public UserTokenTO GetTokenByCode(TokenLoginRequest searchedToken)
        {
            try
            {
                UserToken token = _context.UserToken.FirstOrDefault(t => t.AccessToken == searchedToken.AccessToken || 
                t.RefreshToken == searchedToken.RefreshToken) 
                    ?? new UserToken();
                UserTokenTO tokenTO = _mapper.Map<UserTokenTO>(token);
                return tokenTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserTokenTO GetTokenByUserId(int userId)
        {
            try
            {
                UserToken token = _context.UserToken.FirstOrDefault(t => t.UserId == userId) 
                    ?? new UserToken();
                UserTokenTO tokenTO = _mapper.Map<UserTokenTO>(token);
                return tokenTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public UserTokenTO CreateToken(Usuario usuario)
        {
            try
            {
                string accessToken = _tokenManager.GenerateAccessToken();
                string refreshToken = _tokenManager.GenerateRefreshToken(usuario.IdUsuario, usuario.Email);
                int expirationTime = Convert.ToInt32(_configuration["AccessTokenExpiration"]);
                int refreshExpirationTime = Convert.ToInt32(_configuration["RefreshTokenExpiration"]);

                UserToken token = new UserToken
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    TokenType = "Bearer",
                    ExpiresIn = expirationTime,
                    RefreshExpiresIn = refreshExpirationTime,
                    UserId = usuario.IdUsuario,
                    CreatedAt = DateTimeOffset.Now,
                    UpdatedAt = null,
                    Scope = "user"
                };

                UserTokenTO tokenTO = _mapper.Map<UserTokenTO>(token);

                _context.UserToken.Add(token);
                _context.SaveChanges();
                return tokenTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserTokenTO UpdateToken(string refreshToken)
        {
            try
            {
                int expirationTime = Convert.ToInt32(_configuration["AccessTokenExpiration"]);
                UserToken previousToken = _context.UserToken.FirstOrDefault(t => t.RefreshToken == refreshToken) 
                    ?? new UserToken();
                UserTokenTO tokenTO = _mapper.Map<UserTokenTO>(previousToken);
                if (previousToken.Id == 0)
                {
                    return tokenTO;
                }

                string accessToken = _tokenManager.GenerateAccessToken();

                _tokenManager.UpdateUserAccessToken(tokenTO, accessToken, expirationTime);

                _context.UserToken.Update(previousToken);
                _context.SaveChanges();
                return tokenTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

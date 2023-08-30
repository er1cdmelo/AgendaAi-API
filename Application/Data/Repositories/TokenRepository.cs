using Application.Configuration.Utils;
using Application.Data.Entities;
using Application.Models;
using System.Configuration;

namespace Application.Data.Repositories
{
    public class TokenRepository
    {
        private readonly AgendaContext _context;
        private readonly TokenManager _tokenManager;
        private readonly IConfiguration _configuration;
        public TokenRepository(AgendaContext context, TokenManager tokenManager, IConfiguration configuration)
        {
            _context = context;
            _tokenManager = tokenManager;
            _configuration = configuration;

        }
        public UserTokenTO GetTokenByCode(string searchedToken)
        {
            try
            {
                UserTokenTO token = _context.UserToken.FirstOrDefault(t => t.AccessToken == searchedToken) 
                    ?? new UserTokenTO();
                return token;
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
                UserTokenTO token = _context.UserToken.FirstOrDefault(t => t.UserId == userId) 
                    ?? new UserTokenTO();
                return token;
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

                UserTokenTO token = new UserTokenTO
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

                _context.UserToken.Add(token);
                _context.SaveChanges();
                return token;
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
                UserTokenTO previousToken = _context.UserToken.FirstOrDefault(t => t.RefreshToken == refreshToken) 
                    ?? new UserTokenTO();

                if (previousToken.Id == 0)
                {
                    return previousToken;
                }

                string accessToken = _tokenManager.GenerateAccessToken();
                // we are not generating a new refresh token, since the user is already logged in
                // and we don't want to invalidate the previous token

                _tokenManager.UpdateUserAccessToken(previousToken, accessToken, expirationTime);

                _context.UserToken.Update(previousToken);
                _context.SaveChanges();
                return previousToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

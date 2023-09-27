using Application.Infra.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Configuration.Utils
{
    public class TokenManager
    {
        private static bool Verify(string sentToken, string realToken)
        {
            return BCrypt.Net.BCrypt.Verify(sentToken, realToken);
        }

        private static string Hash(string token)
        {
            return BCrypt.Net.BCrypt.HashPassword(token);
        }

        public string CreateTokenJWT()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("12345678901234567890123456789012");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Eric"),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);            
            return tokenHandler.WriteToken(token);
        }

        public string GenerateAccessToken()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string randomGuid = Guid.NewGuid().ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(randomGuid);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public string GenerateRefreshToken(int idUsuario, string email)
        {
            // Created with Bcrypt
            string combined = idUsuario + "_" + email;
            string token = Hash(combined);
            return token;
        }

        public bool VerifySimpleToken(int idUsuario, string email, string token)
        {
            string basedToken = String.Concat(idUsuario, "_") + String.Concat(email, token);
            return Verify(basedToken, token);
        }

        public void UpdateUserAccessToken(UserTokenTO previousToken, string newToken, int lifetime)
        {
            previousToken.AccessToken = newToken;
            previousToken.ExpiresIn = lifetime;
            previousToken.UpdatedAt = DateTimeOffset.Now;
        }

        public void UpdateUserRefreshToken(UserTokenTO previousToken, string newToken, int lifetime)
        {
            previousToken.RefreshToken = newToken;
            previousToken.RefreshExpiresIn = lifetime;
            previousToken.UpdatedAt = DateTimeOffset.Now;
        }

        public bool AccessTokenIsExpired(UserTokenTO token)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            DateTimeOffset baseTime = token.UpdatedAt ?? token.CreatedAt;
            int expiresIn = token.ExpiresIn;
            DateTimeOffset expiresAt = baseTime.AddMinutes(expiresIn);
            return now > expiresAt;
        }

        public bool RefreshTokenIsExpired(UserTokenTO token)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            DateTimeOffset createdAt = token.CreatedAt;
            int expiresIn = token.RefreshExpiresIn;
            DateTimeOffset expiresAt = createdAt.AddMinutes(expiresIn);
            return now > expiresAt;
        }
    }
}

namespace Application.Models.Requests
{
    public class TokenLoginRequest
    {
        public string AccessToken;
        public string RefreshToken;
        public string TokenType;

        public TokenLoginRequest(string accessToken, string refreshToken, string tokenType)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            TokenType = tokenType;
        }

        public TokenLoginRequest()
        {
        }
    }
}

namespace Application.Data.Entities
{
    public class UserToken
    {
        public UserToken()
        {
            AccessToken = string.Empty;
            RefreshToken = string.Empty;
            TokenType = string.Empty;
            Scope = string.Empty;
        }
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public int RefreshExpiresIn { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string Scope { get; set; }
    }

}

namespace Application.Utils
{
    public class PasswordService
    {
        private static bool Verify(string sentToken, string realToken)
        {
            return BCrypt.Net.BCrypt.Verify(sentToken, realToken);
        }

        private static string Hash(string token)
        {
            return BCrypt.Net.BCrypt.HashPassword(token);
        }
        public static string HashPassword(string password)
        {
            return Hash(password);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return Verify(password, hash);
        }
    }
}

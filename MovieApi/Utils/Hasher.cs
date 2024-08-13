using BCrypt.Net;

namespace MovieApi.Utils
{
    public class Hasher
    {
        public static string HashPassword(string s)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            return BCrypt.Net.BCrypt.HashPassword(s, salt);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}

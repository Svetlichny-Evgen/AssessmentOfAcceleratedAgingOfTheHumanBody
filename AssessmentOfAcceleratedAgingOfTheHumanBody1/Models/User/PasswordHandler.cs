using System.Security.Cryptography;
using System.Text;

namespace AssessmentOfAcceleratedAgingOfTheHumanBody1.Models.User
{
    public class PasswordHandler
    {
        // Метод для кодирования пароля
        public static string EncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty");
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Метод для проверки совпадения введенного и сохраненного паролей
        public static bool VerifyPassword(string inputPassword, string savedPassword)
        {
            string inputPasswordHash = EncodePassword(inputPassword);
            return string.Equals(inputPasswordHash, savedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}

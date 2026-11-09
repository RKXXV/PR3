using System;
using System.Text;

namespace PR3.Services
{
    public class CaptchaGenerator
    {
        private static readonly Random random = new Random();
        private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        public static string GenerateCaptchaText(int lenght)
        {
            if (lenght <= 0)
            {
                throw new ArgumentException("Длина текста капчи должна быть больше 0.");
            }

            StringBuilder captchaText = new StringBuilder(lenght);

            for (int i = 0; i < lenght; i++)
            {
                int index = random.Next(characters.Length);
                captchaText.Append(characters[index]);
            }

            return captchaText.ToString();
        }
    }
}

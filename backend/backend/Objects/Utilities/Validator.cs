using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace backend.Objects.Utilities
{
    public static class Validator
    {
        public static bool CompareString(string str1, string str2)
        {
            return string.Equals(str1.RemoveDiacritics(), str2.RemoveDiacritics(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNumbers(this string text)
        {
            return !string.IsNullOrEmpty(text) && Regex.IsMatch(text, @"^\d+$");
        }

        public static bool CheckValidPhone(string phone)
        {
            int phoneLength = Operator.ExtractNumbers(phone).Length;
            return phoneLength > 9 && phoneLength < 12;
        }

        public static int CheckValidEmail(string email)
        {
            // Verifica se há um único "@" e que não está no início ou no final
            int atCount = email.Count(c => c == '@');
            bool hasTextBeforeAt = email.IndexOf('@') > 0;
            bool hasTextAfterAt = email.LastIndexOf('@') < email.Length - 1;

            // Verifica se após o "@" há um "." e se não termina com "."
            int atPosition = email.IndexOf('@');
            bool hasDotAfterAt = atPosition >= 0 && email.IndexOf('.', atPosition) > atPosition;
            bool endsWithDot = email.EndsWith('.');

            // Verificações
            if (atCount != 1) return -1; // E-mail inteiro inválido

            else if (!hasTextBeforeAt) return -1; // Parte antes do @ inválida

            else if (!hasTextAfterAt) return -2; // Domínio inválido

            else if (!hasDotAfterAt) return -2; // Domínio inválido

            else if (endsWithDot) return -1; // E-mail inteiro inválido

            return 1; // E-mail válido
        }
    }
}
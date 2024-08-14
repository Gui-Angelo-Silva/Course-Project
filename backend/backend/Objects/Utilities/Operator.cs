using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace backend.Objects.Utilities
{
    public static class Operator
    {
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string ExtractNumbers(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return new string(text.Where(char.IsDigit).ToArray());
        }

        public static bool CompareString(string str1, string str2)
        {
            return string.Equals(str1.RemoveDiacritics(), str2.RemoveDiacritics(), StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNumbers(this string text)
        {
            return !string.IsNullOrEmpty(text) && Regex.IsMatch(text, @"^\d+$");
        }

        public static string FormatForCurrency(double amount)
        {
            // Converte decimal para string com exatamente duas casas decimais
            string formattedAmount = amount.ToString("F2", CultureInfo.InvariantCulture);

            // Divide o número em parte inteira e parte decimal
            string[] parts = formattedAmount.Split('.');
            string integerPart = parts[0];
            string decimalPart = parts.Length > 1 ? parts[1].PadRight(2, '0') : "00";

            // Adiciona separadores de milhar à parte inteira
            integerPart = Regex.Replace(integerPart, @"(\d)(?=(\d{3})+(?!\d))", "$1.");

            // Retorna a string formatada com espaço
            return $"R$ {integerPart},{decimalPart}";
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a string para um array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converte o array de bytes de volta para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
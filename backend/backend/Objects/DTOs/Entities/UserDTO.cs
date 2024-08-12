using backend.Objects.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend.Objects.DTOs.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? ImageUser { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido!")]
        [MinLength(10)]
        [MaxLength(100)]
        public string EmailUser
        {
            get => _emailUser;
            set => _emailUser = value.ToLower();
        }
        private string _emailUser;

        [MinLength(8)]
        [MaxLength(128)]
        [Required(ErrorMessage = "A senha é requerida!")]
        public string PasswordUser { get; set; }

        [Required(ErrorMessage = "O telefone é requerido!")]
        [MinLength(14)]
        [MaxLength(15)]
        public string PhoneUser { get; set; }


        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }



        public bool CheckValidPhone()
        {
            int phoneLength = Operator.ExtractNumbers(this.PhoneUser).Length;
            return phoneLength > 9 && phoneLength < 12;
        }

        public int CheckValidEmail()
        {
            // Verifica se há um único "@" e que não está no início ou no final
            int atCount = this.EmailUser.Count(c => c == '@');
            bool hasTextBeforeAt = this.EmailUser.IndexOf('@') > 0;
            bool hasTextAfterAt = this.EmailUser.LastIndexOf('@') < this.EmailUser.Length - 1;

            // Verifica se após o "@" há um "." e se não termina com "."
            int atPosition = this.EmailUser.IndexOf('@');
            bool hasDotAfterAt = atPosition >= 0 && this.EmailUser.IndexOf('.', atPosition) > atPosition;
            bool endsWithDot = this.EmailUser.EndsWith('.');

            // Verificações
            if (atCount != 1)
            {
                return -1; // E-mail inteiro inválido
            }

            if (!hasTextBeforeAt)
            {
                return -1; // Parte antes do @ inválida
            }

            if (!hasTextAfterAt)
            {
                return -2; // Domínio inválido
            }

            if (!hasDotAfterAt)
            {
                return -2; // Domínio inválido
            }

            if (endsWithDot)
            {
                return -1; // E-mail inteiro inválido
            }

            return 1; // E-mail válido
        }
    }
}
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

        [Required(ErrorMessage = "A senha é requerida!")]
        [MinLength(8)]
        [MaxLength(128)]
        public string PasswordUser { get; set; }

        [Required(ErrorMessage = "O telefone é requerido!")]
        [MinLength(14)]
        [MaxLength(15)]
        public string PhoneUser { get; set; }


        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido!")]
        public string EmailUser
        {
            get => _emailUser;
            set => _emailUser = value.ToLower();
        }
        private string _emailUser;

        [Required(ErrorMessage = "A senha é requerida!")]
        public string PasswordUser { get; set; }

        [Required(ErrorMessage = "O telefone é requerido!")]
        public string PhoneUser { get; set; }


        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }
    }
}
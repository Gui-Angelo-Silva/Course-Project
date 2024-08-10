using System.Text.Json.Serialization;

namespace SGED.Objects.DTOs.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string NameUser { get; set; }

        public string EmailUser
        {
            get => _emailUser;
            set => _emailUser = value.ToLower();
        }
        private string _emailUser;

        public string PasswordUser { get; set; }

        public string PhoneUser { get; set; }


        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }
    }
}
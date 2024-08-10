using System.Text.Json.Serialization;

namespace SGED.Objects.DTOs.Entities
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public DateTime DateReservation { get; set; }

        public decimal ValueReservation
        {
            get => _valueReservation;
            set => _valueReservation = Math.Round(value, 2);
        }
        private decimal _valueReservation;

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public int IdUser { get; set; }

        public int IdTable { get; set; }


        [JsonIgnore]
        public UserDTO? UserDTO { get; set; }
        [JsonIgnore]
        public TableDTO? TableDTO { get; set; }
    }
}

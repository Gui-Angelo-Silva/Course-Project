using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data é requerida!")]
        public string DateReservation { get; set; }

        [Required(ErrorMessage = "A hora de início é requerida!")]
        public string HourBegin { get; set; }

        public string? HourFinish { get; set; }

        public string? TimeDuration { get; set; }

        [Required(ErrorMessage = "O valor é requerido!")]
        public decimal ValueReservation
        {
            get => _valueReservation;
            set => _valueReservation = Math.Round(value, 2);
        }
        private decimal _valueReservation;

        [Required(ErrorMessage = "O usuário é requerido!")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "A mesa é requerida!")]
        public int IdTable { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }


        [JsonIgnore]
        public UserDTO? UserDTO { get; set; }

        [JsonIgnore]
        public TableDTO? TableDTO { get; set; }
    }
}

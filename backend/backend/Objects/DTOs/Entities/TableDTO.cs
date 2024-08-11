using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class TableDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O código é requerido!")]
        [MinLength(1)]
        [MaxLength(20)]
        public string CodeTable { get; set; }

        [Required(ErrorMessage = "A capacidade é requerida!")]
        public int CapacityPersons { get; set; }

        [Required(ErrorMessage = "O valor é requerido!")]
        public decimal ValueTable
        {
            get => _valueTable;
            set => _valueTable = Math.Round(value, 2);
        }
        private decimal _valueTable;

        [Required(ErrorMessage = "O restaurante é requerido!")]
        public int IdRestaurant { get; set; }


        [JsonIgnore]
        public RestaurantDTO? RestaurantDTO { get; set; }

        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }
    }
}
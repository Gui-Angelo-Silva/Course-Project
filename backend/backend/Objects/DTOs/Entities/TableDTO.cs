using System.Text.Json.Serialization;

namespace SGED.Objects.DTOs.Entities
{
    public class TableDTO
    {
        public int Id { get; set; }

        public int NumberTable { get; set; }

        public int CapacityPersons { get; set; }

        public string LocationTable { get; set; }

        public decimal ValueTable
        {
            get => _valueTable;
            set => _valueTable = Math.Round(value, 2);
        }
        private decimal _valueTable;

        public int IdRestaurant { get; set; }


        [JsonIgnore]
        public RestaurantDTO? RestaurantDTO { get; set; }
        [JsonIgnore]
        public ICollection<ReservationDTO>? ReservationsDTO { get; set; }
    }
}
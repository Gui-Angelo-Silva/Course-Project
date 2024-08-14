using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class ThematicRestaurantDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O restaurante é requerido!")]
        public int IdRestaurant { get; set; }

        [Required(ErrorMessage = "A temática é requerida!")]
        public int IdThematic { get; set; }


        [JsonIgnore]
        public RestaurantDTO? RestaurantDTO { get; set; }

        [JsonIgnore]
        public ThematicDTO? ThematicDTO { get; set; }
    }
}
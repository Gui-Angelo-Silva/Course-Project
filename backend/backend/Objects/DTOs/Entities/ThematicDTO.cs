using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class ThematicDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NameThematic { get; set; }


        [JsonIgnore]
        public ICollection<ThematicRestaurantDTO>? ThematicsRestaurantDTO { get; set; }
    }
}
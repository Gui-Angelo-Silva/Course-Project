using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        public List<string>? ImageRestaurant { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        [MinLength(1)]
        [MaxLength(100)]
        public string NameRestaurant { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido!")]
        [MinLength(10)]
        [MaxLength(100)]
        public string EmailRestaurant { get; set; }

        [Required(ErrorMessage = "O telefone é requerido!")]
        [MinLength(15)]
        [MaxLength(15)]
        public string PhoneRestaurant { get; set; }


        [JsonIgnore]
        public ICollection<TableDTO>? TablesDTO { get; set; }
    }
}
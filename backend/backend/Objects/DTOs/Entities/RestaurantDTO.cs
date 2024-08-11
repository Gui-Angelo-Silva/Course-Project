using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Objects.DTOs.Entities
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A franquia é requerida!")]
        public string NameFranchise { get; set; }

        [Required(ErrorMessage = "O nome é requerido!")]
        public string NameRestaurant { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido!")]
        public string EmailRestaurant { get; set; }

        [Required(ErrorMessage = "O telefone é requerido!")]
        public string PhoneRestaurant { get; set; }


        [JsonIgnore]
        public ICollection<TableDTO>? TablesDTO { get; set; }
    }
}
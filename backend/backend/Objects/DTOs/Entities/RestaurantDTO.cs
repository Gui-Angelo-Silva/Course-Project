using System.Text.Json.Serialization;

namespace SGED.Objects.DTOs.Entities
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        public string NameFranchise { get; set; }

        public string NameRestaurant { get; set; }

        public string EmailRestaurant { get; set; }

        public string PhoneRestaurant { get; set; }


        [JsonIgnore]
        public ICollection<TableDTO>? TablesDTO { get; set; }
    }
}
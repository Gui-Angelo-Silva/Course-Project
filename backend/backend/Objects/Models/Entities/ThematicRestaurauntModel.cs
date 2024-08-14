using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Objects.Models.Entities
{
    [Table("thematicrestaurant")]
    public class ThematicRestaurantModel
    {
        [Column("idthematicrestaurant")]
        public int Id { get; set; }

        [Column("idrestaurant")]
        public int IdRestaurant { get; set; }

        [Column("idthematic")]
        public int IdThematic { get; set; }


        public RestaurantModel? RestaurantModel { get; set; }
        public ThematicModel? ThematicModel { get; set; }
    }
}
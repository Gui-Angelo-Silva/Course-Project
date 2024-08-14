using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Objects.Models.Entities
{
    [Table("thematic")]
    public class ThematicModel
    {
        [Column("idthematic")]
        public int Id { get; set; }
        
        [Column("namethematic")]
        public string NameThematic { get; set; }


        public ICollection<ThematicRestaurantModel>? ThematicsRestaurantModel { get; set; }
    }
}
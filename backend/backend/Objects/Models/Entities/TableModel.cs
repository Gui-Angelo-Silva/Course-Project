using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Objects.Models.Entities
{
    [Table("table")]
    public class TableModel
    {
        [Column("idtable")]
        public int Id { get; set; }

        [Column("codetable")]
        public string CodeTable { get; set; }

        [Column("capacitypersons")]
        public int CapacityPersons { get; set; }

        [Column("valuetable")]
        public decimal ValueTable { get; set; }

        public bool AvailableTable { get; set; }

        [ForeignKey("idrestaurant")]
        public int IdRestaurant { get; set; }


        public RestaurantModel? RestaurantModel { get; set; }
        public ICollection<ReservationModel>? ReservationsModel { get; set; }
    }
}